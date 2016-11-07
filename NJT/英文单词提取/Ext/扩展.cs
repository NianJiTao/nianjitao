using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 英文单词提取
{
    public static class 扩展
    {

        public static string NameNavigation(this Type type)
        {
            return type.Name.EndsWith("Page")
            ? type.Name.Remove(type.Name.Length - 4)
            : type.Name;
        }

    }
}
