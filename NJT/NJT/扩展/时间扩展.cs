using System;
using System.Collections.Generic;
using System.Linq;

namespace NJT.扩展
{
    public static partial class 扩展方法
    {
        public static string To时分秒(this DateTime dt)
        {
            return dt.ToString("HH:mm:ss");
        }

        public static string To年月日时分秒(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static string To文件名(this DateTime dt)
        {
            return dt.ToString("yyyy_MM_dd_HH_mm_ss");
        }

        public static TimeSpan To求和(this IEnumerable<TimeSpan> 时间列表)
        {
            return 时间列表.Aggregate(TimeSpan.Zero, (current, item) => current + item);
        }

        public static TimeSpan To整秒(this TimeSpan 时间)
        {
            return TimeSpan.FromSeconds((int)时间.TotalSeconds);
        }

        public static string To星期(this DateTime 时间)
        {
            return 时间.ToString("dddd");
        }

    }
}
