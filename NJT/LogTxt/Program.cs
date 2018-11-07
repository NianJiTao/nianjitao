using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LogTxt
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var file = GetFileName();
            var 内容 = Get内容(args);
            if (!File.Exists(file))
                内容 = Get内容(new[] {Properties.Settings.Default.文件首行}) + 内容;

            序列化.写入txt(file, 内容, true);
        }

        private static string Get内容(string[] args)
        {
            var 内容 = DateTime.Now.ToString(Properties.Settings.Default.内容前缀) + " ";
            if (args != null)
                内容 += string.Join(" ", args) + "\r\n";

            return 内容;
        }

        private static string GetFileName()
        {
            var dir = Properties.Settings.Default.日志目录;
            目录文件.检查并建立目录(dir);
            var file = DateTime.Now.ToString(Properties.Settings.Default.文件前缀);
            file += Properties.Settings.Default.文件后缀;
            var file2 = Path.Combine(dir, file);
            return file2;
        }
    }
}