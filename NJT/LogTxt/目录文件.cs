using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LogTxt
{
    public class 目录文件
    {
        public static void 检查并建立目录(string dir)
        {
            if (string.IsNullOrEmpty(dir))
                return;
            try
            {
                if (Directory.Exists(dir))
                    return;
                Directory.CreateDirectory(dir);
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
