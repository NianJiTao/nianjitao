//using System;
//using System.IO;
//using System.Runtime.Serialization.Formatters.Binary;
//using System.Xml.Serialization;

//namespace NJT.Core

//{
//    public static class 序列化
//    {
//        /// <summary>
//        ///     在当前程序目录下写入名为"配置"的XML文件
//        /// </summary>
//        public static 执行结果 写入<T>(T 要写入的数据, string 文件名)
//        {
//            try
//            {
//                var xml序列 = new XmlSerializer(typeof(T));
//                var 数据流 = new FileStream(文件名, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
//                try
//                {
//                    xml序列.Serialize(数据流, 要写入的数据);
//                    数据流.Close();
//                    return new 执行结果(true);
//                }
//                catch (Exception exc)
//                {
//                    数据流.Close();
//                    return new 执行结果(false, exc.Message);
//                }
//            }
//            catch (Exception exc)
//            {
//                return new 执行结果(false, exc.Message);
//            }
//        }


        

//        /// <summary>
//        ///     序列化
//        /// </summary>
//        /// <param name="data">要序列化的对象</param>
//        /// <returns>返回存放序列化后的数据缓冲区</returns>
//        public static byte[] To二进制(object data)
//        {
//            if (data == null)
//            {
//                return new byte[0];
//            }
//            var formatter = new BinaryFormatter();
//            var rems = new MemoryStream();
//            formatter.Serialize(rems, data);
//            return rems.GetBuffer();
//        }


//        /// <summary>
//        ///     反序列化
//        /// </summary>
//        /// <param name="data">数据缓冲区</param>
//        /// <returns>对象</returns>
//        public static object From二进制(byte[] data)
//        {
//            if (data == null)
//                return null;
//            if (data.Length == 0)
//                return null;
//            var formatter = new BinaryFormatter();
//            var rems = new MemoryStream(data);
//            return formatter.Deserialize(rems);
//        }


//        public static 执行结果 写入二进制<T>(T 要写入的数据, string 文件名)
//        {
//            try
//            {
//                var b = new BinaryFormatter();
//                var 数据流 = new FileStream(文件名, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
//                try
//                {
//                    b.Serialize(数据流, 要写入的数据);
//                    数据流.Close();
//                    return new 执行结果(true);
//                }
//                catch (Exception exc)
//                {
//                    数据流.Close();
//                    return new 执行结果(false, exc.Message);
//                }
//            }
//            catch (Exception exc)
//            {
//                return new 执行结果(false, exc.Message);
//            }
//        }


//        public static 执行结果<T> 读出二进制<T>(string 文件名)
//        {
//            if (!File.Exists(文件名))
//                return new 执行结果<T>(false, "文件名不存在");
//            T 数据;
//            var b = new BinaryFormatter(); //SoapFormatter     
//            var stream = new FileStream(文件名, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
//            try
//            {
//                数据 = (T)b.Deserialize(stream);
//            }
//            catch (Exception exc)
//            {
//                return new 执行结果<T>(false, exc.Message);
//            }
//            finally
//            {
//                stream.Close();
//            }
//            return new 执行结果<T>(true) { Data = 数据 };
//        }
//    }
//}