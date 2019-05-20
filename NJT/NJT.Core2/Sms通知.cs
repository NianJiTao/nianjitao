using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Core
{
    public class Sms通知
    {
        public Sms通知()
        {
        }
        public Sms通知(string 主标题x)
        {
            主标题 = 主标题x;
        }
        public Sms通知(string 主标题x, string 副标题x)
        {
            主标题 = 主标题x;
            副标题 = 副标题x;
        }
        public Sms通知(string 主标题x, string 副标题x, string 内容x)
        {
            主标题 = 主标题x;
            副标题 = 副标题x;
            内容 = 内容x;
        }
        public string 主标题 { get; set; } = string.Empty;
        public string 副标题 { get; set; } = string.Empty;
        public string 内容 { get; set; } = string.Empty;
    }
}
