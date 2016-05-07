using System;

namespace NJT.扩展
{
    public static partial class 扩展方法
    {


        /// <summary>
        /// 保证返回数据为范围内的数值.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="待测值">The 待测值.</param>
        /// <param name="最小">The 最小.</param>
        /// <param name="最大">The 最大.</param>
        /// <returns>T.</returns>
        //public static T 范围限制<T>(T 待测值, T 最小, T 最大) where T : IComparable
        //{
        //    var 大 = (待测值.CompareTo(最小) > 0) ? 待测值 : 最小;
        //    var 小 = (大.CompareTo(最大) > 0) ? 最大 : 大;
        //    return 小;
        //}


        public static T 范围限制<T>(this T 待测值, T 最小, T 最大) where T : IComparable<T>
        {
            var min = 待测值.CompareTo(最小) > 0 ? 待测值 : 最小;
            var max = min.CompareTo(最大) > 0 ? 最大 : min;
            return max;

        }



        /// <summary>
        /// 大于最大,返回最大,   
        /// 小于最小,返回最小.
        /// </summary>
        /// <param name="待测值">The 准备检测的数值.</param>
        /// <param name="最小">The 最小.</param>
        /// <param name="最大">The 最大.</param>
        /// <returns>System.Int32.</returns>
        public static int 范围限制(this int 待测值, int 最小, int 最大)
        {
            return Math.Min(最大, Math.Max(待测值, 最小));
        }


        /// <summary>
        /// 大于最大,返回最大,   
        /// 小于最小,返回最小.
        /// </summary>
        /// <param name="待测值">The 准备检测的数值.</param>
        /// <param name="最小">The 最小.</param>
        /// <param name="最大">The 最大.</param>
        /// <returns>System.Int32.</returns>
        public static double 范围限制(this double 待测值, double 最小, double 最大)
        {
            return Math.Min(最大, Math.Max(待测值, 最小));
        }


    }
}
