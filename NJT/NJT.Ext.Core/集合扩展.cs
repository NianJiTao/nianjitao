﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace NJT.Ext.Core
{
    public static partial class 扩展
    {
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

         

        public static T 选择<T>(this IList<T> list, int k)
        {
            if (list == null)
            {
                return default(T);
            }

            if (k < 0) return list.FirstOrDefault();
            k = k.范围限制(0, list.Count - 1);
            return list[k];
        }


        /// <summary>
        /// 移除后,返回原有序号位的对象.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="sel"></param>
        /// <returns></returns>
        public static T 移除<T>(this List<T> list, T sel)
        {
            if (Equals(sel, null) || list == null)
            {
                return default(T);
            }

            var k = list.IndexOf(sel);
            list.Remove(sel);
            return list.选择(k);
        }


        public static T 移除<T>(this List<T> list, IList<T> sel)
        {
            if (Equals(sel, null) || list == null)
            {
                return default(T);
            }

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
            if (list == null)
            {
                return false;
            }

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


        public static List<T> To定长<T>(this List<T> r, int 长度)
        {
            if (r.Is空() || 长度 < 0)
            {
                return r;
            }

            var 最大值 = r.Count;
            if (最大值 > 长度)
            {
                r.RemoveRange(长度, 最大值 - 长度);
            }

            return r;
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
            if (list == null)
                return;
            list.Add(item);
            while (list.Count > 0 && list.Count > max)
            {
                list.RemoveAt(0);
            }
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
            if (obj == null) return obj;
            if (执行方法 == null) return obj;

            foreach (var item in obj) 执行方法.Invoke(item);

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
            if (source == null || predicate == null)
                return -1;

            var num = 0;
            foreach (var obj in source)
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
            if (源 == null)
            {
                return new List<List<T>>();
            }

            组数 = 组数.范围限制(1, short.MaxValue);
            每组数量 = 每组数量.范围限制(1, short.MaxValue);
            var list2 = Enumerable.Range(0, 组数)
                .Select(i => 源.Skip(每组数量 * i).Take(每组数量).ToList())
                .ToList();
            return list2;
        }


        public static List<List<T>> 分组<T>(this IEnumerable<T> 源, int 每组数量)
        {
            if (源.Is空())
            {
                return new List<List<T>>();
            }

            var r = new List<List<T>>();
            if (每组数量 <= 1)
            {
                r.Add(源.ToList());
                return r;
            }

            int skip = 0;
            while (skip < 源.Count())
            {
                r.Add(源.Skip(skip).Take(每组数量).ToList());
                skip = skip + 每组数量;
            }

            return r;
        }


        /// <summary>
        /// 串联string
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="分隔符"></param>
        /// <returns></returns>
        public static string To串联(this IEnumerable<string> lt, string 分隔符 = "")
        {
            if (lt == null)
                return string.Empty;

            if (string.IsNullOrEmpty(分隔符))
                分隔符 = string.Empty;

            return string.Join(分隔符, lt);
        }


        public static bool Is空<T>(this IEnumerable<T> list)
        {
            return (list == null) || !list.Any();
        }


        public static void 更新列表<T>(this ICollection<T> obj, IEnumerable<T> list2)
        {
            if (obj == null)
                return;
            obj.Clear();
            if (list2.Is空())
                return;
            foreach (var item in list2)
                obj.Add(item);
        }
    }
}