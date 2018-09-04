using System;
using System.Collections.Generic;
using System.Linq;

namespace NJT.Ext
{
    public static partial class 扩展 
    {
        private static object 更新字典标识 = "更新字典标识";

        /// <summary>
        /// 向字典添加新值,如果存在就更新值
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void 更新<TKey, TValue>(this IDictionary<TKey, TValue> obj, TKey key, TValue value)
        {
            if (obj==null || key == null)
            {
                return;
            }
           
            lock (更新字典标识)
            {
                if (obj.ContainsKey(key))
                {
                    obj[key] = value;
                }
                else
                {
                    obj.Add(key, value);
                }
            }
        }
    }
}