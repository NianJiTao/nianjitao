using System;
using System.Collections.Generic;
using System.Text;

namespace NJT.Ext
{
    public static partial class 扩展
    {
        /// <summary>
        /// 保证返回数据为范围内的数值.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="待测值">The 待测值.</param>
        /// <param name="最小">The 最小.</param>
        /// <param name="最大">The 最大.</param>
        /// <returns>T.</returns>
        public static T 范围限制<T>(this T 待测值, T 最小, T 最大) where T : IComparable<T>
        {
            var min = 待测值.CompareTo(最小) > 0 ? 待测值 : 最小;
            var max = min.CompareTo(最大) > 0 ? 最大 : min;
            return max;
        }
    }
}