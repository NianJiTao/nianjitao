using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Microsoft.Toolkit.Uwp.UI.Controls;
using 年纪涛.简介.ViewModels;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace 年纪涛.简介.Views
{
    /// <summary>
    ///     可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class 汉堡导航Page : Page  
    {
        public 汉堡导航Page()
        {
            InitializeComponent();
            DataContextChanged += (s, e) => VM.Data = this.DataContext as 汉堡导航PageViewModel;
        }
        public void SetContentFrame(Frame 导航Frame)
        {
            HamburgerMenu.Content = 导航Frame;
        }

        public Vm<汉堡导航PageViewModel> VM { get; } = new Vm<汉堡导航PageViewModel>();

    }
}