using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace NJT.Core
{
    public static partial class Core扩展
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


        /// <summary>
        /// 验证数组长度是否符合最低要求. start + len 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="数组"></param>
        /// <param name="start"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static bool 长度合格<T>(this IList<T> 数组, int start, int len)
        {
            return 数组 != null && 数组.Count >= start + len && start >= 0;
        }


        public static ushort GetUInt16(this byte[] 字节组, int start)
        {
            return 字节组.长度合格(start, 2) ? BitConverter.ToUInt16(字节组, start) : (ushort) 0;
        }


        public static uint GetUInt32(this byte[] 字节组, int start)
        {
            return 字节组.长度合格(start, 4) ? BitConverter.ToUInt32(字节组, start) : 0;
        }


        public static float GetFloat(this byte[] 字节组, int start)
        {
            return 字节组.长度合格(start, 4) ? BitConverter.ToSingle(字节组, start) : 0;
        }


        public static double GetDouble(this byte[] 字节组, int start)
        {
            return 字节组.长度合格(start, 8) ? BitConverter.ToDouble(字节组, start) : 0;
        }
        /// <summary>
        /// 把数组按指定长度分解开.
        /// 如[1~9]按{1,2,4,1}可分解为锯齿数组.
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="长度组"></param>
        /// <returns></returns>
        public static T[][] 分解<T>(this IList<T> bytes, IList<int> 长度组)
        {
            var m = 0;
            var r = new T[长度组.Count][];
            for (var i = 0; i < r.Length; i++)
            {
                r[i] = bytes.Skip(m).Take(长度组[i]).ToArray();
                m += 长度组[i];
            }

            return r;
        }


        /// <summary>
        /// 把只读列表的值按顺序赋给 目标
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="目标"></param>
        /// <param name="新值列表"></param>
        /// <returns></returns>
        public static IEnumerable<T1> 赋值<T1, T2>(this IEnumerable<T1> 目标, IReadOnlyList<T2> 新值列表) where T1 : class, I名称值
        {
            var index = 0;
            // ReSharper disable once PossibleMultipleEnumeration
            foreach (var 名称值 in 目标)
            {
                if (新值列表.Count > index) 名称值.值 = 新值列表[index];
                index++;
            }

            // ReSharper disable once PossibleMultipleEnumeration
            return 目标;
        }

    }
}