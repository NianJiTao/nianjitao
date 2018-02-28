using CommonServiceLocator;
using NJT.Core;
using Prism.Events;
using Prism.Regions;
using Prism.Unity;
using Unity;

namespace NJT.Prism
{
    public static class RunUnity
    {
        private static IUnityContainer _人事部;

        private static IEventAggregator _宣传部;

        private static IRegionManager _行政部;

        public static I日志 Log { get; set; } = new NLog日志();

        public static IUnityContainer Container人事部
        {
            get => _人事部;
            set => _人事部 = value;
        }

        public static IEventAggregator EventAggregator宣传部
        {
            get
            {
                if (_宣传部 == null)
                {
                    var run = RunFunc.TryRun(() =>
                        Container人事部.Resolve<IEventAggregator>());
                    _宣传部 = run.IsTrue ? run.Data : new EventAggregator();
                }
                return _宣传部;
            }
            set => _宣传部 = value;
        }

        public static IRegionManager RegionManager行政部
        {
            get
            {
                if (_行政部 == null)
                {
                    var run = RunFunc.TryRun(() =>
                        Container人事部.Resolve<IRegionManager>());
                    _行政部 = run.IsTrue ? run.Data : new RegionManager();
                }
                return _行政部;
            }
            set => _行政部 = value;
        }



        /// <summary>
        /// 尝试用名称解析相关类型,失败返回 default(T);
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public static T Get<T>(string name)
        {
            var set1 = RunUnity.Container人事部.TryResolve2<T>(name);
            if (set1==null)
            {
                RunUnity.Log.Error($"未用名称[{name}]注册类型[{nameof(T)}]");
                return default(T);
            }
            return set1;
        }

        public static T Get<T>()
        {
            var set1 = RunUnity.Container人事部.TryResolve <T>();
            if (set1 == null)
            {
                RunUnity.Log.Error($"未注册类型[{nameof(T)}]");
                return default(T);
            }
            return set1;
        }

        /// <summary>
        ///  通过名称解析出T,如果未注册,返回默认值
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
                return container.TryResolve<T>();

            if (!container.IsRegistered<T>(name))
                return default(T);

            return container.Resolve<T>(name);
        }
        /// <summary>
        /// 如果未注册,返回:默认返回值
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
    }
}