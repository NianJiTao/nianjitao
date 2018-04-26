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


        public static T 反射克隆值<T>(this T 目标, T 源, IList<string> 排除属性名 = null)
        {
            if (源 == null || 目标 == null)
                return 目标;
            var listProp = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(x => x.CanRead && x.CanWrite).ToList();
            var is排除 = 排除属性名 != null && 排除属性名.Any();
            var listProp2 = is排除 ? listProp.Where(x => !排除属性名.Contains(x.Name)).ToList() : listProp;
            //var pname = listProp2.Select(x => x.Name).ToList();
            foreach (var p in listProp2)
                p.SetValue(目标, p.GetValue(源));
            return 目标;
        }
    }
}
