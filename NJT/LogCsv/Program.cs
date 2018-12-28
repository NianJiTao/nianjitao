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