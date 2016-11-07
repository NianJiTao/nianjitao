using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 英文单词提取
{
    public class 配置
    {

        public bool 排除熟词本 { get; set; } = true;

        public bool 区分大小写 { get; set; } = false;

        public int 最小单词长度 { get; set; } = 2;


    }
}
