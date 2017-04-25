using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Threading;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using NJT.Core;
using Prism.Events;
using Prism.Regions;

namespace NJT.Prism
{
    public static class UiHelper
    {
        private static Dispatcher _ui线程;
        private static I日志 Log => RunUnity.Log;
        private static IUnityContainer Container人事部 => RunUnity.Container人事部;
        private static IEventAggregator EventAggregator宣传部 => RunUnity.EventAggregator宣传部;
        private static IRegionManager RegionManager行政部 => RunUnity.RegionManager行政部;


        public static Window Win => Application.Current.MainWindow;

        public static Dispatcher UiDispatcher线程
        {
            get => _ui线程 ?? (_ui线程 = Application.Current.MainWindow.Dispatcher);
            set => _ui线程 = value;
        }

        public static string 当前目录 => AppDomain.CurrentDomain.BaseDirectory;

        private static IServiceLocator Locator => ServiceLocator.Current;
        public static object 导出表格 { get; set; }

        public static void 更新资源(object key, object 内容)
        {
            var res = Application.Current.Resources;
            if (res.Contains(key))
                res.Remove(key);
            res.Add(key, 内容);
        }

        public static void RunAtUi(Action 方法, bool 异步)
        {
            if (异步)
                UiDispatcher线程.InvokeAsync(() =>
                    RunFunc.TryRun(方法));
            else
                UiDispatcher线程.Invoke(() => RunFunc.TryRun(方法));
        }


        public static string Get文件名(string 配置文件)
        {
            var path1 = 当前目录;
            var path2 = 配置文件;
            var run = RunFunc.TryRun(() => Path.Combine(path1, path2));
            return run.IsTrue ? run.Data : path2;
        }


        public static void 弹出窗口<T>()
        {
            var win = GetWin<IView弹出窗口>();
            if (win == null)
                return;
            var view = Locator.GetInstance<T>();
            win.DataContext = view;
            win.ShowDialog();
        }

        /// <summary>
        ///     point 弹出窗口大小.
        ///     top 是否置顶.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xy"></param>
        public static void 弹出窗口<T>(Point xy, bool top = true)
        {
            var win = GetWin<IView弹出窗口>();
            if (win == null)
                return;
            var view = Locator.GetInstance<T>();
            win.DataContext = view;

            win.Width = xy.X;
            win.Height = xy.Y;
            if (top)
                win.ShowDialog();
            else
                win.Show();
        }


        public static void 弹出窗口(object view, Point xy, bool top = true)
        {
            var win = GetWin<IView弹出窗口>();
            if (win == null)
                return;
            win.DataContext = view;
            win.Width = xy.X;
            win.Height = xy.Y;
            if (top)
                win.ShowDialog();
            else
                win.Show();
        }

        public static Window GetWin<T>()
        {
            Debug.Assert(null != Locator, "解析器不能为空,请先初始化");
            if (null == Locator)
            {
                Log?.Error("解析器为空,无法弹出窗口");
                return null;
            }

            var win = Locator.GetInstance<T>();
            var win2 = win as Window;
            return win2;
        }

        #region 启动服务

        public static void 启动服务<T>() where T : I启动
        {
            启动服务<T>(Container人事部, Log);
        }

        public static void 启动服务<T>(IUnityContainer 人事部cs) where T : I启动
        {
            启动服务<T>(人事部cs, Log);
        }

        public static void 启动服务<T>(IUnityContainer 人事部cs, I日志 log) where T : I启动
        {
            Debug.Assert(人事部cs != null, "UnityContainer != null");
            var 解析 = 人事部cs.Resolve<T>();
            if (解析 != null)
                解析.启动();
            else
                log?.Error($"{nameof(T)}解析失败");
        }

        #endregion

        #region 激活视图

        public static 运行结果<object> 激活视图(IRegion 地区, string 视图名称)
        {
            var 视图1 = 地区.GetView(视图名称);
            if (视图1 == null)
                return new 运行结果<object>(false, $"{视图名称}_未找到");
            地区.Activate(视图1);
            return new 运行结果<object>(true) {Data = 视图1};
        }

        /// <summary>
        ///     在区域位置上,激活视图T,视图名称为唯一定位字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="区域位置">The 区域位置.</param>
        /// <param name="视图名称">The 视图名称.</param>
        public static void 激活视图T2<T>(string 区域位置, string 视图名称)
        {
            Log?.Info($"激活{视图名称}");
            var 地区 = 查找地区(RegionManager行政部, 区域位置);
            if (地区 != null)
                激活视图T<T>(地区, 视图名称);
        }

        public static void 激活视图T<T>(IRegion 地区, string 视图名称, string 接口名称 = "")
        {
            Debug.Assert(地区 != null, "地区 != null");
            Debug.Assert(EventAggregator宣传部 != null, "EventAggregator  != null");

            var 激活信息 = 激活视图(地区, 视图名称);
            if (激活信息.IsTrue)
                EventAggregator宣传部.GetEvent<Event激活视图>().Publish(视图名称);
            else
                try
                {
                    var 视图2 = string.IsNullOrEmpty(接口名称)
                        ? Container人事部.Resolve<T>()
                        : Container人事部.Resolve<T>(接口名称);

                    地区.Add(视图2, 视图名称);
                    地区.Activate(视图2);
                }
                catch (Exception exc)
                {
                    Log?.Error($"解析类型出错:{exc.Message}");
                }
        }

        /// <summary>
        ///     根据区域名称,直接注册或者激活T类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="视图位置"></param>
        /// <param name="视图名称"></param>
        public static void 激活视图2<T>(string 视图位置, string 视图名称)
        {
            var 地区 = 查找地区(RegionManager行政部, 视图位置);
            if (地区 != null)
                激活视图T<T>(地区, 视图名称);
        }

        public static bool 隐藏视图(IRegion 地区, string 视图名称)
        {
            var 视图1 = 地区.GetView(视图名称);
            if (视图1 == null)
                return false;
            地区.Deactivate(视图1);
            return true;
        }

        public static object 查找视图(IRegion 地区, string 视图名称)
        {
            return 地区.GetView(视图名称);
        }

        public static IRegion 查找地区(IRegionManager 地区, string 地区名称)
        {
            var find = 地区.Regions.FirstOrDefault(x => x.Name == 地区名称);
            if (find == null)
                Log.Error($"未注册[{地区名称}]区域");
            return find;
        }

        #endregion
    }
}