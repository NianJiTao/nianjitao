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
using 年纪涛.简介.ViewModels;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace 年纪涛.简介.Views
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class 联系Page : Page
    {
        public 联系Page()
        {
            this.InitializeComponent();
            DataContextChanged += (s, e) => VM.Data = this.DataContext as 联系PageViewModel;

        }

        public Vm<联系PageViewModel> VM { get; } = new Vm<联系PageViewModel>();

    }
}
