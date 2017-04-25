using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Ext
{
    public static partial class 扩展方法
    {

        /// <summary>
        /// 小数位3位后四舍五入
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static double 小数位(this double obj, int len = 3)
        {
            return Math.Round(obj, len);
        }

        /// <summary>
        /// 小数位3位后四舍五入
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static float 小数位(this float obj, int len = 3)
        {
            return (float)Math.Round(obj, len);
        }

        /// <summary>
        /// 小数位3位后四舍五入
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static decimal 小数位(this decimal obj, int len = 3)
        {
            return (decimal)Math.Round(obj, len);
        }
    }
}
