using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinccVbsPassWordsLook
{
    public class 解密
    {
        public string 运行(string 文件)
        {
            var list2 = 读取文件(文件);
            if (!list2.Any())
                return string.Empty;
            var list3 = 分割密码70(list2.ToList());

            if (list3.Count > 0) return wincc7x解密(list3, Properties.Settings.Default.密钥70);
            var list4 = 分割密码73(list2.ToList());
            if (list4.Count > 0) return wincc7x解密(list4, Properties.Settings.Default.密钥73);
            return string.Empty;
        }


        private string wincc7x解密(List<byte> list3, string 钥匙)
        {
            var a2 = list3.ToArray();
            var b2 = 钥匙.ToCharArray();
            var len3 = Math.Min(a2.Length, b2.Length);
            var c2 = new byte[len3];
            for (int i = 0; i < len3; i++) c2[i] = (byte) (a2[i] ^ b2[i]);
            return Encoding.UTF8.GetString(c2, 0, c2.Length);
        }


        private List<byte> 分割密码70(List<byte> list2)
        {
            list2.Reverse();
            for (int i = 1; i < 21; i++)
            {
                var len = i;
                if (list2[len + 3] == len && list2[len + 2] == 0 && list2[len + 1] == 0 && list2[len + 0] == 0)
                {
                    var bb = list2.Take(len).Reverse().ToList();
                    return bb;
                }
            }

            list2.Reverse();
            return new List<byte>();
        }


        private List<byte> 分割密码73(List<byte> list2)
        {
            list2.Reverse();
            List<byte> l6 = new List<byte>();
            for (int i = 1; i < 21; i++)
            {
                var len = i * 2; //wincc73,每个字符密码长度2
                if (list2[len + 3] == i && list2[len + 2] == 0 && list2[len + 1] == 0 && list2[len + 0] == 0)
                {
                    var bb = list2.Take(len).Reverse().ToList();
                    for (int j = 0; j < bb.Count; j++)
                        if (j % 2 == 0)
                            l6.Add(bb[j]);

                    return l6;
                }
            }

            list2.Reverse();

            return new List<byte>();
        }


        private List<byte> 读取文件(string 文件)
        {
            var list2 = new List<byte>();
            try
            {
                var readStream = new FileStream(文件, FileMode.Open);
                byte[] data = new byte[4096];
                var len2 = 50;
                while (true)
                {
                    int length = readStream.Read(data, 0, data.Length);
                    if (length == 0)
                        break;
                    if (length < len2)
                    {
                        list2 = list2.Concat(data.Take(length)).ToList();
                        list2 = list2.Skip(list2.Count - len2).Take(len2).ToList();
                    }
                    else if (length <= 4096)
                    {
                        list2 = data.Skip(length - len2).Take(len2).ToList();
                    }
                }

                readStream.Close();
                return list2;
            }
            catch (Exception e)
            {
                return new List<byte>();
            }
        }
    }
}