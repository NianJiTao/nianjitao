using System.Collections.Generic;
using System.Linq;

namespace NJT.扩展
{


    public static partial class 扩展方法
    {

        /// <summary>
        /// 序列为空,返回true
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool Is空<T>(this IEnumerable<T> list)
        {
            return list == null || !list.Any();
        }



    }
}
