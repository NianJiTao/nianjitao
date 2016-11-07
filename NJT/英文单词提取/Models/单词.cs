using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 英文单词提取
{
    public class 单词
    {

        public string 名称 { get; set; } = string.Empty;

        public char 首字母 { get; set; } 

        public int 长度 => 名称.Length;

        public int 频率 { get; set; }

        public string 中文 { get; set; }


        //http://cn.bing.com/dict/search?q=Debugger
    }
}
