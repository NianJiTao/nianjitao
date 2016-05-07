using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Unity;
using NJT.Common;
using NJT.Events;
using NJT.接口;
using Prism.Events;
using Prism.Logging;
using Prism.Regions;

namespace NJT.项目启动
{
    public class 系统初始化 : 启动基类
    {


        public 系统初始化(IUnityContainer 人事部cs, IEventAggregator 新闻部cs, IRegionManager 行政部cs)
            : base(人事部cs, 新闻部cs, 行政部cs)
        {
        }

        public override void 启动()
        {
            base.启动();

            //人事部.Resolve<I系统配置服务>().启动();

            log.Log("读取配置信息", Category.Info, Priority.Low);
            读取配置();

            log.Log("加载状态栏", Category.Info, Priority.Low);
            加载状态栏();


            人事部.Resolve<I消息服务>().启动();

            //人事部.Resolve<授权服务1>().启动();

            //新闻部.GetEvent<加载授权视图Event>().Subscribe(x => 加载授权视图(), true);

            //新闻部.GetEvent<加载钥匙视图Event>().Subscribe(x => 加载钥匙视图(), true);

            加载授权视图();


            log.Log("启动完毕", Category.Info, Priority.Low);
            新闻部.GetEvent<状态栏更新Event>().Publish(new 状态栏Data1("提示", " 启动完毕"));

            Application.Current.MainWindow.Closed += MainWindow_Closed;
        }
        private void MainWindow_Closed(object sender, EventArgs e)
        {
            新闻部.GetEvent<退出Event>().Publish(null);
        }

        private void 加载菜单栏()
        {
            //行政部.RegisterViewWithRegion("上", () =>
            //{
            //    var 视图2 = 人事部.Resolve<菜单>();
            //    视图2.LoadViewModel();
            //    return 视图2;
            //});
        }

        private void 加载状态栏()
        {
            //行政部.RegisterViewWithRegion(位置.下, () =>
            //{
            //    var 视图2 = 人事部.Resolve<状态栏>();
            //    视图2.LoadViewModel();
            //    return 视图2;
            //});
        }

        private void 读取配置()
        {
            //var 配置服务 = 人事部.Resolve<I系统配置服务>();
            //var 配置1 = 配置服务.读取();

            //小冰.更新资源("标题", 配置1.标题);
            //Telerik主题.设置主题(配置1.主题);
        }

        private void 加载钥匙视图()
        {
            //var 当前视图名称 = "钥匙视图";

            //var 内容区 = 行政部.Regions[位置.中];

            //if (!激活视图(内容区, 当前视图名称))
            //{
            //    var 视图1 = 人事部.Resolve<钥匙视图>();
            //    视图1.LoadViewModel();
            //    内容区.Add(视图1, 当前视图名称);
            //    内容区.Activate(视图1);
            //}


        }

        private void 加载授权视图()
        {
            //var 当前视图名称 = "授权视图";
            //var 内容区 = 行政部.Regions[位置.中];
            //if (!激活视图(内容区, 当前视图名称))
            //{
            //    var 视图1 = 人事部.Resolve<授权视图>();
            //    视图1.LoadViewModel();
            //    内容区.Add(视图1, 当前视图名称);
            //    内容区.Activate(视图1);
            //}
        }

        private bool 激活视图(IRegion 区域1, string 视图名称)
        {
            return 小冰.激活视图(区域1, 视图名称);
        }

    }
}
