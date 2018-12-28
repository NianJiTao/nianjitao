using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogCsv
{
    public class CsvRw
    {
        /// <summary>
        /// 写入内容到csv文件
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="输出目录"></param>
        public void 写入(Csv内容 obj, string 输出目录)
        {
            优化内容(obj);
            var dir1 = 输出目录;
            if (!检查目录(dir1)) return;
            var dir2 = System.IO.Path.Combine(dir1, obj.设备名称);
            if (!检查目录(dir2)) return;
            var dir3 = System.IO.Path.Combine(dir2, DateTime.Now.ToString("yyyy-MM-dd"));
            if (!检查目录(dir3)) return;
            var dir4 = System.IO.Path.Combine(dir3, obj.文件名称);

            var filename = dir4;
            var str = string.Join(" ", obj.内容);
            if (!(str.EndsWith("\r\n"))) str += "\r\n";
            序列化.写入txt(filename, str);
        }


        private void 优化内容(Csv内容 csv内容)
        {
            if (csv内容 == null) return;
            if (string.IsNullOrEmpty(csv内容.设备名称)) csv内容.设备名称 = "F1";
            if (string.IsNullOrEmpty(csv内容.文件名称)) csv内容.文件名称 = "xcg";
            if (!(csv内容.文件名称.EndsWith(".csv"))) csv内容.文件名称 += ".csv";
            if (csv内容.内容 == null || !csv内容.内容.Any()) csv内容.内容 = new List<string>() {""};
            if (csv内容.插入时间)
            {
                var a = csv内容.内容.ToList();
                a.Insert(0, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ",");
                csv内容.内容 = a;
            }
        }


        private bool 检查目录(string dir1)
        {
            if (!System.IO.Directory.Exists(dir1))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(dir1);
                }
                catch (Exception)
                {
                    //Console.WriteLine(e);
                    //throw;
                }
            }
            else
            {
                return true;
            }

            return System.IO.Directory.Exists(dir1);
        }
    }
}