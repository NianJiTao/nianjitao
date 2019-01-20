using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Input;

namespace NJT.Ext
{
    public static partial class 扩展
    {
        public static IList<object> Get静态属性(this Type typex)
        {
            if (typex == null)
                return new List<object>();
            var r = typex.GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Select(x => x.GetValue(null)).ToList();
            return r;
        }

        public static IList<object> Get静态字段(this Type typex)
        {
            if (typex == null)
                return new List<object>();
            var r = typex.GetFields(BindingFlags.Public | BindingFlags.Static)
                .Select(x => x.GetValue(null)).ToList();
            return r;
        }


        /// <summary>
        /// 可给接口或者类型的属性赋值.
        /// 如果属性的特性有"禁止克隆"将跳过此属性
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
                .Where(x => x.CanRead && x.CanWrite)
                .ToList();
            var 全部属性List = 实例属性List.Concat(接口属性List).ToList();

            var is排除 = 排除属性名 != null && 排除属性名.Any();
            var list1 = is排除 ? 全部属性List.Where(x => !排除属性名.Contains(x.Name)).ToList() : 全部属性List;

            var list2 = list1
                .Where(x => x.CustomAttributes.All(y => y.AttributeType.Name != "禁止克隆"))
                .ToList();

            foreach (var p in list2)
            {
                try
                {
                    p.SetValue(目标, p.GetValue(源));
                }
                catch
                {
                    // ignored
                }
            }

            return 目标;
        }


        /// <summary>
        /// 从对象里面反射获取命令属性
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static List<PropertyInfo> GetCommandList(this object obj)
        {
            if (obj == null) return new List<PropertyInfo>();
            var r = obj.GetType().GetProperties().ToList();
            var r2 = r.Where(x => x.CanRead && (typeof(ICommand).IsAssignableFrom(x.PropertyType))).ToList();
            return r2;
        }

        /// <summary>
        /// 返回 命令名称,值,列表
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static List<Tuple<string, object>> GetCommandValueList(this object obj)
        {
            return obj.GetCommandList().Select(x => new Tuple<string, object>(x.Name, x.GetValue(obj))).ToList();
        }


        /// <summary>
        /// 从对象里面反射获取属性,并去除排除属性
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static List<PropertyInfo> GetPropertiesList(this object obj, params string[] 排除)
        {
            if (obj == null) return new List<PropertyInfo>();
            var r = obj.GetType().GetProperties().ToList();
            var r2 = r.Where(x => x.CanRead && !排除.Contains(x.Name)).ToList();
            return r2;
        }
    }
}
