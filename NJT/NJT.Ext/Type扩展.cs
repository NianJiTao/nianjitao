using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Ext
{
    public static partial class 扩展方法
    {

        public static IList<object> Get静态属性(this Type typex)
        {
            var r = typex.GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Select(x => x.GetValue(null)).ToList();
            return r;
        }

        public static IList<object> Get静态字段(this Type typex)
        {
            var r = typex.GetFields(BindingFlags.Public | BindingFlags.Static)
                .Select(x => x.GetValue(null)).ToList();
            return r;
        }
    }
}
