﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NJT.Ext
{
    public static partial class 扩展
    {
        static string[] 单位 = {"字节", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB", "BB"};

        /// <summary>
        /// byte转换为BCD码  
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int ConvertToBCD(this byte b)
        {
            //高四位    
            var b1 = (b / 10);
            //低四位    
            var b2 = (b % 10);
            return ((b1 << 4) | b2);
        }

        /// <summary>
        /// 解析BCD结构的字节为十进制
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int ConvertBCDToInt(this byte b)
        {
            //高四位    
            var b1 = ((b >> 4) & 0xF);
            //低四位    
            var b2 = (b & 0xF);

            return (b1 * 10 + b2);
        }


        /// <summary>
        /// 如1024 --> 1 KB
        /// </summary>
        /// <param name="字节">The 字节.</param>
        /// <returns>System.String.</returns>
        public static string To文件大小(this long 字节)
        {
            var 对数 = (字节 <= 0) ? 0 : (int) Math.Log(字节, 1024);
            if (对数 > 9)
            {
                return "超大";
            }

            var 大小 = (decimal) 字节 / (1L << (对数 * 10));
            return $"{大小:n1} {单位[对数]}";
        }


        public static string To百分比(this double 数值)
        {
            return 数值.ToString("p");
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

        /// <summary>
        /// 在后面填充的字节 空格 32
        /// </summary>
        /// <param name="字串"></param>
        /// <param name="长度"></param>
        /// <param name="填充">在后面填充的字节空格 32</param>
        /// <returns></returns>
        public static byte[] 长度修正(this byte[] 字串, int 长度, byte 填充 = 32)
        {
            长度 = 长度.范围限制(0, short.MaxValue);
            if (字串 == null)
            {
                return Enumerable.Repeat(填充, 长度).ToArray();
            }

            if (字串.Length > 长度)
            {
                return 字串.Take(长度).ToArray();
            }

            if (字串.Length < 长度)
            {
                var r = 字串.Concat(Enumerable.Repeat(填充, 长度 - 字串.Length));
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
            长度 = 长度.范围限制(0, short.MaxValue);
            if (字串 == null)
            {
                return Enumerable.Repeat(填充, 长度).ToArray();
            }

            if (字串.Length > 长度)
            {
                return 字串.Take(长度).ToArray();
            }

            if (字串.Length < 长度)
            {
                var r = Enumerable.Repeat(填充, 长度 - 字串.Length).Concat(字串);
                return r.ToArray();
            }

            return 字串;
        }

        /// <summary>
        /// 整数秒转换到时间.
        /// </summary>
        /// <param name="ss">The string.</param>
        /// <returns>TimeSpan.</returns>
        public static TimeSpan ToTimeSpan(this int ss)
        {
            return new TimeSpan(0, 0, 0, ss);
        }

        /// <summary>
        /// 按秒转为TimeSpan
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static TimeSpan 秒(this int obj)
        {
            return TimeSpan.FromSeconds(obj);
        }

        public static TimeSpan 毫秒(this int obj)
        {
            return TimeSpan.FromMilliseconds(obj);
        }

        public static TimeSpan 分钟(this int obj)
        {
            return TimeSpan.FromMinutes(obj);
        }

        public static TimeSpan 小时(this int obj)
        {
            return TimeSpan.FromHours(obj);
        }

        /// <summary>
        /// 生成List,按数量
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="数量"></param>
        /// <returns></returns>
        public static List<T> GetList<T>(this int 数量) where T : new()
        {
            if (数量 <= 0)
                return new List<T>();
            var list2 = Enumerable.Range(0, 数量)
                .Select(i => new T())
                .ToList();
            return list2;
        }


        /// <summary>
        /// 返回字节组的字符串形式,用utf8解码
        /// </summary>
        /// <param name="字节组"></param>
        /// <returns></returns>
        public static string GetString(this byte[] 字节组)
        {
            return GetString(字节组, Encoding.UTF8);
        }

        /// <summary>
        /// 根据指定编码返回字串
        /// </summary>
        /// <param name="字节组"></param>
        /// <param name="编码"></param>
        /// <returns></returns>
        public static string GetString(this byte[] 字节组, Encoding 编码)
        {
            if (字节组 == null || !字节组.Any() || 编码 == null)
                return string.Empty;

            var m = 字节组.Where(x => x > 0).ToArray();
            if (!m.Any())
                return string.Empty;

            return 编码.GetString(m);
        }
    }
}