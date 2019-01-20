using System;
using System.Collections.Generic;
using System.Linq;

namespace NJT.Ext
{
    public static partial class 扩展
    {
        public static T NotNullDo<T>(this T 目标, Action<T> act)
        {
            if (目标 != null)
                act?.Invoke(目标);
            return 目标;
        }

        /// <summary>
        /// 转换为 List 泛型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static IList<T> GetList<T>(this Array obj)
        {
            if (obj == null)
                return new List<T>();
            var r2 = obj.Cast<T>().ToList();
            return r2;
        }


        /// <summary>
        /// 如果条件符合,则执行方法 , 如果过滤方法为空,将直接执行方法.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="执行方法"></param>
        /// <param name="过滤方法"></param>
        /// <returns></returns>
        public static T IfDo<T>(this T obj, Func<T, T> 执行方法, Func<T, bool> 过滤方法)
        {
            if (执行方法 == null)
                return obj;
            if (null == 过滤方法)
                return 执行方法.Invoke(obj);

            if (过滤方法.Invoke(obj))
                return 执行方法.Invoke(obj);

            return obj;
        }
    }
}
