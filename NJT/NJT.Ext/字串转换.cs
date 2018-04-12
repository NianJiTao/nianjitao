﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace NJT.Ext
{
    public static partial class 扩展方法
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

            if (b.Length > (index + len))
            {
                return b.Remove(index, len);
            }

            return string.Empty;
        }


        /// <summary>
        /// byte转换为BCD码  
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static byte ConvertToBCD(this byte b)
        {
            //高四位    
            var b1 = (byte)(b / 10);
            //低四位    
            var b2 = (byte)(b % 10);
            return (byte)((b1 << 4) | b2);
        }

        /// <summary>
        /// 解析BCD结构的字节为十进制
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static byte ConvertBCDToInt(this byte b)
        {
            //高四位    
            var b1 = (byte)((b >> 4) & 0xF);
            //低四位    
            var b2 = (byte)(b & 0xF);

            return (byte)(b1 * 10 + b2);
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

            if (b.Length > (index + len))
            {
                return b.Substring(index, len);
            }

            return b;
        }

        /// <summary>
        ///  返回  i.ToString().PadLeft(len, '0'); 如1->001
        /// </summary>
        /// <param name="i"></param>
        /// <param name="长度"></param>
        /// <returns></returns>
        public static string ToString00N(this int i, int 长度 = 3)
        {
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
            var m = int.TryParse(str.ToString().Trim(), out int n);
            return m ? n : 0;
        }
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

        /// <summary>
        /// 串联string
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="分隔符"></param>
        /// <returns></returns>
        public static string To串联(this IEnumerable<string> lt, string 分隔符 = "")
        {
            return string.Join(分隔符, lt);
        }
        //        public static  (int add, int multiply) Add_Multiply(int int1, int int2)
        //11     => (int1 + int2, int1* int2); 

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
        public static string 长度修正(this string 字串, int 长度,char 填充=' ')
        {
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
        /// 在后面填充的字节 空格 32
        /// </summary>
        /// <param name="字串"></param>
        /// <param name="长度"></param>
        /// <param name="填充">在后面填充的字节空格 32</param>
        /// <returns></returns>
        public static byte[] 长度修正(this byte[] 字串, int 长度, byte 填充 = 32)
        {
            if (字串.Length > 长度)
            {
                return 字串.Take(长度).ToArray();
            }
            if (字串.Length < 长度)
            {
                var b2 = new byte[长度 - 字串.Length];
                for (var i = 0; i < b2.Length; i++)
                {
                    b2[i] = 填充;
                }
                var r = 字串.Concat(b2);
                return r.ToArray();
            }
            return 字串;
        }

        /// <summary>
        /// 在前面填充的字节 0 (ascii-48)
        /// </summary>
        /// <param name="字串"></param>
        /// <param name="长度"></param>
        /// <param name="填充"></param>
        /// <returns></returns>
        public static byte[] 数字长度修正(this byte[] 字串, int 长度, byte 填充 = 48)
        {
            if (字串.Length > 长度)
            {
                return 字串.Take(长度).ToArray();
            }
            if (字串.Length < 长度)
            {
                var b2 = new byte[长度 - 字串.Length];
                for (var i = 0; i < b2.Length; i++)
                {
                    b2[i] = 填充;
                }
                var r = b2.Concat(字串);
                return r.ToArray();
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

        public static double ToDouble(this string obj)
        {
            if (string.IsNullOrEmpty(obj))
                return 0d;
            var b = double.TryParse(obj, out var r);
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
