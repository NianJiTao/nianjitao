using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Core
{
    public interface I日志记录
    {
        DateTime 时间 { get; set; }
        string 记录 { get; set; }

        /// <summary>
        /// 通过标识来分类,可以订阅事件时候过滤记录
        /// </summary>
        /// <value>The 标识.</value>
        string 标识 { get; set; }


        string 类型 { get; set; }
        int 级别 { get; set; }

    }

    public class 日志记录1 : I日志记录
    {
        public 日志记录1(string text)
        {
            时间 = DateTime.Now;
            记录 = text;
        }
        public 日志记录1(string text, string 标识1)
        {
            时间 = DateTime.Now;
            记录 = text;
            标识 = 标识1;
        }

        public DateTime 时间 { get; set; }
        public string 记录 { get; set; }
        public string 标识 { get; set; } = string.Empty;
        public string 类型 { get; set; } = string.Empty;
        public int 级别 { get; set; } = 0;
    }
}
