using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LogTxt
{
    public class 序列化
    {
        public static void 写入txt(string 文件名, string 内容, bool 追加)
        {
            if (string.IsNullOrEmpty(文件名))
                return;
            if (string.IsNullOrEmpty(内容))
                内容 = string.Empty;
            try
            {
                var myWriter = new StreamWriter(文件名, 追加, Encoding.Default);
                //myWriter.WriteLine(内容);
                myWriter.Write(内容);
                myWriter.Close();
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}