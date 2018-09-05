using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;

namespace NJT.Ext
{
    public static partial class 扩展 
    {
        public static string GetFileName(this string cs)
        {
            if (string.IsNullOrEmpty(cs))
                return string.Empty;
            try
            {
                return System.IO.Path.GetFileNameWithoutExtension(cs);
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 验证字串是否为true,或者1,
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool ToBool(this string b)
        {
            if (string.Equals("True", b, StringComparison.CurrentCultureIgnoreCase))
            {
                return true;
            }

            if (string.Equals("1", b, StringComparison.CurrentCultureIgnoreCase))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 验证长度,再返回,长度不够返回空字串.
        /// </summary>
        /// <param name="b"></param>
        /// <param name="index"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string Remove2(this string b, int index, int len)
        {
            if (string.IsNullOrEmpty(b))
            {
                return string.Empty;
            }
            index = index.范围限制(0, short.MaxValue);
            len = len.范围限制(0, short.MaxValue);
            return b.Length > (index + len) ? b.Remove(index, len) : string.Empty;
        }


        /// <summary>
        /// 返回字串内指定长度,如果长度不够,返回原字串全长.
        /// </summary>
        /// <param name="b"></param>
        /// <param name="index"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string Substring2(this string b, int index, int len)
        {
            if (string.IsNullOrEmpty(b))
            {
                return string.Empty;
            }
            index = index.范围限制(0, short.MaxValue);
            len = len.范围限制(0, short.MaxValue);
            return b.Length <= (index + len) ? b : b.Substring(index, len);
        }

        /// <summary>
        ///  返回  i.ToString().PadLeft(len, '0'); 如1->001
        /// </summary>
        /// <param name="i"></param>
        /// <param name="长度"></param>
        /// <returns></returns>
        public static string ToString00N(this int i, int 长度 = 3)
        {
            长度 = 长度.范围限制(0, 127);
            return i.ToString().PadLeft(长度, '0');
        }

        public static string Remove非文件名字符(this string obj)
        {
            if (string.IsNullOrEmpty(obj)) return obj;
            var 非法字符 = System.IO.Path.GetInvalidFileNameChars();
            return obj.Remove字符(非法字符);
        }

        public static string Remove非目录字符(this string obj)
        {
            if (string.IsNullOrEmpty(obj)) return obj;
            var 非法字符 = System.IO.Path.GetInvalidPathChars();
            return obj.Remove字符(非法字符);
        }

        public static string Remove字符(this string obj, char[] 排除表)
        {
            if (string.IsNullOrEmpty(obj)) return obj;
            if (排除表==null ) return obj;
            var byte2 = obj.ToCharArray().Where(x => !排除表.Contains(x)).ToArray();
            var r = new string(byte2);
            return r;
        }

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
        /// 返回:字串,数字,数字位数.
        /// </summary>
        /// <param name="str">The STR.</param>
        /// <returns>Tuple{System.StringSystem.Int32}.</returns>
        public static Tuple<string, int, int> To分离数值(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return new Tuple<string, int, int>(str, 0, 0);

            var c = 0;
            var 数字 = 0;
            for (var i = 1; i < str.Length + 1; i++)
            {
                if (int.TryParse(str.Substring(str.Length - i, i), out var r2))
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


        static string[] 单位 = {"字节", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB", "BB"};


        public static float ToFloat(this string obj)
        {
            var f = 0f;
            if (string.IsNullOrEmpty(obj))
            {
                return f;
            }

            float.TryParse(obj, out f);
            return f;
        }


        public static string To目录合并(this string 目录1, string 目录2)
        {
            return System.IO.Path.Combine(目录1, 目录2);
        }

        public static string To合并文件名(this string dir2, string 文件名x)
        {
            if (string.IsNullOrEmpty(文件名x))
                文件名x = string.Empty;

            if (string.IsNullOrEmpty(dir2))
                dir2 = string.Empty;
            var 文件名 = 文件名x.Remove非文件名字符();
            try
            {
                var n2 = System.IO.Path.Combine(dir2, 文件名);
                文件名 = n2;
            }
            catch (Exception)
            {
                return dir2;
            }

            return 文件名;
        }

        public static string Get首字母(this string 汉字串)
        {
            return 拼音.首字母(汉字串);
        }


        public static byte[] HexToByte(this string hexString)
        {
            if (string.IsNullOrEmpty(hexString))
            {
                return new byte[0];
            }
            var returnBytes = new byte[hexString.Length / 2];
            for (var i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);  //未验证是否有效数字
            return returnBytes;
        }


        /// <summary>
        /// item1:是否建立成功,
        /// item2:错误信息.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static Tuple<bool, string> CreatDir(this string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return new Tuple<bool, string>(false, "文件名为空");
            }

            var dir = string.Empty;
            try
            {
                dir = System.IO.Path.GetDirectoryName(fileName);
            }
            catch (Exception e)
            {
                return new Tuple<bool, string>(false, e.Message);
            }

            if (System.IO.Directory.Exists(dir))
            {
                return new Tuple<bool, string>(true, "目录已经存在");
            }

            try
            {
                System.IO.Directory.CreateDirectory(dir);
            }
            catch (Exception e)
            {
                return new Tuple<bool, string>(false, e.Message);
            }

            return new Tuple<bool, string>(true, string.Empty);
        }


        public static string[] To分割(this string text, string 分割符 = ";")
        {
            if (string.IsNullOrEmpty(分割符))
            {
                分割符 = ";";
            }
            var r = new string[0];
            if (!string.IsNullOrEmpty(text))
                r = text.Split(分割符.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            return r;
        }


        /// <summary>
        /// 不区分大小写,相比较.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool 等于(this string a, string b)
        {
            return (string.Equals(a, b, StringComparison.CurrentCultureIgnoreCase));
        }


        /// <summary>
        /// 太长截取,太短右边补填充,默认补空格
        /// </summary>
        /// <param name="字串"></param>
        /// <param name="长度"></param>
        /// <param name="填充"></param>
        /// <returns></returns>
        public static string 长度修正(this string 字串, int 长度, char 填充 = ' ')
        {
            长度 = 长度.范围限制(0, byte.MaxValue);
            if (字串 == null)
            {
                return string.Empty.PadRight(长度, 填充);
            }


            if (字串.Length > 长度)
            {
                return 字串.Remove(长度);
            }

            if (字串.Length < 长度)
            {
                return 字串.PadRight(长度, 填充);
            }

            return 字串;
        }


        /// <summary>
        /// 短:左边补0,如:-03,0006 ,长截取.
        /// </summary>
        /// <param name="字串"></param>
        /// <param name="长度"></param>
        /// <returns></returns>
        public static string 数字长度修正(this string 字串, int 长度)
        {
            长度 = 长度.范围限制(0, byte.MaxValue);
            if (字串 == null)
            {
                return string.Empty.PadLeft(长度,  '0');
            }

            if (字串.Length > 长度)
            {
                return 字串.Remove(长度);
            }

            if (字串.Length < 长度)
            {
                if (字串.StartsWith("-"))
                {
                    return "-" + 字串.Remove(0, 1).PadLeft(长度, '0').Remove(0, 1);
                }

                return 字串.PadLeft(长度, '0');
            }

            return 字串;
        }


        public static double ToDouble(this string obj)
        {
            if (string.IsNullOrEmpty(obj))
                return 0d;
            var b = double.TryParse(obj, out var r);
            return b ? r : 0d;
        }


        /// <summary>
        /// 返回是否相等,不区分大小写, true和1相等.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool 等于OrBool(this string a, string b)
        {
            if (a==null || b==null)
            {
                return false;
            }
            var r = a.等于(b);
            if (r)
                return true;

            if (a.ToBool() && b.ToBool())
                return true;

            return false;
        }


        /// <summary>
        /// yyyyMMddHHmmss 格式可转换.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>TimeSpan.</returns>
        public static DateTime GetDateTime14(this string str)
        {
            try
            {
                var dt = str.GetDateTime("yyyyMMddHHmmss");
                return dt;
            }
            catch (Exception)
            {
                return DateTime.MinValue;
            }
        }

        /// <summary>
        /// yyyyMMdd 格式可转换.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime GetDateTime8(this string str)
        {
            try
            {
                var dt = str.GetDateTime("yyyyMMdd");
                return dt;
            }
            catch (Exception)
            {
                return DateTime.MinValue;
            }
        }

        public static DateTime GetDateTime(this string 字符串, string 日期格式)
        {
            if (string.IsNullOrWhiteSpace(字符串) || string.IsNullOrEmpty(日期格式))
            {
                return DateTime.MinValue;
            }
            var r = DateTime.ParseExact(字符串, 日期格式, CultureInfo.CurrentCulture, DateTimeStyles.AllowWhiteSpaces);
            return r;
        }
    }
}