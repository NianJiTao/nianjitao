using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace NJT.Ext
{
    public static partial class 扩展方法
    {
        public static string To时分秒(this DateTime dt)
        {
            return dt.ToString("HH:mm:ss");
        }
        /// <summary>
        /// 用_分割,长度共19;
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string To年月日时分秒(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-ddTHH_mm_ss");
        }
        public static string To星期(this DateTime 时间)
        {
            return 时间.ToString("dddd");
        }

        public static TimeSpan To整秒(this TimeSpan 时间)
        {
            return 时间 - TimeSpan.FromMilliseconds(时间.Milliseconds);
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
        public static DateTime ToDateTime14(this string str)
        {
            try
            {
                var dt = DateTime.ParseExact(str, "yyyyMMddHHmmss", CultureInfo.CurrentCulture, DateTimeStyles.AllowWhiteSpaces);
                return dt;
                //return ToDateTime14_2(str);
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
        public static DateTime ToDateTime8(this string str)
        {
            try
            {
                var dt = DateTime.ParseExact(str, "yyyyMMdd", CultureInfo.CurrentCulture, DateTimeStyles.AllowWhiteSpaces);
                return dt;
            }
            catch (Exception)
            {
                return DateTime.MinValue;
            }
        }

       
        //private static DateTime ToDateTime14_2(this string str)
        //{
        //    if (str.Length != 14)
        //    {
        //        return DateTime.MinValue;
        //    }
        //    var y = str.Substring(0, 4).ToInt().范围限制(1, 9999);
        //    var MM = str.Substring(4, 2).ToInt().范围限制(1, 12);
        //    var dd = str.Substring(6, 2).ToInt().范围限制(1, 31);
        //    var h = str.Substring(8, 2).ToInt().范围限制(0, 23);
        //    var m = str.Substring(10, 2).ToInt().范围限制(0, 59);
        //    var s = str.Substring(12, 2).ToInt().范围限制(0, 59);
        //    return new DateTime(y, MM, dd, h, m, s);
        //}
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
            DateTime dt;
            var b = DateTime.TryParse(obj.ToString(), out dt);
            return b ? dt : DateTime.MinValue;
        }

     
    }
}
