using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace NJT.Ext
{
    public static partial class 扩展
    {
        public static T 选择<T>(this IList<T> list, int k)
        {
            if (k < 0) return list.FirstOrDefault();
            if (list.Count > k) return list[k];
            return list.LastOrDefault();
        }

        public static T 移除<T>(this IList<T> list, T sel)
        {
            if (Equals(sel, null))
            {
                return default(T);
            }

            var k = list.IndexOf(sel);
            list.Remove(sel);
            return list.选择(k);
        }

        public static T 移除<T>(this IList<T> list, IList<T> sel)
        {
            var k = list.IndexOf(sel.FirstOrDefault());
            foreach (var item in sel)
            {
                list.Remove(item);
            }

            return list.选择(k);
        }


        public static bool 上移<T>(this IList<T> bindingList, int id, int 位数 = 1)
        {
            return bindingList.交换(id, id - 位数);
        }

        public static bool 下移<T>(this IList<T> bindingList, int id, int 位数 = 1)
        {
            return bindingList.交换(id, id + 位数);
        }


        public static bool 交换<T>(this IList<T> list, int 原id, int 新id)
        {
            if (原id >= list.Count || 新id >= list.Count || 原id < 0 || 新id < 0 || 原id == 新id)
            {
                return false;
            }

            try
            {
                var sel = list[原id];
                list[原id] = list[新id];
                list[新id] = sel;
                return true;
            }
            catch (Exception)
            {
                return false;
                ;
            }
        }


        public static IList<T> 随机选取<T>(this IList<T> r, int 数量)
        {
            if (r == null || r.Count == 0 || 数量 <= 0)
            {
                return new List<T>();
            }

            var l = new List<T>();
            var 最大值 = r.Count;
            var rd = new Random();
            while (数量 > 0)
            {
                var m = rd.Next(最大值);
                l.Add(r[m]);
                数量--;
            }

            return l;
        }

        public static void 洗牌<T>(this IList<T> r, int 次数)
        {
            if (r == null || r.Count == 0 || 次数 <= 0)
            {
                return;
            }

            var 最大值 = r.Count;
            var rd = new Random();
            while (次数 > 0)
            {
                r.交换(rd.Next(最大值), rd.Next(最大值));
                次数--;
            }
        }

        public static void To定长<T>(this List<T> r, int 长度)
        {
            if (r == null || r.Count == 0 || 长度 < 0)
            {
                return;
            }

            var 最大值 = r.Count;
            if (最大值 > 长度)
            {
                r.RemoveRange(长度, 最大值 - 长度);
            }
        }

        /// <summary>
        /// 调用add,如果超过最大长度,移除首位.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="item"></param>
        /// <param name="max"></param>
        public static void AddAndMax<T>(this IList<T> list, T item, int max = 100)
        {
            if (list.Count < max)
            {
                list.Add(item);
                return;
            }

            if (list.Count > 0)
            {
                list.RemoveAt(0);
            }

            list.Add(item);
        }


        /// <summary>
        /// 遍历列表并执行方法,返回列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="执行方法"></param>
        /// <returns></returns>
        public static IEnumerable<T> ForEachDo<T>(this IEnumerable<T> obj, Action<T> 执行方法)
        {
            foreach (var item in obj)
            {
                执行方法(item);
            }

            return obj;
        }


        /// <summary>
        /// 返回查找到的索引,找不到返回-1;
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static int IndexOf2<T>(this IEnumerable<T> source, Predicate<T> predicate)
        {
            int num = 0;
            foreach (T obj in source)
            {
                if (predicate(obj))
                    return num;
                ++num;
            }

            return -1;
        }



        /// <summary>
        /// 把数组分成几组,每组一样数量.如果源数据不够长,组内容可能为空.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="源"></param>
        /// <param name="组数"></param>
        /// <param name="每组数量"></param>
        /// <returns></returns>
        public static List<List<T>> 分组<T>(this IEnumerable<T> 源, int 组数, int 每组数量)
        {
            var list2 = Enumerable.Range(0, 组数)
                .Select(i => 源.Skip(每组数量 * i).Take(每组数量).ToList())
                .ToList();
            return list2;
        }


        /// <summary>
        /// 串联string
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="分隔符"></param>
        /// <returns></returns>
        public static string To串联(this IEnumerable<string> lt, string 分隔符 = "")
        {
            return string.Join(分隔符, lt);
        }

        public static bool Is空<T>(this IEnumerable<T> list)
        {
            if (list == null)
                return true;
            return !list.Any();
        }
    }
}