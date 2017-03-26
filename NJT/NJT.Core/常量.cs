using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Core
{
    public static class 常量
    {

        public static string 星期名称 => "星期日;星期一;星期二;星期三;星期四;星期五;星期六";

        public static string[] 星期名称list => 星期名称.Split(';');


        public static readonly TimeSpan S1秒 = new TimeSpan(0, 0, 1);
        public static readonly TimeSpan S5秒 = new TimeSpan(0, 0, 5);
        public static readonly TimeSpan S10秒 = new TimeSpan(0, 0, 10);
        public static readonly TimeSpan S30秒 = new TimeSpan(0, 0, 30);
        public static readonly TimeSpan M1分 = new TimeSpan(0, 1, 0);
        public static readonly TimeSpan M5分 = new TimeSpan(0, 5, 0);
        public static readonly TimeSpan M10分 = new TimeSpan(0, 10, 0);
        public static readonly TimeSpan M30分 = new TimeSpan(0, 30, 0);
        public static readonly TimeSpan H1小时 = new TimeSpan(1, 0, 0);
        public static readonly TimeSpan H2小时 = new TimeSpan(2, 0, 0);
        public static readonly TimeSpan H6小时 = new TimeSpan(6, 0, 0);
        public static readonly TimeSpan H12小时 = new TimeSpan(12, 0, 0);
        public static readonly TimeSpan H24小时 = new TimeSpan(24, 0, 0);
    }
}
