﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace NJT.扩展
{
    public static partial class 扩展方法
    {
        public static List<T> To列表<T>() where T : struct
        {
            return Enum.GetValues(typeof(T))
                .Cast<T>()
                .OrderBy(x => x)
                .ToList();
        }
    }

}
