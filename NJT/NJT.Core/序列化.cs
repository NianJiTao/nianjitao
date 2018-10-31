using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NJT.Core

{
    public static partial class 序列化
    {
        public static Encoding 编码 = Encoding.Default;


        /// <summary>
        ///     在当前程序目录下写入名为"配置"的XML文件
        /// </summary>
        public static 运行结果 写入<T>(T 要写入的数据, string 文件名)
        {
            Action<Stream, object> seria = (s, o) =>
            {
                var xml序列 = new XmlSerializer(typeof(T));
                xml序列.Serialize(s, o);
            };
            return 写入base(要写入的数据, 文件名, seria);
        }


        /// <summary>
        ///     读出当前目录下名为"配置"的文件
        /// </summary>
        public static 运行结果<T> 读出<T>(string 文件名)
        {
            Func<Stream, object> 反序列化 = o =>
            {
                var xs = new XmlSerializer(typeof(T));
                var r = xs.Deserialize(o);
                return r;
            };
            return 读出base<T>(文件名, 反序列化);
        }


        /// <summary>
        ///     序列化
        /// </summary>
        /// <param name="data">要序列化的对象</param>
        /// <returns>返回存放序列化后的数据缓冲区</returns>
        public static byte[] To二进制(object data)
        {
            if (data == null)
                return new byte[0];
            var formatter = new BinaryFormatter();
            var rems = new MemoryStream();
            formatter.Serialize(rems, data);
            return rems.GetBuffer();
        }


        /// <summary>
        ///     反序列化
        /// </summary>
        /// <param name="data">数据缓冲区</param>
        /// <returns>对象</returns>
        public static object From二进制(byte[] data)
        {
            if (data == null)
                return null;
            if (data.Length == 0)
                return null;
            var formatter = new BinaryFormatter();
            var rems = new MemoryStream(data);
            return formatter.Deserialize(rems);
        }


        public static 运行结果 写入二进制<T>(T 要写入的数据, string 文件名)
        {
            Action<Stream, object> seria = (s, o) =>
            {
                var xml序列 = new BinaryFormatter();
                xml序列.Serialize(s, o);
            };
            return 写入base(要写入的数据, 文件名, seria);
        }


        public static 运行结果<T> 读出二进制<T>(string 文件名)
        {
            Func<Stream, object> 反序列化 = o =>
            {
                var xs = new BinaryFormatter();
                var r = xs.Deserialize(o);
                return r;
            };
            return 读出base<T>(文件名, 反序列化);
        }


        private static 运行结果 写入base<T>(T 要写入的数据, string 文件名, Action<Stream, object> 序列化方法)
        {
            if (string.IsNullOrEmpty(文件名))
                return new 运行结果(false, "文件名为空");
            try
            {
                var 数据流 = new FileStream(文件名, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                try
                {
                    序列化方法.Invoke(数据流, 要写入的数据);
                    数据流.Close();
                    return new 运行结果(true);
                }
                catch (Exception exc)
                {
                    数据流.Close();
                    return new 运行结果(false, exc.Message);
                }
            }
            catch (Exception exc)
            {
                return new 运行结果(false, exc.Message);
            }
        }

        private static 运行结果<T> 读出base<T>(string 文件名, Func<Stream, object> 反序列化方法)
        {
            if (!File.Exists(文件名))
                return new 运行结果<T>(false, "文件名不存在");
            T 数据;
            Stream stream = new FileStream(文件名, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            try
            {
                var data = 反序列化方法.Invoke(stream);
                数据 = (T) data;
            }
            catch (Exception exc)
            {
                return new 运行结果<T>(false, exc.Message);
            }
            finally
            {
                stream.Close();
            }

            return new 运行结果<T>(true) {Data = 数据};
        }

        public static async Task<运行结果> 合并txt(IList<string> 文件列表, string 目标文件名)
        {
            bool 合并成功;
            var sw = new StreamWriter(目标文件名);
            try
            {
                foreach (var item in 文件列表)
                {
                    var r2 = await 读出txt(item);
                    if (r2.IsTrue)
                        await sw.WriteAsync(r2.Data);
                }

                合并成功 = true;
            }
            catch (Exception)
            {
                合并成功 = false;
            }
            finally
            {
                sw?.Close();
            }

            return new 运行结果(合并成功);
        }

        public static async Task<运行结果> 写入txt(string 文件名, string 内容)
        {
            return await 写入txt(文件名, 内容, false);
        }

        public static async Task<运行结果> 追加txt(string 文件名, string 内容)
        {
            return await 写入txt(文件名, 内容, true);
        }

        private static async Task<运行结果> 写入txt(string 文件名, string 内容, bool 追加)
        {
            if (string.IsNullOrEmpty(文件名))
                return new 运行结果(false, "文件名为空");
            try
            {
                var myWriter = new StreamWriter(文件名, 追加, 编码);
                await myWriter.WriteAsync(内容);
                myWriter.Close();
                return new 运行结果(true);
            }
            catch (Exception ee)
            {
                return new 运行结果(false, ee.Message);
            }
        }

        public static async Task<运行结果<string>> 读出txt(string 文件名)
        {
            string 结果;
            if (string.IsNullOrEmpty(文件名))
                return new 运行结果<string>(false, "文件名为空");
            StreamReader myReader = null;
            try
            {
                myReader = new StreamReader(文件名, 编码);
                结果 = await myReader.ReadToEndAsync();
            }
            catch (Exception ee)
            {
                return new 运行结果<string>(false, ee.Message);
            }
            finally
            {
                myReader?.Close();
            }

            return new 运行结果<string>(true) {Data = 结果};
        }

        public static async Task<运行结果> 插入首行txt(string 文件名, string h4)
        {
            if (string.IsNullOrEmpty(文件名))
                return new 运行结果(false, "文件名为空");

            var r = await 序列化.读出txt(文件名);
            if (r.IsTrue == false)
            {
                return new 运行结果(false, r.Message);
            }

            var 内容 = h4 + r.Data;

            return await 写入txt(文件名, 内容, false);
        }
    }
}