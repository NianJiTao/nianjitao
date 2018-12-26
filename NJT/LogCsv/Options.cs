using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace LogCsv
{
    public class Options
    {
        [Value(0, HelpText = "一个 .sln 文件，一个或者多个 .csproj 文件。")]
        public IEnumerable<string> InputFiles { get; set; }

        [Option('f', "fu", Required = false  , HelpText = "设备名称")]
        public IEnumerable<string> 设备名称 { get; set; }

        [Option('n', "name", Required = false, HelpText = "文件名称")]
        public string 文件名称 { get; set; }

        [Option('c', "content", Required = false, HelpText = "文本内容")]
        public string 内容 { get; set; }
    }

}
