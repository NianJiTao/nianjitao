using System.Windows.Media;
using NJT.Common;
using Prism.Mvvm;

namespace NJT.接口
{
    public interface I倒计时
    {
        int 数字 { get; set; }
        string 标题 { get; set; }
    }


    public class 倒计时1 : BindableBase, I倒计时
    {
        private int _数字 = 30;

        public int 数字
        {
            get { return _数字; }
            set { SetProperty(ref _数字, value); }
        }

        public string 标题 { get; set; } = "倒计时提醒";
    }
}