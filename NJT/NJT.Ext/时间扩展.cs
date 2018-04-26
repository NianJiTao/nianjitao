using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using NJT.Core;

namespace NJT.Ext
{
    public static partial class 扩展方法
    {
        /// <summary>
        /// HH:mm:ss
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string To时分秒(this DateTime dt)
        {
            return dt.ToString("HH:mm:ss");
        }

        /// <summary>
        ///  长度共19; yyyy-MM-ddTHH_mm_ss
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string To年月日时分秒(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-ddTHH_mm_ss");
        }

        /// <summary>
        /// dddd
        /// </summary>
        /// <param name="时间"></param>
        /// <returns></returns>
        public static string To星期(this DateTime 时间)
        {
            return 时间.ToString("dddd");
        }

        /// <summary>
        /// 去掉秒数小数点后面.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static TimeSpan To整秒(this TimeSpan obj)
        {
            return TimeSpan.FromSeconds((int) obj.TotalSeconds);
        }

        /// <summary>
        /// 去掉秒数小数点后面.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime To整秒(this DateTime obj)
        {
            return new DateTime(obj.Year, obj.Month, obj.Day, obj.Hour, obj.Minute, obj.Second);
        }


        /// <summary>
        /// 整数秒转换到时间.
        /// </summary>
        /// <param name="ss">The string.</param>
        /// <returns>TimeSpan.</returns>
        public static TimeSpan ToTimeSpan(this int ss)
        {
            return new TimeSpan(0, 0, 0, ss);
        }

        /// <summary>
        /// yyyyMMddHHmmss 格式可转换.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>TimeSpan.</returns>
        public static DateTime GetDateTime14(this string str)
        {
            try
            {
                var dt = str.GetDateTime("yyyyMMddHHmmss");
                return dt;
            }
            catch (Exception)
            {
                return DateTime.MinValue;
            }
        }

        /// <summary>
        /// yyyyMMdd 格式可转换.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime GetDateTime8(this string str)
        {
            try
            {
                var dt = str.GetDateTime("yyyyMMdd");
                return dt;
            }
            catch (Exception)
            {
                return DateTime.MinValue;
            }
        }

        public static DateTime GetDateTime(this string 字符串, string 日期格式)
        {
            var r = DateTime.ParseExact(字符串, 日期格式, CultureInfo.CurrentCulture, DateTimeStyles.AllowWhiteSpaces);
            return r;
        }

        /// <summary>
        /// 对象转换成时间. UTC时间,本地时间需加.ToLocalTime()
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// 
        public static DateTime GetDateTime(this object obj)
        {
            if (obj == null)
                return DateTime.MinValue;
            var b = DateTime.TryParse(obj.ToString(), out DateTime dt);
            return b ? dt : DateTime.MinValue;
        }

        private static readonly Lazy<日期顺序号> Lazy日期顺序号 =new Lazy<日期顺序号>();

        /// <summary>
        /// 返回当前日期的顺序号,递增1
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int Get顺序号(this DateTime obj)
        {
            return Lazy日期顺序号.Value.Get记录号(obj);
        }
    }
}