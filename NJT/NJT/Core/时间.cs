using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace NJT.Common
{
    public static class 时间
    {
        public static List<DispatcherTimer> 定时列表 = new List<DispatcherTimer>();

        public static void 刷新当前时间(Action<string> 显示时间, TimeSpan 刷新间隔, string 时间格式)
        {
            var 时间计时器 = new DispatcherTimer { Interval = 刷新间隔 };
            时间计时器.Tick += (o, e) => 显示时间(DateTime.Now.ToString(时间格式));
            时间计时器.Start();
        }


        public static void 延时启动(int 延时毫秒, Action 启动方法)
        {
            var time延时 = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 0, 延时毫秒) };
            time延时.Tick += (o, e) =>
            {
                time延时.Stop();
                启动方法();
            };
            time延时.Start();
        }

        public static void 循环(int 间隔毫秒, Action 启动方法)
        {

            var timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(间隔毫秒)
            };
            定时列表.Add(timer);
            timer.Tick += (o, e) => { 启动方法(); };
            timer.Start();
        }
        public static void 关闭所有()
        {
            foreach (var x in 定时列表)
            {
                x.Stop();
            }
            定时列表.Clear();
        }



        public static string 更改时间(DateTime 新时间)
        {
            try
            {
                设置2(新时间);
                return string.Empty;
            }
            catch (Exception ee)
            {
                return ee.Message;
            }
        }

        private static void 设置2(DateTime 新时间)
        {
            var sysTime = new SystemTime();

            sysTime.wYear = Convert.ToUInt16(新时间.Year);
            sysTime.wMonth = Convert.ToUInt16(新时间.Month);

            var n北京时间 = 新时间.Hour - 8;
            if (n北京时间 < 0)
            {
                n北京时间 += 24;
                n北京时间 %= 24;

                sysTime.wDay = Convert.ToUInt16(新时间.Day - 1);
                var w星期 = ((int)新时间.DayOfWeek - 1 + 7) % 7;
                sysTime.wDayOfWeek = Convert.ToUInt16(w星期);
            }
            else
            {
                sysTime.wDay = Convert.ToUInt16(新时间.Day);
                sysTime.wDayOfWeek = Convert.ToUInt16(新时间.DayOfWeek);
            }
            sysTime.wHour = Convert.ToUInt16(n北京时间);
            sysTime.wMinute = Convert.ToUInt16(新时间.Minute);
            sysTime.wSecond = Convert.ToUInt16(新时间.Second);
            sysTime.wMiliseconds = Convert.ToUInt16(新时间.Millisecond + 1);

            UnsafeNativeMethods.设置系统时间(ref sysTime);
        }
    }



    [StructLayout(LayoutKind.Sequential)]
    public struct SystemTime
    {
        public ushort wYear;
        public ushort wMonth;
        public ushort wDayOfWeek;
        public ushort wDay;
        public ushort wHour;
        public ushort wMinute;
        public ushort wSecond;
        public ushort wMiliseconds;
    }

    public static class UnsafeNativeMethods
    {
        public static bool 设置系统时间(ref SystemTime sysTime)
        {
            return SetSystemTime(ref sysTime);
        }


        [DllImport("Kernel32.dll")]
        static extern bool SetSystemTime(ref SystemTime sysTime);

    }
}
