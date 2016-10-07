using System;
using System.Collections.Generic;
using System.Linq;

namespace NJT.Ext
{
    public static partial class 扩展方法
    {
        public static string To时分秒(this DateTime dt)
        {
            return dt.ToString("HH:mm:ss");
        }
        public static string To星期(this DateTime 时间)
        {
            return 时间.ToString("dddd");
        }

        public static TimeSpan To整秒(this TimeSpan 时间)
        {
            return 时间 - TimeSpan.FromMilliseconds(时间.Milliseconds);
        }


    }
}
