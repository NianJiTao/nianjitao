using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace LogCsv
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length==0)
                {
                    //logcsv.exe - f f1 - n abc - c 时间,温度1,温度2
                }
                Parser.Default.ParseArguments<Csv内容>(args)
                    .WithParsed(x => { new CsvRw().写入(x, Properties.Settings.Default.输出目录); });
            }
            catch (Exception)
            {
                //Console.WriteLine(e);
                //throw;
            }
        }
    }
}