using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace NJT.Ext
{
    public static partial class 扩展
    {
        /// <summary>
        /// 如果是int  转为int,否则b.ToString2().ToInt();
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int ToInt2(this object obj)
        {
            return ToVal(obj, ToInt);
        }


        /// <summary>
        /// 如果是float 转为float,否则tostring,tofloat
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static float ToFloat2(this object obj)
        {
            return ToVal(obj, ToFloat);
        }


        /// <summary>
        /// 如果是double,直接返回,否则尝试转为double,
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static double ToDouble2(this object obj)
        {
            return ToVal(obj, ToDouble);
        }

        /// <summary>
        /// 对象如果是时间,直接返回,否则转字串,再尝试转时间.错误返回最小时间
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime ToDateTime2(this object obj)
        {
            return ToVal(obj, ToDateTime);
        }

        /// <summary>
        /// 返回对象的字符串表示,如果为空返回 string.Empty
        /// </summary>
        /// <param name="obj">The string.</param>
        /// <returns>System.String.</returns>
        public static string ToString2(this object obj)
        {
            return obj?.ToString() ?? string.Empty;
        }

        /// <summary>
        /// 如果是T类型,直接返回,否则转换后返回
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static T ToVal<T>(this object obj, Func<string, T> func)
        {
            if (obj is T val)
                return val;
            return func.Invoke(obj.ToString2());
        }
    }
}