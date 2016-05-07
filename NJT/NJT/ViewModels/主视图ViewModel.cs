using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Prism.Commands;

namespace NJT.ViewModels
{
    public class 主视图ViewModel
    {
        public 主视图ViewModel()
        {
            显示Command = new DelegateCommand<object>(显示Action);
            退出Command = new DelegateCommand<object>(退出Action);
        }


        public ICommand 显示Command { get; set; }
        public ICommand 退出Command { get; set; }

        private void 退出Action(object obj)
        {
            Application.Current.Shutdown();
        }

        private void 显示Action(object obj)
        {
            Application.Current.MainWindow.WindowState = WindowState.Normal;
        }

    }
}
