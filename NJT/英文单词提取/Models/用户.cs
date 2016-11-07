using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 英文单词提取
{
    public class 用户
    {
        public string 名称 { get; set; } = "默认用户";

        public HashSet<string> 生词本 { get; set; } =new HashSet<string>();

        public HashSet<string> 熟词本 { get; set; }=new HashSet<string>();



    }
}
