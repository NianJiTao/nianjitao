using System.Windows;
using Prism.Mvvm;

namespace NJT.Views
{
    /// <summary>
    /// 消息窗口.xaml 的交互逻辑
    /// </summary>
    public partial class 消息窗口
    {
        public 消息窗口()
        {
            InitializeComponent();

        }
 

      


        private void Window_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
