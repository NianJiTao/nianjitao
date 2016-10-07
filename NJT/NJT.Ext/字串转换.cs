using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace NJT.Ext
{
    public static partial class 扩展方法
    {


        /// <summary>
        /// 字串格式化示例
        /// </summary>
        static void 格式化()
        {
            12345.ToString("n"); //生成 12,345.00 
            12345.ToString("C"); //生成 ￥12,345.00 
            12345.ToString("e"); //生成 1.234500e+004 
            12345.ToString("f4"); //生成 12345.0000 
            12345.ToString("x"); //生成 3039 (16进制) 
            12345.ToString("p"); //生成 1,234,500.00% 
        }

         

        /// <summary>
        /// "数值123" 可分离为 item1=数值, item2=123, item3=3
        /// "数值05" 可分离为 item1=数值, item2=5, item3=2
        /// 返回:字串,数字,数字位数.
        /// </summary>
        /// <param name="str">The STR.</param>
        /// <returns>Tuple{System.StringSystem.Int32}.</returns>
        public static Tuple<string, int, int> To分离数值(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return new Tuple<string, int, int>(str, 0, 0);

            int r2;
            var c = 0;
            var 数字 = 0;
            for (var i = 1; i < str.Length + 1; i++)
            {
                if (int.TryParse(str.Substring(str.Length - i, i), out r2))
                {
                    c = i;
                    数字 = r2;
                }
                else
                {
                    break;
                }
            }
            var 字串 = c <= 0 ? str : c >= str.Length ? "" : str.Remove(str.Length - c);
            return new Tuple<string, int, int>(字串, 数字, c);
        }


        /// <summary>
        /// 如1024 --> 1 KB
        /// </summary>
        /// <param name="字节">The 字节.</param>
        /// <returns>System.String.</returns>
        public static string To文件大小(this long 字节)
        {
            var 对数 = (字节 <= 0) ? 0: (int)Math.Log(字节, 1024);
            if (对数 > 9)
            {
                return  "超大";
            }
            var 大小 = (decimal)字节 / (1L << (对数 * 10));
            return $"{大小:n1} {单位[对数]}";
        }
        static string[] 单位 = { "字节", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB", "BB" };


        public static string To百分比(double 数值)
        {
            return 数值.ToString("p");
        }
    }
}
