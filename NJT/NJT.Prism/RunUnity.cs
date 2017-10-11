using CommonServiceLocator;
using Microsoft.Practices.Unity;
using NJT.Core;
using Prism.Events;
using Prism.Regions;

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
            get
            {
                if (_人事部 == null)
                {
                    var run = RunFunc.TryRun(() =>
                        ServiceLocator.Current.GetInstance<IUnityContainer>());
                    _人事部 = run.IsTrue ? run.Data : new UnityContainer();
                }
                return _人事部;
            }
            set => _人事部 = value;
        }

        public static IEventAggregator EventAggregator宣传部
        {
            get
            {
                if (_宣传部 == null)
                {
                    var run = RunFunc.TryRun(() =>
                        ServiceLocator.Current.GetInstance<IEventAggregator>());
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
                        ServiceLocator.Current.GetInstance<IRegionManager>());
                    _行政部 = run.IsTrue ? run.Data : new RegionManager();
                }
                return _行政部;
            }
            set => _行政部 = value;
        }


        public static bool IsRunTime { get; set; } = false;


        /// <summary>
        /// 尝试用名称解析相关类型,失败返回 default(T);
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public static T Get<T>(string name)
        {
            var set1 = RunUnity.Container人事部.TryResolve2<T>(name);
            if (!set1.IsTrue)
            {
                RunUnity.Log.Error($"未用名称[{name}]注册类型[{nameof(T)}]");
                return default(T);
            }
            return set1.Data;
        }

        public static T Get<T>()
        {
            var set1 = RunUnity.Container人事部.TryResolve2<T>();
            if (!set1.IsTrue)
            {
                RunUnity.Log.Error($"未注册类型[{nameof(T)}]");
                return default(T);
            }
            return set1.Data;
        }
    }
}