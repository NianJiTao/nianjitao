using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Core
{
    public static class 星期转换
    {
        //System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek) 

        /// <summary>
        ///     The 星期显示组 如 1, "星期一", DayOfWeek.Monday,false
        /// </summary>
        public static readonly IList<I星期信息> 星期显示组 =
            new List<I星期信息> 
            {
                new 星期信息1(0, "星期日", DayOfWeek.Sunday, false),
                new 星期信息1(1, "星期一", DayOfWeek.Monday, false),
                new 星期信息1(2, "星期二", DayOfWeek.Tuesday, false),
                new 星期信息1(3, "星期三", DayOfWeek.Wednesday, false),
                new 星期信息1(4, "星期四", DayOfWeek.Thursday, false),
                new 星期信息1(5, "星期五", DayOfWeek.Friday, false),
                new 星期信息1(6, "星期六", DayOfWeek.Saturday, false),
            };

       

        /// <summary>
        ///     如 1 转换为 "星期一"
        /// </summary>
        /// <param name="k">The k.</param>
        /// <returns>System.String.</returns>
        public static string ToWeek中文(int k)
        {
            if (k<-65000 || k>65000)
            {
                return 星期显示组[0].中文;
            }
            var k2 = (Math.Abs( k) + 7) % 7;
            return 星期显示组[k2].中文;
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


        ///// <summary>
        ///// 如今天为周三,k=4,返回明天日期,k=2 返回下周二日期.k=3,返回今天日期
        ///// </summary>
        ///// <param name="k">The k.</param>
        ///// <returns>DateTime.</returns>
        //public static DateTime To日期(int k)
        //{
        //    var k2 = (int)(DateTime.Today.DayOfWeek);
        //    var d = (k + 7 - k2) % 7;
        //    return DateTime.Today.AddDays(d);
        //}

        //public static string ToWeek中文(DayOfWeek k)
        //{
        //    return 星期显示组[(int)k].中文;
        //    //return System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(k);
        //}

    }
}
