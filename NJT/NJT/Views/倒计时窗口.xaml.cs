using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
 
using Prism.Mvvm;
using Microsoft.Practices.Unity;
using NJT.ViewModels;
using NJT.接口;

namespace NJT.Views
{
    /// <summary>
    /// 倒计时窗口.xaml 的交互逻辑
    /// </summary>
    public partial class 倒计时窗口 : Window, I倒计时窗口
    {

        public 倒计时窗口()
        {
            InitializeComponent();
        }

      

        private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            关闭();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private 倒计时窗口ViewModel 业务2;
        public void 启动(I倒计时 倒计时)
        {
            业务2 = 小冰.人事部.Resolve<倒计时窗口ViewModel>();
            业务2.参数 = 倒计时;
            业务2.倒计时结束 += 业务2_倒计时结束;
            业务2.启动();
            this.DataContext = 业务2;
            this.Show();

        }

        void 业务2_倒计时结束(object sender, EventArgs e)
        {
            this.Close();
        }

        public void 关闭()
        {
            if (业务2 != null) 业务2.关闭();
        }
    }
}