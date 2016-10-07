using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Mvvm;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using NJT.Common;
using NJT.Services;
using NJT.扩展;
using NJT.接口;
using Prism.Logging;
using Prism.Modularity;
using Prism.Unity;

namespace NJT.项目启动
{
    public class 启动器 : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            //var 视图1 = ServiceLocator.Current.GetInstance<主窗口>();
            //return 视图1;

            return null;
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            Application.Current.MainWindow = (Window)Shell;
            //(Shell as IView)?.LoadViewModel();
            Application.Current.MainWindow.Show();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            var 模块管理中心 = new ModuleCatalog();
            return 模块管理中心;
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();
            小冰.Set默认解析器();
            var moduleCatalog = (ModuleCatalog)ModuleCatalog;
            moduleCatalog.AddModule(typeof(启动模块));
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            Container.RegisterType<ILoggerFacade, NLog日志>(new ContainerControlledLifetimeManager());

            //Container.RegisterType<I系统配置服务, 系统配置服务1>(new ContainerControlledLifetimeManager());

            Container.RegisterType<I消息服务, 消息服务1>(new ContainerControlledLifetimeManager());
        }
    }
}
