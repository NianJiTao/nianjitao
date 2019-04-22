using System;
using System.Collections.Generic;
using System.Linq;
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
            var list3 = list2.Where(x =>
                x.CanWrite
                && x.CustomAttributes.All(y => y.AttributeType.Name != "禁止克隆")
            ).ToList();


            var valList3 = valList2.ToList();
            foreach (var info in list3)
            {
                var propertyTypeName = info.PropertyType.Name;
                Func<object, object> 转换Func = null;
                switch (propertyTypeName)
                {
                    case "String":
                        转换Func = x => x.ToString2();
                        break;
                    case "Byte":
                        转换Func = x => (byte) x.ToString2().ToInt();
                        break;
                    case "Boolean":
                        转换Func = x => x.ToString2().ToBool();
                        break;
                    case "Int32":
                        转换Func = x => x.ToString2().ToInt();
                        break;
                    case "Int16":
                        转换Func = x => (short)x.ToString2().ToInt();
                        break;
                    case "Double":
                        转换Func = x => x.ToDouble2();
                        break;
                    case "Single":
                        转换Func = x => x.ToFloat2();
                        break;
                    case "DateTime":
                        转换Func = x => x.ToDateTime2();
                        break;
                }

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