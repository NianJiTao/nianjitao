﻿using System;
using NJT.Core;
using Prism.Ioc;
using Prism.Logging;
using Prism.Mvvm;
using Prism.Regions;
using Unity;

namespace NJT.Prism
{
    public static class RunUnity
    {
        private static IRegionManager _行政部;


        public static I日志 Log { get; set; } = new NLog日志();

        public static IContainerRegistry Registry { get; set; }

        public static IUnityContainer Container1 { get; set; }

        public static IUnityContainer Container人事部
        {
            get => Container1;
            set => Container1 = value;
        }

        public static IRegionManager RegionManager行政部
        {
            get
            {
                if (_行政部 == null)
                {
                    var run = RunFunc.TryRun(() =>
                        Container1.Resolve<IRegionManager>());
                    _行政部 = run.IsTrue ? run.Data : new RegionManager();
                }

                return _行政部;
            }
            set => _行政部 = value;
        }


        public static ILoggerFacade CreateLogger()
        {
            return new Nlog2(Log);
        }


        /// <summary>
        ///     尝试用名称解析相关类型,失败返回 default(T);
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public static T Get<T>(string name)
        {
            var set1 = Container1.TryResolve2<T>(name);
            if (set1 == null)
            {
                Log.Error($"未用名称[{name}]注册类型[{nameof(T)}]");
                return default(T);
            }

            return set1;
        }


        public static T Get<T>()
        {
            var set1 = Container1.TryResolve2<T>("");
            if (set1 == null)
            {
                Log.Error($"未注册类型[{nameof(T)}]");
                return default(T);
            }

            return set1;
        }


        public static T TryResolveReturnNull<T>(this IUnityContainer container) where T : class
        {
            if (container == null)
                return null;
            if (!container.IsRegistered<T>())
                return null;
            return container.Resolve<T>();
        }


        /// <summary>
        ///     通过名称解析出T,如果未注册,返回默认值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="container">The container.</param>
        /// <param name="name">The name.</param>
        /// <returns>T.</returns>
        public static T TryResolve2<T>(this IUnityContainer container, string name)
        {
            if (container == null)
                return default(T);

            if (string.IsNullOrEmpty(name))
            {
                try
                {
                    return container.Resolve<T>();
                }
                catch (Exception)
                {
                    return default(T);
                }
            }

            if (!container.IsRegistered<T>(name))
                return default(T);

            return container.Resolve<T>(name);
        }


        /// <summary>
        ///     如果未注册,返回:默认返回值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="container"></param>
        /// <param name="name"></param>
        /// <param name="默认返回值"></param>
        /// <returns></returns>
        public static T TryResolve2<T>(this IUnityContainer container, string name, T 默认返回值)
        {
            if (container == null)
                return 默认返回值;

            if (string.IsNullOrEmpty(name))
                return 默认返回值;

            if (!container.IsRegistered<T>(name))
                return 默认返回值;

            return container.Resolve<T>(name);
        }


        /// <summary>
        ///     先尝试解析名称,再尝试解析不带名称.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="container"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static T TryResolve3<T>(this IUnityContainer container, string name)
        {
            if (container == null)
                return default(T);

            if (string.IsNullOrEmpty(name))
                return container.TryResolve2<T>("");

            if (!container.IsRegistered<T>(name))
                return container.TryResolve2<T>("");

            return container.Resolve<T>(name);
        }


        /// <summary>
        /// 尝试解析类型,错误时返回默认值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T TryResolve5<T>(this IUnityContainer obj)
        {
            if (obj == null) return default(T);
            try
            {
                return obj.Resolve<T>();
            }
            catch (Exception)
            {
                return default(T);
            }
        }


        /// <summary>
        ///     return new Lazy<T>(() => Container人事部.TryResolve2<T>(名称));
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="名称"></param>
        /// <returns></returns>
        public static Lazy<T> GetLazy延迟解析<T>(string 名称)
        {
            return new Lazy<T>(() => Container1.TryResolve2<T>(名称));
        }


        /// <summary>
        ///     读取已经注册的值,如有方法,就运行
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="值名称"></param>
        /// <param name="action1"></param>
        /// <returns></returns>
        public static I运行结果<T> 读取配置值<T>(string 值名称, Action<T> action1)
        {
            if (Container1 == null) return new 运行结果<T>(false, "解析器为空");
            if (!Container1.IsRegistered<T>(值名称)) return new 运行结果<T>(false, "值名称未注册");
            var r1 = Container1.Resolve<T>(值名称);
            action1?.Invoke(r1);
            return new 运行结果<T>(true) {Data = r1};
        }


        /// <summary>
        ///     注册View 调用什么vm类型,vm使用IUnityContainer解析
        /// </summary>
        /// <typeparam name="TView"></typeparam>
        /// <typeparam name="TViewModel"></typeparam>
        /// <param name="container"></param>
        public static void RegVm<TView, TViewModel>(this IUnityContainer container)
        {
            ViewModelLocationProvider.Register<TView>(() => container.Resolve<TViewModel>());
        }


        /// <summary>
        /// 解析类型,如果没有就注册为初始化值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="container1"></param>
        /// <param name="标识名"></param>
        /// <returns></returns>
        public static T ResolveOrInit<T>(this IUnityContainer container1, string 标识名) where T : new()
        {
            var reg = container1.IsRegistered<T>(标识名);
            if (!reg) container1.RegisterInstance<T>(标识名, new T());

            return container1.Resolve<T>(标识名);
        }


        /// <summary>
        /// 解析类型,如果没有就注册为 initFunc值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="container1"></param>
        /// <param name="标识名"></param>
        /// <param name="initFunc"></param>
        /// <returns></returns>
        public static T ResolveOrInit<T>(this IUnityContainer container1, string 标识名, Func<T> initFunc)
        {
            var reg = container1.IsRegistered<T>(标识名);
            if (!reg) container1.RegisterInstance<T>(标识名, initFunc());

            return container1.Resolve<T>(标识名);
        }
    }
}