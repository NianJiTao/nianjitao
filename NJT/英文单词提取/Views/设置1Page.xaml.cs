﻿using Windows.UI.Xaml.Controls;
using 英文单词提取.ViewModels;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace 英文单词提取.Views
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class 设置1Page : Page
    {
        public 设置1Page()
        {
            this.InitializeComponent();
            DataContextChanged += (s, e) => VM.Data = this.DataContext as 设置1PageViewModel;
        }

        public Vm<设置1PageViewModel> VM { get; } = new Vm<设置1PageViewModel>();
    }
}
