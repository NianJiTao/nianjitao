using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Core
{
    public interface  I星期信息:I选中
    {
        int 数字 { get; set; }
        string 中文 { get; set; }
        DayOfWeek 英文 { get; set; }

    }
    public class 星期信息1: I星期信息
    {

        public 星期信息1()
        {

        }
        public 星期信息1(int 数字cs, string 中文cs, DayOfWeek 英文cs, bool 选中cs)
        {
            数字 = 数字cs;
            中文 = 中文cs;
            英文 = 英文cs;
            Is选中 = 选中cs;
        }

        public int 数字 { get; set; }

        public string 中文 { get; set; }

        public DayOfWeek 英文 { get; set; }

        public bool Is选中 { get; set; }
    }
}
