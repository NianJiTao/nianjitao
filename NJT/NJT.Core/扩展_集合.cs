using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace NJT.Core
{
    public static partial class 扩展
    {
        public static ObservableCollection<T> ToObservabler<T>(this IEnumerable<T> list2)
        {
            var r = new ObservableCollection<T>();
            if (list2 != null)
                foreach (var k in list2)
                    r.Add(k);

            return r;
        }

        /// <summary>
        /// 如果true,返回data的列表,否则返回空列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static ObservableCollection<T> ToObservabler<T>(this I运行结果<IList<T>> obj)
        {
            return obj.IsTrue ? obj.Data.ToObservabler() : new ObservableCollection<T>();
        }

        public static ObservableCollection<T> ToObservabler<T>(this I运行结果<IEnumerable<T>> obj)
        {
            return obj.IsTrue ? obj.Data.ToObservabler() : new ObservableCollection<T>();
        }


        public static T FindItem<T>(this IEnumerable<T> 列表, string 名称) where T : I名称
        {
            if (string.IsNullOrEmpty(名称))
            {
                return default(T);
            }

            var find = 列表.FirstOrDefault(x => string.Equals(x.名称, 名称, StringComparison.CurrentCultureIgnoreCase));
            return find;
        }

        public static T FindItem<T>(this IEnumerable<T> 列表, string 名称, int skip) where T : I名称
        {
            if (string.IsNullOrEmpty(名称))
                return default(T);

            var find = 列表.Where(x => string.Equals(x.名称, 名称, StringComparison.CurrentCultureIgnoreCase))
                .Skip(skip)
                .FirstOrDefault();
            return find;
        }

        public static object FindValue<T>(this IEnumerable<T> 列表, string 名称) where T : I名称值
        {
            var find = 列表.FindItem(名称);
            return find?.值;
        }

        /// <summary>
        /// 查找属性名称并更新值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="字段表"></param>
        /// <param name="属性名"></param>
        /// <param name="属性值"></param>
        public static IEnumerable<T> UpValue<T>(this IEnumerable<T> 字段表, string 属性名, object 属性值) where T : I名称值
        {
            var find = 字段表.FindItem(属性名);
            if (find != null)
                find.值 = 属性值;
            return 字段表;
        }

         
    }
}