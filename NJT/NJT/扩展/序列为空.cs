﻿using System.Collections.Generic;
using System.Linq;

namespace NJT.扩展
{


    public static partial class 扩展方法
    {

        public static bool Is空<T>(this IEnumerable<T> list)
        {
            return !list.Any();
        }

    }
}
