using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Common
{
    public class 星期泛型<T> : 星期信息
    {
        public T 数据 { get; set; }
    }



    public class 星期信息
    {

        public 星期信息()
        {

        }
        public 星期信息(int 数字cs, string 中文cs, DayOfWeek 英文cs, bool 选中cs)
        {
            数字 = 数字cs;
            中文 = 中文cs;
            英文 = 英文cs;
            选中 = 选中cs;
        }

        public int 数字 { get; set; }

        public string 中文 { get; set; }

        public DayOfWeek 英文 { get; set; }

        public bool 选中 { get; set; }

    }

    public static class 星期转换
    {
        //System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek) 

        /// <summary>
        ///     The 星期显示组 如 1, "星期一", DayOfWeek.Monday,false
        /// </summary>
        public static HashSet<星期信息> 星期显示组 =
            new HashSet<星期信息>
            {
                new 星期信息(1, "星期一", DayOfWeek.Monday, false),
                new 星期信息(2, "星期二", DayOfWeek.Tuesday, false),
                new 星期信息(3, "星期三", DayOfWeek.Wednesday, false),
                new 星期信息(4, "星期四", DayOfWeek.Thursday, false),
                new 星期信息(5, "星期五", DayOfWeek.Friday, false),
                new 星期信息(6, "星期六", DayOfWeek.Saturday, false),
                new 星期信息(0, "星期日", DayOfWeek.Sunday, false),

            };

        public static HashSet<Tuple<int, string>> 星期快捷数组 =
            new HashSet<Tuple<int, string>>
            {
                new Tuple<int, string>(0, "今天"),
                new Tuple<int, string>(1, "明天")
            };

        /// <summary>
        ///     如 1 转换为 "星期一"
        /// </summary>
        /// <param name="k">The k.</param>
        /// <returns>System.String.</returns>
        public static string ToWeek中文(int k)
        {
            var k2 = (Math.Abs(k) + 7) % 7;
            return 星期显示组.First(x => x.数字 == k2).中文;
        }
        public static string ToWeek中文(DayOfWeek k)
        {
            return System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(k);
        }
        /// <summary>
        ///     日期转为 "星期一"
        /// </summary>
        /// <param name="日期">The 日期.</param>
        /// <returns>System.String.</returns>
        public static string ToWeek中文(DateTime 日期)
        {
            var week = 日期.DayOfWeek;
            return 星期显示组.First(x => x.英文 == week).中文;
        }

        /// <summary>
        ///     如 "星期一" 转换为 1
        /// </summary>
        /// <param name="k">The k.</param>
        /// <returns>System.Int32.</returns>
        public static int ToWeekInt(string k)
        {
            var r = 星期显示组.FirstOrDefault(x => x.中文 == k);
            return r?.数字 ?? 1;
        }

        /// <summary>
        ///     DayOfWeek.Monday 转为1
        /// </summary>
        /// <param name="日期">The 日期.</param>
        /// <returns>System.Int32.</returns>
        public static int ToWeekInt(DateTime 日期)
        {
            var week = 日期.DayOfWeek;
            return 星期显示组.First(x => x.英文 == week).数字;
        }

        /// <summary>
        ///     返回日期和今天的差值. 今天为0;明天为1
        /// </summary>
        /// <param name="日期">The 日期.</param>
        /// <returns>System.Int32.</returns>
        public static int ToInt差(DateTime 日期)
        {
            return (日期 - DateTime.Today).Days;
        }

        /// <summary>
        /// 如今天为周三,k=4,返回明天日期,k=2 返回下周二日期.k=3,返回今天日期
        /// </summary>
        /// <param name="k">The k.</param>
        /// <returns>DateTime.</returns>
        public static DateTime To日期(int k)
        {
            var k2 = ToWeekInt(DateTime.Today);
            var d = (k + 7 - k2) % 7;
            return DateTime.Today.AddDays(d);
        }

        /// <summary>
        ///     DayOfWeek.Monday 转为1
        /// </summary>
        /// <param name="week">The week.</param>
        /// <returns>System.Int32.</returns>
        public static int ToWeekInt(DayOfWeek week)
        {
            return 星期显示组.First(x => x.英文 == week).数字;
        }

    }
}
