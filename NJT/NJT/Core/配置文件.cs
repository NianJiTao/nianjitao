using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;

namespace NJT.Common
{
    public static class 配置文件
    {
        /// <summary>
        /// 在当前程序目录下写入名为"配置"的XML文件
        /// </summary>
        public static bool 写入<T>(T 要写入的数据, string 文件名)
        {
            try
            {
                var xml序列 = new XmlSerializer(typeof(T));
                var 数据流 = new FileStream(文件名, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                try
                {
                    xml序列.Serialize(数据流, 要写入的数据);
                    数据流.Close();
                    return true;
                }
                catch (Exception)
                {
                    数据流.Close();
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// 读出当前目录下名为"配置"的文件
        /// </summary>
        public static Tuple<bool, T> 读出<T>(string 文件名)
        {
            if (!File.Exists(文件名))
            {
                return new Tuple<bool, T>(false, default(T));
            }
            T 数据;
            var xs = new XmlSerializer(typeof(T));
            Stream stream = new FileStream(文件名, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            try
            {
                数据 = (T)xs.Deserialize(stream);
            }
            catch (Exception)
            {
                return new Tuple<bool, T>(false, default(T));
            }
            finally
            {
                stream.Close();
            }
            return new Tuple<bool, T>(true, 数据);
        }

        public static T 批量读出<T>(T 单例, string 配置文件名)
        {
            var 配置读取 = 读出<T>(配置文件名);
            if (配置读取.Item1)
            {
                单例 = 配置读取.Item2;
            }
            return 单例;
        }


        /// <summary> 
        /// 序列化 
        /// </summary> 
        /// <param name="data">要序列化的对象</param> 
        /// <returns>返回存放序列化后的数据缓冲区</returns> 
        public static byte[] Serialize(object data)
        {
            var formatter = new BinaryFormatter();
            var rems = new MemoryStream();
            formatter.Serialize(rems, data);
            return rems.GetBuffer();
        }

        /// <summary> 
        /// 反序列化 
        /// </summary> 
        /// <param name="data">数据缓冲区</param> 
        /// <returns>对象</returns> 
        public static object Deserialize(byte[] data)
        {
            var formatter = new BinaryFormatter();
            var rems = new MemoryStream(data);
            data = null;
            return formatter.Deserialize(rems);
        }


        public static bool 写入二进制<T>(T 要写入的数据, string 文件名)
        {
            try
            {
                var b = new BinaryFormatter();
                var 数据流 = new FileStream(文件名, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                try
                {
                    b.Serialize(数据流, 要写入的数据);
                    数据流.Close();
                    return true;
                }
                catch (Exception)
                {
                    数据流.Close();
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        public static Tuple<bool, T> 读出二进制<T>(string 文件名)
        {
            if (!File.Exists(文件名))
            {
                return new Tuple<bool, T>(false, default(T));
            }
            T 数据;
            var b = new BinaryFormatter(); //SoapFormatter     
            var stream = new FileStream(文件名, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            try
            {
                数据 = (T)b.Deserialize(stream);
            }
            catch (Exception)
            {
                return new Tuple<bool, T>(false, default(T));
            }
            finally
            {
                stream.Close();
            }
            return new Tuple<bool, T>(true, 数据);
        }


       
    }
}
