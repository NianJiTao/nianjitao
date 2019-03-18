using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Threading;
using NJT.Core;
using Unity;

namespace NJT.Prism
{
    public static class UiHelper
    {
        private static Dispatcher _ui线程;
        private static I日志 Log => RunUnity.Log;
        private static IUnityContainer Container人事部 => RunUnity.Container人事部;
        private static IUnityContainer Container1 => RunUnity.Container人事部;


        public static Window Win => Application.Current.MainWindow;

        public static Dispatcher UiDispatcher线程
        {
            get => _ui线程 ?? (_ui线程 = Win?.Dispatcher);
            set => _ui线程 = value;
        }

        public static string 当前目录 => AppDomain.CurrentDomain.BaseDirectory;


        public static void 更新资源(object key, object 内容)
        {
            if (key == null)
                return;
            var res = Application.Current.Resources;
            if (res.Contains(key))
                res.Remove(key);
            res.Add(key, 内容);
        }


        public static void RunAtUi(Action 方法, bool 异步)
        {
            if (UiDispatcher线程 == null)
                RunFunc.TryRun(方法);
            else if (异步)
                UiDispatcher线程.InvokeAsync(() => RunFunc.TryRun(方法));
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


        public static I运行结果<T> 启动服务<T>() where T : I启动
        {
            return 启动服务<T>(Container人事部, RunUnity.Log);
        }


        public static I运行结果<T> 启动服务<T>(string 名称) where T : I启动
        {
            if (Container人事部 == null) return new 运行结果<T>(false, "解析器为空");
            if (string.IsNullOrEmpty(名称)) return 启动服务<T>(Container人事部, RunUnity.Log);

            if (Container人事部.IsRegistered<T>(名称) == false) return new 运行结果<T>(false);

            var 解析 = Container人事部.Resolve<T>(名称);
            if (解析 != null)
            {
                服务列表.Add(解析);
                解析.启动();
                return new 运行结果<T>(true) {Data = 解析};
            }

            return new 运行结果<T>(false);
        }


        public static bool? 打开弹出窗口<T>(string 标题)
        {
            var 弹出 = Container人事部?.TryResolve2<IView弹出窗口>("");
            if (!(弹出 is Window t))
                return false;
            t.SizeToContent = SizeToContent.WidthAndHeight;
            t.WindowStyle = WindowStyle.ToolWindow;
            var win2 = Container人事部.TryResolve2<T>("");
            if (win2 == null)
                return false;
            弹出.DataContext = win2;
            t.Title = 标题;
            return t.ShowDialog();
        }


        public static 配置读写<T> Get配置读写<T>(string 配置目录)
        {
            var fileName = Path.Combine(Get文件名(配置目录), typeof(T).Name + ".config");
            var r = new 配置读写<T>(fileName);
            return r;
        }


        #region 弹出窗口

        public static void 弹出窗口<T>()
        {
            if (!(Container人事部.TryResolve2<IView弹出窗口>("") is Window win))
                return;
            var view = Container人事部.TryResolve2<T>("");
            弹出窗口(win, view, true);
        }


        /// <summary>
        ///     point 弹出窗口大小.    top 是否置顶.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xy">  弹出窗口大小.</param>
        /// <param name="top">  是否置顶.</param>
        public static void 弹出窗口<T>(Point xy, bool top = true)
        {
            var view = Container人事部.TryResolve2<T>("");
            弹出窗口(view, xy, top);
        }


        public static void 弹出窗口(object view, Point xy, bool top = true)
        {
            if (!(Container人事部.TryResolve2<IView弹出窗口>("") is Window win))
                return;
            win.Width = xy.X;
            win.Height = xy.Y;
            弹出窗口(win, view, top);
        }


        public static void 弹出窗口(Window win, object vm, bool top = true)
        {
            if (null == win)
                return;
            win.DataContext = vm;
            if (top)
                win.ShowDialog();
            else
                win.Show();
        }

        #endregion


        #region 启动服务

        public static List<object> 服务列表 = new List<object>();


        public static I运行结果<T> 启动服务<T>(IUnityContainer 人事部cs, I日志 log) where T : I启动
        {
            if (人事部cs == null) return new 运行结果<T>(false, "解析器为空");
            var 解析 = 人事部cs.TryResolve2<T>("");
            if (解析 != null)
            {
                服务列表.Add(解析);
                解析.启动();
                return new 运行结果<T>(false) {Data = 解析};
            }

            var info = $"{nameof(T)}解析失败";
            log?.Error(info);
            return new 运行结果<T>(false, info);
        }

        #endregion
    }
}