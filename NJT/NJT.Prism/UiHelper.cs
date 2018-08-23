﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Threading;
using CommonServiceLocator;
using NJT.Core;
using Prism.Events;
using Prism.Regions;
using Prism.Unity;
using Unity;

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
            get => _ui线程 ?? (_ui线程 = Application.Current.MainWindow?.Dispatcher);
            set => _ui线程 = value;
        }

        public static string 当前目录 => AppDomain.CurrentDomain.BaseDirectory;

      

        public static void 更新资源(object key, object 内容)
        {
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

        #region 弹出窗口

        public static void 弹出窗口<T>()
        {
            if (!(Container人事部.TryResolve<IView弹出窗口>() is Window win))
                return;
            var view = Container人事部.TryResolve<T>();
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
            var view = Container人事部.TryResolve<T>();
            弹出窗口(view, xy, top);
        }


        public static void 弹出窗口(object view, Point xy, bool top = true)
        {
            if (!(Container人事部.TryResolve<IView弹出窗口>() is Window win))
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

        public static T 启动服务<T>(IUnityContainer 人事部cs, I日志 log) where T : I启动
        {
            Debug.Assert(人事部cs != null, "UnityContainer != null");
            var 解析 = 人事部cs.Resolve<T>();
            if (解析 != null)
            {
                服务列表.Add(解析);
                解析.启动();
                return 解析;
            }
            else
            {
                log?.Error($"{nameof(T)}解析失败");
                return default(T);
            }
        }

        #endregion
    }
}