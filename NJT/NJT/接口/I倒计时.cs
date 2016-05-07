using System.Windows.Media;
using NJT.Common;

namespace NJT.接口
{
    public interface I倒计时
    {
        int 数字 { get; set; }
        string 标题 { get; set; }
    }


    public class 倒计时1 : Vm基类<int>, I倒计时
    {
        private int _数字;

        public 倒计时1()
        {
            数字 = 30;
            标题 = "倒计时提醒";
        }

        public int 数字
        {
            get { return _数字; }
            set { SetProperty(ref _数字, value); }
        }

        public string 标题 { get; set; }
    }
}