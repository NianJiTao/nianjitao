using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using 英文单词提取.ViewModels;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace 英文单词提取.Views
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class 导航1Page : Page
    {
        public 导航1Page()
        {
            this.InitializeComponent();
            DataContextChanged += (s, e) => VM.Data = this.DataContext as 导航1PageViewModel;

            //this.DataContext = new 导航1PageViewModel();
        }

        public Vm<导航1PageViewModel> VM { get; } = new Vm<导航1PageViewModel>();

        public void SetContentFrame(Frame 导航Frame)
        {
            HamburgerMenu.Content = 导航Frame;
        }

    }
}
