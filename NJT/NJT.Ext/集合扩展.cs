using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace NJT.Ext
{
    public static partial class 扩展方法
    {
        public static T 选择<T>(this IList<T> list, int k)
        {
            if (k < 0) return list.FirstOrDefault();
            if (list.Count > k) return list[k];
            return list.LastOrDefault();
        }

        public static T 移除<T>(this IList<T> list, T sel)
        {
            Debug.Assert(list != null, "列表不能为空");
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
            Debug.Assert(list != null, "列表不能为空");
            Debug.Assert(sel != null, "列表不能为空");
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
                return false; ;
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


        public static IList<T> GetList<T>(this Array obj)
        {
            if (obj == null)
                return new List<T>();
            var r2 = obj.Cast<T>().ToList();
            return r2;
        }
        public static void to定长<T>(this List<T> r, int 长度)
        {
            if (r == null || r.Count == 0 || 长度 <  0)
            {
                return;
            }
            var 最大值 = r.Count;
            if (最大值> 长度)
            {
                r.RemoveRange(长度,最大值-长度);
            }
          
        }

    }
}
