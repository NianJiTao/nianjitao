using Xunit;
using LogCsv;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace LogCsv.Tests
{
    public class CsvRwTests
    {
        [Fact()]
        public void 共享写入Test()
        {
            var 文件名 = "d:\\temp\\" + DateTime.Now.ToString("yyyyMMddHH") + ".txt";

            var fs = new FileStream(文件名, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            var myWriter = new StreamWriter(fs, Encoding.Default);
            myWriter.Write("abc");


            var fs2 = new FileStream(文件名, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            var myWriter2 = new StreamWriter(fs2, Encoding.Default);
            myWriter2.Write("abc2");

            myWriter.Close();
            myWriter2.Close();
        }


        [Fact()]
        public void 写入Test()
        {
            var rw = new CsvRw();
            var a = new Csv内容()
            {
                设备名称 = "F2",
                文件名称 = "123456",
                内容 = new List<string>() { "时间,值", "1,2,3,4,5,6\r\n" },
            };


            rw.写入(a, "d:\\temp");
            var b = System.IO.File.Exists("d:\\temp\\F2\\"
                                          + DateTime.Now.ToString("yyyy-MM-dd")
                                          + "\\123456.csv");
            Assert.True(b, "写入的文件不存在");
        }

        [Fact()]
        public void 写入Test1()
        {
            var aa = "-f f2 -n 123 -c a`~1!2@3#4$5%6^7&8*9(0)-=_+\\|/?:;'<>   ";
            Parser.Default.ParseArguments<Csv内容>(aa.Split(new []{" "},StringSplitOptions.None))
                .WithParsed(x => { new CsvRw().写入(x, "d:\\temp"); });

              aa = "-f f2 -n 123 -c abc2    ";
            Parser.Default.ParseArguments<Csv内容>(aa.Split(new[] { " " }, StringSplitOptions.None))
                .WithParsed(x => { new CsvRw().写入(x, "d:\\temp"); });
        }
    }
}