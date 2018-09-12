using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NJT.Core;

namespace NJT.Ext
{
    public static partial class 反射
    {
        public static T GetNew<T>(IEnumerable<I名称值> obj, string[] 排除属性) where T : class, new()
        {
            if (obj == null)
                return null;
            var r = new T();
            反射.赋值(r, 排除属性, obj);
            return r;
        }

        /// <summary>
        /// 把list内的值按名称赋值给对象的属性.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="排除属性"></param>
        /// <param name="listVal"></param>
        public static void 赋值(object obj, string[] 排除属性, IEnumerable<I名称值> listVal)
        {
            if (obj == null)
                return;
            if (listVal == null)
                return;
            var list2 = obj.GetPropertiesList(排除属性);
            var list = listVal.ToList();
            foreach (var info in list2)
            {
                var t = info.PropertyType.Name;
                if (t == typeof(string).Name)
                {
                    var val = list.FindValue(info.Name).ToString2();
                    info.SetValue(obj, val);
                }
                else if (t == typeof(int).Name)
                {
                    var val = list.FindValue(info.Name).ToInt();
                    info.SetValue(obj, val);
                }
                else if (t == typeof(double).Name)
                {
                    var val = list.FindValue(info.Name).ToDouble2();
                    info.SetValue(obj, val);
                }
            }
        }
    }
}
