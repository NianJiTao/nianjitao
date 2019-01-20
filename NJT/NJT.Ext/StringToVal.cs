using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace NJT.Ext
{
    public static partial class 扩展
    {
        /// <summary>
        /// 验证字串是否为true,或者1,
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool ToBool(this string b)
        {
            return string.Equals("True", b, StringComparison.CurrentCultureIgnoreCase)
                   || string.Equals("1", b, StringComparison.CurrentCultureIgnoreCase);
        }


        public static float ToFloat(this string obj)
        {
            var f = 0f;
            if (string.IsNullOrEmpty(obj))
                return f;

            float.TryParse(obj, out f);
            return f;
        }


        public static double ToDouble(this string obj)
        {
            if (string.IsNullOrEmpty(obj))
                return 0d;
            var b = double.TryParse(obj, out var r);
            return b ? r : 0d;
        }


        /// <summary>
        /// 字符串转int32,错误转为0;
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int ToInt(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return 0;
            var m = int.TryParse(str.Trim(), out int n);
            return m ? n : 0;
        }


        /// <summary>
        /// 提取字串内的整数数字.如第1段返回1. 只提取首次匹配
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int GetNumber(this string obj)
        {
            if (string.IsNullOrEmpty(obj))
                return 0;

            var find = Regex.Match(obj, "\\d+");
            if (!find.Success)
                return 0;

            return find.Value.ToInt();
        }

        public static DateTime ToDateTime(this string obj)
        {
            if (string.IsNullOrEmpty(obj))
                return DateTime.MinValue;
            var b = DateTime.TryParse(obj, out var dt2);
            return b ? dt2 : DateTime.MinValue;
        }
    }
}