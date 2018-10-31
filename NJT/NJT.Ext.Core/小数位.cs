using System;
using System.Collections.Generic;
using System.Text;

namespace NJT.Ext.Core
{
    public static partial class 扩展
    {
        /// <summary>
        /// 小数位3位后四舍五入
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static double 小数位(this double obj, int len = 3)
        {
            return Math.Round(obj, len.范围限制(0, 15));
        }

        /// <summary>
        /// 小数位3位后四舍五入
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static float 小数位(this float obj, int len = 3)
        {
            return (float)Math.Round(obj, len.范围限制(0, 15));
        }

        /// <summary>
        /// 小数位3位后四舍五入
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static decimal 小数位(this decimal obj, int len = 3)
        {
            return Math.Round(obj, len.范围限制(0, 15));
        }

        /// <summary>
        /// 0~1转为0-100,四舍五入;
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int ToProgressVal(this double obj)
        {
            return Convert.ToInt32((Math.Round(obj.范围限制(0, 1), 2) * 100));
        }

        /// <summary>
        /// 0~1转为0-100,四舍五入;
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int ToProgressVal(this float obj)
        {
            return Convert.ToInt32((Math.Round(obj.范围限制(0, 1), 2) * 100));
        }
    }
}
