using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Common
{
    public class SNTP客户端
    {
        private const byte SNTP数据长度 = 48;

        // Offset constants for timestamps in the data structure
        private const byte offReferenceID = 12;
        private const byte offReferenceTimestamp = 16;
        private const byte offOriginateTimestamp = 24;
        private const byte offReceiveTimestamp = 32;
        private const byte offTransmitTimestamp = 40;
        // SNTP Data Structure (as described in RFC 2030)
        private byte[] _sntp数据 = new byte[SNTP数据长度];

        public void Connect(bool 更新本机时间)
        {
            try
            {
                // Resolve server address
                var hostadd = Dns.GetHostEntry(时间服务器);
                var EPhost = new IPEndPoint(hostadd.AddressList[0], 端口号);

                //Connect the time server
                var TimeSocket = new UdpClient();

                TimeSocket.Connect(EPhost);

                编码时间数据();

                TimeSocket.Send(_sntp数据, _sntp数据.Length);
                TimeSocket.Client.SendTimeout = 2000;
                TimeSocket.Client.ReceiveTimeout = 2000;
                TimeSocket.ReceiveAsync().ContinueWith(x =>
                {
                    _sntp数据 = x.Result.Buffer;
                    if (!Is接收失败())
                    {
                        接收数据后方法(new 时间同步结果
                        {
                            同步成功 = false,
                            错误信息 = "无法连接",
                            上次同步 = DateTime.Now
                        });
                        return;
                    }

                    目的地时间戳t4 = DateTime.Now;
                    var 时钟偏移 = 本地时钟偏移;
                    时钟偏移 += (int)微调时间.TotalMilliseconds;
                    bool 设置本地成功 = false;
                    if (更新本机时间)
                    {
                        if (Math.Abs(时钟偏移) > 允许误差.TotalMilliseconds)
                        {
                            设置本地成功 = 设置时间(时钟偏移);
                        }
                        else
                        {
                            设置本地成功 = true;
                        }

                    }

                    接收数据后方法(new 时间同步结果
                    {
                        同步成功 = true,
                        当前误差 = TimeSpan.FromMilliseconds(时钟偏移),
                        上次同步 = DateTime.Now,
                        设置成功 = 设置本地成功
                    });
                });
            }
            catch (SocketException e)
            {
                接收数据后方法(new 时间同步结果
                {
                    同步成功 = false,
                    错误信息 = e.Message,
                    上次同步 = DateTime.Now
                });
            }
        }

        private void 接收数据后方法(时间同步结果 时间同步结果2)
        {
            同步后方法(时间同步结果2);
        }
        // Destination Timestamp (T4)
        public DateTime 目的地时间戳t4;

        public Action<时间同步结果> 同步后方法 = x => { };

        public int 端口号 { get; set; } = 123;

        // Leap Indicator
        public _LeapIndicator LeapIndicator
        {
            get
            {
                // Isolate the two most significant bits
                var val = (byte)(_sntp数据[0] >> 6);
                switch (val)
                {
                    case 0:
                        return _LeapIndicator.NoWarning;
                    case 1:
                        return _LeapIndicator.LastMinute61;
                    case 2:
                        return _LeapIndicator.LastMinute59;
                    case 3:
                        goto default;
                    default:
                        return _LeapIndicator.Alarm;
                }
            }
        }

        public byte 版本号
        {
            get
            {
                // Isolate bits 3 - 5
                var val = (byte)((_sntp数据[0] & 0x38) >> 3);
                return val;
            }
        }

        // 工作模式
        public _工作模式 工作模式
        {
            get
            {
                // Isolate bits 0 - 3
                var val = (byte)(_sntp数据[0] & 0x7);
                switch (val)
                {
                    case 0:
                        goto default;
                    case 6:
                        goto default;
                    case 7:
                        goto default;
                    default:
                        return _工作模式.Unknown;
                    case 1:
                        return _工作模式.SymmetricActive;
                    case 2:
                        return _工作模式.SymmetricPassive;
                    case 3:
                        return _工作模式.Client;
                    case 4:
                        return _工作模式.Server;
                    case 5:
                        return _工作模式.Broadcast;
                }
            }
        }

        // Stratum
        public _Stratum Stratum
        {
            get
            {
                var val = _sntp数据[1];
                if (val == 0) return _Stratum.Unspecified;
                if (val == 1) return _Stratum.PrimaryReference;
                if (val <= 15) return _Stratum.SecondaryReference;
                return _Stratum.Reserved;
            }
        }

        // Poll Interval (in seconds)
        public uint PollInterval
        {
            get
            {
                // Thanks to Jim Hollenhorst <hollenho@attbi.com>
                return (uint)Math.Pow(2, (sbyte)_sntp数据[2]);
            }
        }

        // Precision (in seconds)
        public double Precision
        {
            get
            {
                // Thanks to Jim Hollenhorst <hollenho@attbi.com>
                return Math.Pow(2, (sbyte)_sntp数据[3]);
            }
        }

        // Root Delay (in milliseconds)
        public double RootDelay
        {
            get
            {
                var temp = 0;
                temp = 256 * (256 * (256 * _sntp数据[4] + _sntp数据[5]) + _sntp数据[6]) + _sntp数据[7];
                return 1000 * ((double)temp / 0x10000);
            }
        }

        // Root Dispersion (in milliseconds)
        public double RootDispersion
        {
            get
            {
                var temp = 0;
                temp = 256 * (256 * (256 * _sntp数据[8] + _sntp数据[9]) + _sntp数据[10]) + _sntp数据[11];
                return 1000 * ((double)temp / 0x10000);
            }
        }

        // Reference Identifier
        public string ReferenceID
        {
            get
            {
                var val = "";
                switch (Stratum)
                {
                    case _Stratum.Unspecified:
                        goto case _Stratum.PrimaryReference;
                    case _Stratum.PrimaryReference:
                        val += (char)_sntp数据[offReferenceID + 0];
                        val += (char)_sntp数据[offReferenceID + 1];
                        val += (char)_sntp数据[offReferenceID + 2];
                        val += (char)_sntp数据[offReferenceID + 3];
                        break;
                    case _Stratum.SecondaryReference:
                        switch (版本号)
                        {
                            case 3: // Version 3, Reference ID is an IPv4 address
                                var Address = _sntp数据[offReferenceID + 0] + "." +
                                              _sntp数据[offReferenceID + 1] + "." +
                                              _sntp数据[offReferenceID + 2] + "." +
                                              _sntp数据[offReferenceID + 3];
                                try
                                {
                                    var Host = Dns.GetHostEntry(Address);
                                    val = Host.HostName + " (" + Address + ")";
                                }
                                catch (Exception)
                                {
                                    val = "N/A";
                                }
                                break;
                            case 4: // Version 4, Reference ID is the timestamp of last update
                                var time = 计算日期(GetMilliSeconds(offReferenceID));
                                // Take care of the time zone
                                var offspan = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now);
                                val = (time + offspan).ToString();
                                break;
                            default:
                                val = "N/A";
                                break;
                        }
                        break;
                }

                return val;
            }
        }


        // Reference Timestamp
        public DateTime ReferenceTimestamp
        {
            get
            {
                var time = 计算日期(GetMilliSeconds(offReferenceTimestamp));
                // Take care of the time zone
                var offspan = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now);
                return time + offspan;
            }
        }

        // Originate Timestamp (T1)
        public DateTime 起源时间戳t1
        {
            get { return 计算日期(GetMilliSeconds(offOriginateTimestamp)); }
        }

        // Receive Timestamp (T2)
        public DateTime 接收时间戳t2
        {
            get
            {
                var time = 计算日期(GetMilliSeconds(offReceiveTimestamp));
                // Take care of the time zone
                var offspan = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now);
                return time + offspan;
            }
        }

        // Transmit Timestamp (T3)
        public DateTime 传送时间戳t3
        {
            get
            {
                var time = 计算日期(GetMilliSeconds(offTransmitTimestamp));
                // Take care of the time zone
                var offspan = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now);
                return time + offspan;
            }
            set { SetDate(offTransmitTimestamp, value); }
        }

        // Round trip delay (in milliseconds)
        public int 往返时延
        {
            get
            {
                // Thanks to DNH <dnharris@csrlink.net>
                var span = 目的地时间戳t4 - 起源时间戳t1 - (接收时间戳t2 - 传送时间戳t3);
                return (int)span.TotalMilliseconds;
            }
        }

        // Local clock offset (in milliseconds)
        public int 本地时钟偏移
        {
            get
            {
                // Thanks to DNH <dnharris@csrlink.net>
                var span = 接收时间戳t2 - 起源时间戳t1 + (传送时间戳t3 - 目的地时间戳t4);
                return (int)(span.TotalMilliseconds / 2);
            }
        }

        public string 时间服务器 { get; set; }

        public TimeSpan 微调时间 { get; set; } = TimeSpan.Zero;

        public TimeSpan 允许误差 { get; set; } = TimeSpan.FromMilliseconds(300);

        // Compute date, given the number of milliseconds since January 1, 1900
        private DateTime 计算日期(ulong milliseconds)
        {
            var span = TimeSpan.FromMilliseconds(milliseconds);
            var time = new DateTime(1900, 1, 1);
            time += span;
            return time;
        }

        // Compute the number of milliseconds, given the offset of a 8-byte array
        private ulong GetMilliSeconds(byte offset)
        {
            ulong intpart = 0, fractpart = 0;

            for (var i = 0; i <= 3; i++)
            {
                intpart = 256 * intpart + _sntp数据[offset + i];
            }
            for (var i = 4; i <= 7; i++)
            {
                fractpart = 256 * fractpart + _sntp数据[offset + i];
            }
            var milliseconds = intpart * 1000 + fractpart * 1000 / 0x100000000L;
            return milliseconds;
        }

        // Compute the 8-byte array, given the date
        private void SetDate(byte offset, DateTime date)
        {
            ulong intpart = 0, fractpart = 0;
            var StartOfCentury = new DateTime(1900, 1, 1, 0, 0, 0); // January 1, 1900 12:00 AM

            var milliseconds = (ulong)(date - StartOfCentury).TotalMilliseconds;
            intpart = milliseconds / 1000;
            fractpart = milliseconds % 1000 * 0x100000000L / 1000;

            var temp = intpart;
            for (var i = 3; i >= 0; i--)
            {
                _sntp数据[offset + i] = (byte)(temp % 256);
                temp = temp / 256;
            }

            temp = fractpart;
            for (var i = 7; i >= 4; i--)
            {
                _sntp数据[offset + i] = (byte)(temp % 256);
                temp = temp / 256;
            }
        }

        // 初始化 the NTPClient data
        private void 编码时间数据()
        {
            // Set version number to 4 and 工作模式 to 3 (client)
            _sntp数据[0] = 0x1B;
            // 初始化 all other fields with 0
            for (var i = 1; i < 48; i++)
            {
                _sntp数据[i] = 0;
            }
            // 初始化 the transmit timestamp
            传送时间戳t3 = DateTime.Now;
        }


        // Connect to the time server and update system time


        public bool Is接收失败()
        {
            if (_sntp数据.Length < SNTP数据长度 || 工作模式 != _工作模式.Server)
            {
                return false;
            }
            return true;
        }

        public override string ToString()
        {
            string str;

            str = "Leap Indicator: ";
            switch (LeapIndicator)
            {
                case _LeapIndicator.NoWarning:
                    str += "No warning";
                    break;
                case _LeapIndicator.LastMinute61:
                    str += "Last minute has 61 seconds";
                    break;
                case _LeapIndicator.LastMinute59:
                    str += "Last minute has 59 seconds";
                    break;
                case _LeapIndicator.Alarm:
                    str += "Alarm Condition (clock not synchronized)";
                    break;
            }
            str += "\r\nVersion number: " + 版本号 + "\r\n";
            str += "工作模式: ";
            switch (工作模式)
            {
                case _工作模式.Unknown:
                    str += "Unknown";
                    break;
                case _工作模式.SymmetricActive:
                    str += "Symmetric Active";
                    break;
                case _工作模式.SymmetricPassive:
                    str += "Symmetric Pasive";
                    break;
                case _工作模式.Client:
                    str += "Client";
                    break;
                case _工作模式.Server:
                    str += "Server";
                    break;
                case _工作模式.Broadcast:
                    str += "Broadcast";
                    break;
            }
            str += "\r\nStratum: ";
            switch (Stratum)
            {
                case _Stratum.Unspecified:
                case _Stratum.Reserved:
                    str += "Unspecified";
                    break;
                case _Stratum.PrimaryReference:
                    str += "Primary Reference";
                    break;
                case _Stratum.SecondaryReference:
                    str += "Secondary Reference";
                    break;
            }
            str += "\r\nLocal time: " + 传送时间戳t3;
            str += "\r\nPrecision: " + Precision + " s";
            str += "\r\nPoll Interval: " + PollInterval + " s";
            str += "\r\nReference ID: " + ReferenceID;
            str += "\r\nRoot Delay: " + RootDelay + " ms";
            str += "\r\nRoot Dispersion: " + RootDispersion + " ms";
            str += "\r\nRound Trip Delay: " + 往返时延 + " ms";
            str += "\r\nLocal Clock Offset: " + 本地时钟偏移 + " ms";
            str += "\r\n";

            return str;
        }

        [DllImport("kernel32.dll")]
        private static extern bool SetLocalTime(ref SYSTEMTIME time);


        private bool 设置时间(double 时钟偏移)
        {
            SYSTEMTIME st;
            var trts = DateTime.Now.AddMilliseconds(时钟偏移);

            st.year = (short)trts.Year;
            st.month = (short)trts.Month;
            st.dayOfWeek = (short)trts.DayOfWeek;
            st.day = (short)trts.Day;
            st.hour = (short)trts.Hour;
            st.minute = (short)trts.Minute;
            st.second = (short)trts.Second;
            st.milliseconds = (short)trts.Millisecond;
            SetLocalTime(ref st);

            var 当前时间 = DateTime.Now;
            var 误差秒 = (trts - 当前时间).Duration().TotalSeconds;
            if (误差秒 > 1)
            {
                return false;
            }
            return true;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct SYSTEMTIME
        {
            public short year;
            public short month;
            public short dayOfWeek;
            public short day;
            public short hour;
            public short minute;
            public short second;
            public short milliseconds;
        }
    }


    // Leap indicator field values
    public enum _LeapIndicator
    {
        NoWarning, // 0 - No warning
        LastMinute61, // 1 - Last minute has 61 seconds
        LastMinute59, // 2 - Last minute has 59 seconds
        Alarm // 3 - Alarm condition (clock not synchronized)
    }

    //工作模式 field values
    public enum _工作模式
    {
        SymmetricActive, // 1 - 对称 活动
        SymmetricPassive, // 2 - 对称 被动
        Client, // 3 - 客户端
        Server, // 4 - 服务端
        Broadcast, // 5 - 广播
        Unknown // 0, 6, 7 - Reserved
    }

    // Stratum field values
    public enum _Stratum
    {
        Unspecified, // 0 - unspecified or unavailable
        PrimaryReference, // 1 - primary reference (e.g. radio-clock)
        SecondaryReference, // 2-15 - secondary reference (via NTP or SNTP)
        Reserved // 16-255 - reserved
    }

    public class 时间同步结果
    {
        public bool 同步成功 { get; set; } = false;

        public string 错误信息 { get; set; } = "";

        public TimeSpan 当前误差 { get; set; } = TimeSpan.Zero;

        public DateTime 上次同步 { get; set; } = DateTime.MinValue;

        public bool 设置成功 { get; set; } = true;

        public string 客户机 { get; set; } = "";

    }
}
