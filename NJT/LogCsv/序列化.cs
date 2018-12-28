using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace LogCsv
{
    public class 序列化
    {
        public static Encoding 编码 { get; set; } = Encoding.Default;


        public static void 写入txt(string 文件名, string 内容)
        {
            if (string.IsNullOrEmpty(文件名))
                return;
            if (string.IsNullOrEmpty(内容))
                内容 = string.Empty;
            try
            {
                var fs = new FileStream(文件名, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                var myWriter = new StreamWriter(fs, 编码);
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