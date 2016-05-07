using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Mvvm;
using Prism.Events;
using Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using NJT.Events;
using NJT.接口;
using System.Windows;
using System.Windows.Threading;
using NJT.Common;
using Prism.Logging;

namespace NJT
{
    /// <summary>
    /// 程序常用静态方法类
    /// </summary>
    public static class 小冰
    {
        private static IUnityContainer _人事部;

        private static IEventAggregator _宣传部;

        private static IRegionManager _行政部;

        private static Dispatcher _ui线程;

        private static Dictionary<string, dynamic> 缓存Dict = new Dictionary<string, dynamic>();
        private static ILoggerFacade _log;

        public static IUnityContainer 人事部
        {
            get { return _人事部 ?? (_人事部 = ServiceLocator.Current.GetInstance<IUnityContainer>()); }
            set { _人事部 = value; }
        }

        public static IEventAggregator 宣传部
        {
            get { return _宣传部 ?? (_宣传部 = 人事部.Resolve<IEventAggregator>()); }
            set { _宣传部 = value; }
        }

        public static IRegionManager 行政部
        {
            get { return _行政部 ?? (_行政部 = 人事部.Resolve<IRegionManager>()); }
            set { _行政部 = value; }
        }

        public static Dispatcher Ui线程
        {
            get { return _ui线程 ?? (_ui线程 = Dispatcher.CurrentDispatcher); }
            set { _ui线程 = value; }
        }
        public static ILoggerFacade Log

        {
            get
            {
                if (_log == null)
                {
                    _log = new EmptyLogger();
                }
                return _log;
            }
            set { _log = value; }
        }
        public static bool 已注册 { get; set; }
        public static string 当前目录 => AppDomain.CurrentDomain.BaseDirectory;
        public static ResourceDictionary 程序资源 => Application.Current.Resources;

        public static void 测试初始化()
        {
            人事部 = new UnityContainer();
            宣传部 = new EventAggregator();
            行政部 = new RegionManager();
            Set默认解析器();
            人事部.RegisterType<ILoggerFacade, EmptyLogger>();
            人事部.RegisterType<IEventAggregator, EventAggregator>();
            人事部.RegisterType<IRegionManager, RegionManager>();
        }

        /// <summary>
        ///     加载默认解析工厂,需要初始化时候运行.
        /// </summary>
        public static void Set默认解析器()
        {
            ViewModelLocationProvider.SetDefaultViewModelFactory(
                T => 人事部.Resolve(T));
        }


        public static bool 激活视图(IRegion 区域1, string 视图名称)
        {
            var 视图1 = 区域1.GetView(视图名称);
            if (视图1 == null)
                return false;
            区域1.Activate(视图1);
            return true;
        }

        public static bool 导航到视图(IRegion 区域1, string 视图名称)
        {
            var 视图1 = 区域1.GetView(视图名称);
            if (视图1 == null)
                return false;
            区域1.NavigationService.RequestNavigate(视图名称);
            return true;
        }

        /// <summary>
        ///     检查 必备条件.
        /// </summary>
        /// <param name="必备条件">The 必备条件.</param>
        /// <param name="出错提示">The 出错提示.</param>
        public static void 检查(Func<bool> 必备条件, string 出错提示)
        {
            Contract.Assert(必备条件(), 出错提示);
        }

        public static void 更新资源(object key, object 内容)
        {
            Application.Current.Resources.Remove(key);
            Application.Current.Resources.Add(key, 内容);
        }

        public static void 弹出消息(string 消息)
        {
            宣传部.GetEvent<弹出消息Event>().
                Publish(new 消息1 { 显示文字 = 消息 });
        }

        //public static void 状态栏更新(string 类别, string 消息)
        //{
        //    宣传部.GetEvent<状态栏更新Event>()
        //        .Publish(new 状态栏Data1(类别, 消息));
        //}

        public static void 启动服务<T>(IUnityContainer 人事部cs, ILoggerFacade log) where T : I启动
        {
            Debug.Assert(人事部cs != null, "人事部cs != null");
            var 解析 = 人事部cs.Resolve<T>();
            if (解析 != null)
            {
                解析.启动();
            }
            else
            {
                Debug.Assert(log != null, "log != null");
                log.Log($"{nameof(T)}解析失败", Category.Exception, Priority.High);
            }
        }
        public static void 启动服务<T>(IUnityContainer 人事部cs) where T : I启动
        {
            Debug.Assert(人事部cs != null, "人事部cs != null");
            var 解析 = 人事部cs.Resolve<T>();
            if (解析 != null)
            {
                解析.启动();
            }
        }

        public static void 加载视图<T>(string 位置) where T : IView
        {
            行政部.RegisterViewWithRegion(位置, () =>
            {
                var 视图2 = 人事部.Resolve<T>();
                ViewModelLocationProvider.AutoWireViewModelChanged(视图2);
                return 视图2;
            });
        }

        //public static void 键盘Action(object dataContext, object sender, KeyEventArgs e)
        //{
        //    var key = dataContext as I键盘;
        //    key?.键盘Command?.Execute(new Tuple<object, KeyEventArgs>(sender, e));
        //}


        public static T 定位指针<T>(IList<T> 数据列表, int 指针, bool 循环)
        {
            if (数据列表 == null)
                return default(T);
            if (数据列表.Count == 0)
                return default(T);
            if (指针 < 数据列表.Count)
                return 数据列表[指针];
            if (循环)
                return 数据列表[指针 % 数据列表.Count];
            return default(T);
        }


        private static Mutex mutex; //建立字段.程序不退出,字段不回收.

        public static void 多启动限制(string 唯一字符串, Action 执行方法)
        {
            bool createdNew;
            mutex = new System.Threading.Mutex(true, 唯一字符串, out createdNew);
            if (!createdNew)
            {
                执行方法();
                System.Environment.Exit(0);
            }
        }
    }
}
