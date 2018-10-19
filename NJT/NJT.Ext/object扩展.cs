using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using NJT.Core;

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



        /// <summary>
        /// 根据参数引用,返回提取是否成功,和参数值
        /// 支持多级参数,用.分割;如:忠旺退火炉卷信息.[0].铝卷号
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="参数引用"></param>
        /// <returns></returns>
        public static I运行结果<object> Get参数值(this object obj, string 参数引用)
        {
            if (obj == null)
                return new 运行结果<object>(false, "参数为空") { Data = null };

            if (string.IsNullOrEmpty(参数引用))
                return new 运行结果<object>(true) { Data = obj };

            var 子级参数 = 参数引用.To分割(".");
            var 待提取 = obj;
            I运行结果<object> r = new 运行结果<object>(true) { Data = obj };
            foreach (var s in 子级参数)
            {
                r = Get参数值2(待提取, s);
                //if (!r.IsTrue) break;//提取错误也继续提取
                待提取 = r.Data;
            }

            return r;
        }

        private static I运行结果<object> Get参数值2(object obj, string 参数引用)
        {
            //匹配 [0] 或者[]
            var is索引 = Regex.Match(参数引用, "\\[\\d*\\]");
            if (!is索引.Success)
            {
                var propertiesList = obj.GetPropertiesList();
                var propertyInfo = propertiesList.FirstOrDefault(x => x.Name == 参数引用);
                if (propertyInfo == null)
                {
                    return new 运行结果<object>(false, "未找到参数") { Data = obj };
                }

                var r = RunFunc.TryRun(() => propertyInfo.GetValue(obj));
                if (!r.IsTrue) r.Data = obj;

                return r;
            }

            var index = 参数引用.GetNumber();

            if (obj is IEnumerable<object> coll2)
            {
                var r = coll2.Count() > index
                    ? new 运行结果<object>(true) { Data = coll2.Skip(index).FirstOrDefault() }
                    : new 运行结果<object>(false, $"{index}索引太大") { Data = coll2 };

                return r;
            }

            return new 运行结果<object>(false, $"{参数引用}不是集合") { Data = obj };
        }
    }
}