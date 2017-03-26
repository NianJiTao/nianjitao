using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

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
        /// "abc123" 可分离为 item1=abc, item2=123, item3=3
        /// "abc05" 可分离为 item1=bac, item2=5, item3=2
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
            var 对数 = (字节 <= 0) ? 0 : (int)Math.Log(字节, 1024);
            if (对数 > 9)
            {
                return "超大";
            }
            var 大小 = (decimal)字节 / (1L << (对数 * 10));
            return $"{大小:n1} {单位[对数]}";
        }
        static string[] 单位 = { "字节", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB", "BB" };


        public static string To百分比(double 数值)
        {
            return 数值.ToString("p");
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
            var n = 0;
            var m = int.TryParse(str.ToString().Trim(), out n);
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


        public static string To目录合并(this string 目录1, string 目录2)
        {
            return System.IO.Path.Combine(目录1, 目录2);
        }

        public static string Get首字母(this string 汉字串)
        {
            return 拼音.首字母(汉字串); 
        }

        /// <summary>
        /// // 0xae00cf => "AE00CF "
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ToHexString(this byte[] bytes) 
        {
            var hexString = string.Empty;
            if (bytes != null)
            {
                var strB = new StringBuilder();
                for (var i = 0; i < bytes.Length; i++)
                {
                    strB.Append(bytes[i].ToString("X2"));
                }
                hexString = strB.ToString();
            }
            return hexString;
        }

        public static byte[] HexToByte(this string hexString)
        {
            var returnBytes = new byte[hexString.Length / 2];
            for (var i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }


        public static string ToJoin(this IEnumerable<string> lt ,string 分隔符="")
        {
            return string.Join(分隔符, lt );
        }


        public static void CreatDir(this string fileName)
        {
            var dir = System.IO.Path.GetDirectoryName(fileName);
            if (string.IsNullOrEmpty(dir))
            {
                return;
            }
            if (System.IO.Directory.Exists(dir))
            {
                return;
            }
            try
            {
                System.IO.Directory.CreateDirectory(dir);
            }
            catch (Exception)
            {
                return;
            }
        }


        public static string[] ToSpilt(this string text, string 分割符 = ";")
        {
            var r = new string[0];
            if (!string.IsNullOrEmpty(text))
                r = text.Split(分割符.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            return r;
        }
    }
}
