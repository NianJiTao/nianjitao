using System;
using System.Collections.Generic;
using System.Linq;

namespace NJT.扩展
{
    public static class Enum扩展
    {
        public static List<T> To列表<T>() where T : struct
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToList();
        }
 
    }

    enum 测试枚举
    {
        真,
        假,
    }

    class 测试类
    {
        public 测试类()
        {
            var r = Enum扩展.To列表<测试枚举>();
        }
    }
}
