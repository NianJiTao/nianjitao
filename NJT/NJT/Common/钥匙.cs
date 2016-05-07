using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Common
{
    public partial class 钥匙
    {
        public void 生成钥匙(string dir, int 数量)
        {
            try
            {
                var 全部 = new StringBuilder();
                for (var i = 0; i < 数量; i++)
                {
                    var k = i.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0');
                    var 私钥文件 = Path.Combine(dir, string.Format("S{0}.xml", k));
                    var 公钥文件 = Path.Combine(dir, string.Format("P{0}.xml", k));
                    var provider = new RSACryptoServiceProvider();
                    var 私钥数据 = provider.ToXmlString(true);
                    var 公钥数据 = provider.ToXmlString(false);
                    全部.AppendLine(string.Format(@"public const string P{0} ={2}{1}{2};", k, 公钥数据, "\""));
                    全部.AppendLine(string.Format(@"public const string H{0} ={2}{1}{2};", k, sn.计算Md5(公钥数据), "\""));
                    写入文件(私钥文件, 私钥数据);
                    写入文件(公钥文件, 公钥数据);
                }
                var all = Path.Combine(dir, "all.txt");
                写入文件(all, 全部.ToString());
            }
            catch (Exception)
            {
            }
        }


        private void 写入文件(string path, string 数据)
        {
            try
            {
                var xmlFile = new FileStream(path, FileMode.Create);
                var sw = new StreamWriter(xmlFile);
                sw.WriteLine(数据);
                sw.Close();
                xmlFile.Close();
            }
            catch (Exception)
            {
            }
        }
    }
}
