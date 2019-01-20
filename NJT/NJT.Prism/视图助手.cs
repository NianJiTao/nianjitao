using System;
using System.Windows;
using NJT.Core;
using Prism.Events;
using Prism.Regions;
using Prism.Unity;
using Unity;

namespace NJT.Prism
{
    public class 视图助手
    {
        private static bool _errorShow;
        private static IEventAggregator EventAggregator宣传部 => RunUnity.EventAggregator宣传部;
        private static IUnityContainer Container人事部 => RunUnity.Container人事部;
        private static IRegionManager RegionManager行政部 => RunUnity.RegionManager行政部;


        public static Window 解析win<T>()
        {
            try
            {
                var win = Container人事部.TryResolve<T>();
                var shell = win as Window;
                if (shell != null)
                {
                    UiHelper.UiDispatcher线程 = shell.Dispatcher;
                    shell.Closed += (s, e) =>
                    {
                        RunUnity.Log.Info("程序关闭,通知各单位退出.");
                        EventAggregator宣传部.GetEvent<Event退出>().Publish();
                    };
                }

                return shell;
            }
            catch (Exception e)
            {
                var error = $"源:{e.Source}\r\n消息:{e.Message}\r\n栈:{e.StackTrace}";
                MessageBox.Show(error);
                return null;
            }
        }


        public static void 加载主视图()
        {
            var view = Container人事部.TryResolve<IView主视图>();
            if (view != null)
            {
                RegionManager行政部.AddToRegion("Main", view);
                RegionManager行政部.Regions["Main"].Activate(view);
            }

            RegionManager行政部.RequestNavigate(位置.下, 位置.View.状态栏视图);
            RegionManager行政部.RequestNavigate(位置.上, 位置.View.菜单视图);
        }


        public static void 导航到(string 视图名称x, string 区域 = "中")
        {
            if (string.IsNullOrEmpty(视图名称x) || string.IsNullOrEmpty(区域))
                return;
            RunUnity.Log.Info($"导航到:{视图名称x}");
            RegionManager行政部.RequestNavigate(区域, 视图名称x);
        }


        public static void 导航到(string 视图名称x, string 区域, Action<NavigationResult> 回调方法, NavigationParameters 参数)
        {
            if (string.IsNullOrEmpty(视图名称x) || string.IsNullOrEmpty(区域))
                return;
            RunUnity.Log.Info($"导航到:{视图名称x}");
            RegionManager行政部.RequestNavigate(区域, 视图名称x, 回调方法, 参数);
        }


        public static void ShowError(Exception eException)
        {
            if (eException == null) return;
            if (_errorShow) return;
            _errorShow = true;
            var error = $"源:{eException.Source}\r\n消息:{eException.Message}\r\n栈:{eException.StackTrace}";
            MessageBox.Show(error);
            _errorShow = false;
        }


        public static void 导航到(string 视图名称x, NavigationParameters 参数)
        {
            导航到(视图名称x, "中", x => { }, 参数);
        }
    }
}