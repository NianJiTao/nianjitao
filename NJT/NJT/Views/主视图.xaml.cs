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

namespace NJT.Views
{
    /// <summary>
    /// 主视图.xaml 的交互逻辑
    /// </summary>
    public partial class 主视图 : Window
    {
        public 主视图()
        {
            InitializeComponent();



            最小化隐藏();
           
        }

        private void 最小化隐藏()
        {
            StateChanged += (o, e) =>
            {
                switch (WindowState)
                {
                    case WindowState.Minimized:
                        ShowInTaskbar = false;
                        break;
                    case WindowState.Normal:
                        ShowInTaskbar = true;
                        break;
                    case WindowState.Maximized:
                        ShowInTaskbar = true;
                        break;

                }

            };
        }
    }
}
