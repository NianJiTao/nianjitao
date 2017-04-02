using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Core
{
    public static class 注册
    {
        public static string 本机特征码 { get; private set; }


        public static string[] 版权
        {
            get
            {
                return new[]
                {
                    "设计开发:年纪涛",
                    "电话:13913140677",
                    "QQ:925007694",
                    "微信:FMTV365",
                    "邮箱:nianjitao@outlook.com"
                };
            }
        }

        private static I硬件信息 _硬件 = new 硬件信息();

        public static string 计算特征码()
        {
            本机特征码 = _硬件.Get特征码();
            return 本机特征码;
        }

        public static bool 验证注册(string 公钥, string 特征码, string 注册码)
        {
            if (string.IsNullOrEmpty(注册码)) return false;
            if (注册码.Length < 15) return false;
            var 结果 = false;
            try
            {
                var 日期 = 提取日期(注册码);
                if (DateTime.Today > 日期) return false;
                var 签名源 = 源数据组合(特征码, 日期);
                var 哈希 = Get哈希码(签名源);
                结果 = 授权验证(公钥, 哈希, 注册码.Remove(0, 14));
            }
            catch (Exception)
            {
                结果 = false;
            }
            return 结果;
        }


        public static DateTime 提取日期(string 注册码)
        {
            try
            {
                if (注册码.Length < 15) return DateTime.MinValue;
                var 日期字节 = Base24Encoding.解码toByte(注册码.Substring(0, 14));
                var 日期字串 = Encoding.UTF8.GetString(日期字节);
                var 转换天数 = int.TryParse(日期字串, out int 天数);
                if (!转换天数) return DateTime.MinValue;
                var 日期 = DateTime.MinValue.AddDays(天数);
                return 日期;
            }
            catch (Exception)
            {
                return DateTime.MinValue;
            }
        }


        public static bool 授权验证(string 公钥, string 哈希码, string 授权码)
        {
            try
            {
                var t = Base24Encoding.解码toByte(授权码);
                var t2 = Convert.FromBase64String(哈希码);
                var key = new RSACryptoServiceProvider();
                key.FromXmlString(公钥);
                var deformatter = new RSAPKCS1SignatureDeformatter(key);
                deformatter.SetHashAlgorithm("SHA1");
                if (deformatter.VerifySignature(t2, t))
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }


        public static bool 完整验证(string 公钥, string md5数据)
        {
            return GetMd5(公钥) == md5数据;
        }


        public static string 源数据组合(string 机器码, DateTime 日期)
        {
            return 机器码 + 日期.ToString("yyyy_MM_dd");
        }


        public static string Get哈希码(string 源数据)
        {
            var bytes = Encoding.GetEncoding("GB2312").GetBytes(源数据);
            var inArray = HashAlgorithm.Create("SHA1")?.ComputeHash(bytes);
            return Convert.ToBase64String(inArray??new byte[]{30});
        }


        public static string 签名(string 私钥, string 源数据)
        {
            try
            {
                var hashbyteSignature = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(源数据));
                var rsa = new RSACryptoServiceProvider();
                rsa.FromXmlString(私钥);
                var rsaFormatter = new RSAPKCS1SignatureFormatter(rsa);
                rsaFormatter.SetHashAlgorithm("SHA1");
                //执行签名
                var encryptedSignatureData = rsaFormatter.CreateSignature(hashbyteSignature);
                var 结果 = Base24Encoding.编码toString(encryptedSignatureData);
                return 结果;
            }
            catch (Exception ee)
            {
                return ee.Message;
            }
        }


        public static string 读取钥匙(string dir)
        {
            try
            {
                var reader = new StreamReader(dir);
                var privatekey = reader.ReadToEnd();
                reader.Close();
                return privatekey;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }


        public static string GetMd5(string initString)
        {
            var md5 = new MD5CryptoServiceProvider();
            var btSerialCode = md5.ComputeHash(Encoding.Default.GetBytes(initString));
            var encryptedString = BitConverter.ToString(btSerialCode);
            encryptedString = encryptedString.Replace("-", "");
            return encryptedString;
        }
    }
}
