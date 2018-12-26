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

            Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(o =>
                {
                    Console.WriteLine($" 设备： {o.设备名称.First()}");
                    Console.WriteLine($" 文件： {o.文件名称}");
                    Console.WriteLine($" 内容： {o.内容}");
                    Console.ReadLine();
                });
        }
    }
}
