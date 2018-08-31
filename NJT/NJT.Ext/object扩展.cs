using System;
using System.Collections.Generic;
using System.Linq;

namespace NJT.Ext
{
    public static partial class 扩展 
    {
        /// <summary>
        /// 如果是float 转为float,否则tostring,tofloat
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static float ToFloat2(this object b)
        {
            if (b is float f)
            {
                return f;
            }

            return b.ToString2().ToFloat();
        }


        /// <summary>
        /// 字符串转int32,错误转为0;
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int ToInt(this object str)
        {
            if (str == null)
                return 0;
            var m = int.TryParse(str.ToString().Trim(), out int n);
            return m ? n : 0;
        }

        /// <summary>
        /// 返回对象的字符串表示,如果为空返回 string.Empty
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>System.String.</returns>
        public static string ToString2(this object str)
        {
            return str?.ToString() ?? string.Empty;
        }


        /// <summary>
        /// 如果是double,直接返回,否则尝试转为double,
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static double ToDouble2(this object obj)
        {
            if (obj == null)
                return 0d;
            if (obj is double d1)
                return d1;
            var b = double.TryParse(obj.ToString(), out var r);
            return b ? r : 0d;
        }

        /// <summary>
        /// 对象如果是时间,直接返回,否则转字串,再尝试转时间.错误返回最小时间
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this object obj)
        {
            if (obj == null)
                return DateTime.MinValue;
            if (obj is DateTime dt)
                return dt;
            var b = DateTime.TryParse(obj.ToString(), out var dt2);
            return b ? dt2 : DateTime.MinValue;
        }
    }
}