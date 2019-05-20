using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Media;

namespace NJT.Core
{
    public interface IView弹出消息 : IView
    {
        I弹出消息 消息 { set; }
    }
    public interface I弹出消息
    {
        string 显示文字 { get; set; }
        int 显示毫秒 { get; set; }
        double 字体大小 { get; set; }
        string 字体颜色 { get; set; }
    }

    public class 弹出消息1 : I弹出消息
    {
        public string 显示文字 { get; set; } = "没什么事";
        public int 显示毫秒 { get; set; } = 2000;
        public double 字体大小 { get; set; } = 64;
        public string 字体颜色 { get; set; } = "Green";
    }
}
