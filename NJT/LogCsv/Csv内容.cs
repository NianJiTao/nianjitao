using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace LogCsv
{
    public class Csv内容
    {
        [Value(0, HelpText = "其他值")] public IEnumerable<string> 其他值 { get; set; }

        [Option('i', "insert", Default = "false", Required = false, HelpText = "是否插入到首行")]
        public bool 插入首行 { get; set; }

        [Option('f', "furnace", Default = "F1", Required = true, HelpText = "设备名称")]
        public string 设备名称 { get; set; }

        [Option('n', "name", Default = "xcg001", Required = true, HelpText = "文件名称")]
        public string 文件名称 { get; set; }

        [Option('c', "content", Required = true, HelpText = "文本内容")]
        public IEnumerable<string> 内容 { get; set; }
    }
}