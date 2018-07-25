using System.Collections.Generic;
using System.Linq;

namespace NJT.Ext
{
    public static partial class 扩展方法
    {
        public static bool Is空<T>(this IEnumerable<T> list)
        {
            if (list == null)
                return true;
            return !list.Any();
        }
    }
}