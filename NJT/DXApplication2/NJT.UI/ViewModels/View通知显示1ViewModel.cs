using System.Windows.Media;
using DevExpress.Mvvm;

namespace NJT.UI.ViewModels
{
    public class View通知显示1ViewModel : ViewModelBase
    {
        public View通知显示1ViewModel()
        {
            内容 = "有事发生";
            标题 = "通知";
            背景 = Brushes.Black;
        }


        public string 标题
        {
            get { return GetProperty(() => 标题); }
            set { SetProperty(() => 标题, value); }
        }


        public string 内容
        {
            get { return GetProperty(() => 内容); }
            set { SetProperty(() => 内容, value); }
        }

        public Brush 背景
        {
            get { return GetProperty(() => 背景); }
            set { SetProperty(() => 背景, value); }
        }


        public FontFamily 字体
        {
            get { return GetProperty(() => 字体); }
            set { SetProperty(() => 字体, value); }
        }
    }
}