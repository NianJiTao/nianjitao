using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Prism.Logging;
using Prism.Unity.Windows;
using Prism.Windows.AppModel;
using Prism.Windows.Navigation;
using 年纪涛.简介.Views;
using Microsoft.Practices.Unity;

namespace 年纪涛.简介
{
    /// <summary>
    /// 提供特定于应用程序的行为，以补充默认的应用程序类。
    /// </summary>
    sealed partial class App : PrismUnityApplication
    {
      
        public App()
        {
            this.InitializeComponent();
        }


        protected override UIElement CreateShell(Frame rootFrame)
        {
            var shell = Container.Resolve<汉堡导航Page>();
            shell.SetContentFrame(rootFrame);
            return shell;
        }


        protected override Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
        {
            NavigationService.Navigate("个人信息", null);
            Window.Current.Activate();
            return Task.FromResult(true);
        }

 

        protected override ILoggerFacade CreateLogger()
        {
            return base.CreateLogger();
        }


        
    }
}
