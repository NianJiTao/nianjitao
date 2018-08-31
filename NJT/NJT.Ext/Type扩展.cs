using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Ext
{
    public static partial class 扩展 
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


        /// <summary>
        /// 可给接口或者类型的属性赋值.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="目标"></param>
        /// <param name="源"></param>
        /// <param name="排除属性名"></param>
        /// <returns></returns>
        public static T 反射克隆值<T>(this T 目标, T 源, IList<string> 排除属性名 = null) where T : class
        {
            if (源 == null || 目标 == null)
                return 目标;

            var 接口属性List = typeof(T).GetInterfaces()
                .SelectMany(x => x.GetProperties(BindingFlags.Instance | BindingFlags.Public))
                .Where(x => x.CanRead && x.CanWrite);

            var 实例属性List = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(x => x.CanRead && x.CanWrite).Concat(接口属性List).ToList();

            var is排除 = 排除属性名 != null && 排除属性名.Any();
            var 过滤后List = is排除 ? 实例属性List.Where(x => !排除属性名.Contains(x.Name)).ToList() : 实例属性List;

            foreach (var p in 过滤后List)
                p.SetValue(目标, p.GetValue(源));

            return 目标;
        }
    }
}