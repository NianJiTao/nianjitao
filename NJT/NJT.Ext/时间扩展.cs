using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using NJT.Core;

namespace NJT.Ext
{
    public static partial class 扩展
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


        private static readonly Lazy<日期顺序号> Lazy日期顺序号 = new Lazy<日期顺序号>();

        /// <summary>
        /// 返回当前日期的顺序号,递增1
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int Get顺序号(this DateTime obj)
        {
            return Lazy日期顺序号.Value.Get记录号(obj);
        }


        public static TimeSpan To求和(this IEnumerable<TimeSpan> 时间列表)
        {
            if (时间列表 == null)
                return TimeSpan.Zero;
            return 时间列表.Aggregate(TimeSpan.Zero, (current, item) => current + item);
        }

        public static TimeSpan Get时间差(this DateTime? 开始, DateTime? 结束)
        {
            if (开始 == null || 结束 == null || 结束 < 开始)
                return TimeSpan.Zero;

            var r = ((DateTime)结束 - (DateTime)开始);
            return r;
        }
    }
}