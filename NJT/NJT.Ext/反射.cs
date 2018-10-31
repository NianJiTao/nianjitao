using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NJT.Core;
using NJT.Ext.Core;

namespace NJT.Ext
{
    public static partial class 反射
    {
        public static T GetNew<T>(IEnumerable<I名称值> obj, string[] 排除属性) where T : class, new()
        {
            if (obj == null)
                return null;
            var r = new T();
            赋值(r, 排除属性, obj);
            return r;
        }

        /// <summary>
        /// 把list内的值按名称赋值给对象的属性.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="排除属性"></param>
        /// <param name="valList2"></param>
        public static void 赋值(object obj, string[] 排除属性, IEnumerable<I名称值> valList2)
        {
            if (obj == null)
                return;
            if (valList2 == null)
                return;
            var list2 = obj.GetPropertiesList(排除属性);
            var list3 = list2.Where(x => x.CanWrite).ToList();
            var valList3 = valList2.ToList();
            foreach (var info in list3)
            {
                var propertyTypeName = info.PropertyType.Name;
                Func<object, object> 转换Func = null;

                if (propertyTypeName == typeof(string).Name)
                    转换Func = x => x.ToString2();
                else if (propertyTypeName == typeof(int).Name)
                    转换Func = x => x.ToString2().ToInt();
                else if (propertyTypeName == typeof(double).Name)
                    转换Func = x => x.ToDouble2();
                else if (propertyTypeName == typeof(DateTime).Name)
                    转换Func = x => x.ToDateTime2();

                var val3 = valList3.FindItem(info.Name);
                if (val3 != null && 转换Func != null)
                {
                    var val4 = 转换Func.Invoke(val3.值);
                    info.SetValue(obj, val4);
                }
            }
        }
    }
}