using Prism.Logging;
using Prism.Events;
using Prism.Regions;
using NJT.接口;
using Unity;

namespace NJT.Common
{
    public class 启动基类 : I启动
    {
        public readonly IRegionManager 行政部;
        public readonly IUnityContainer 人事部;
        public readonly IEventAggregator 新闻部;

        public 启动基类(IUnityContainer 人事部cs, IEventAggregator 新闻部cs, IRegionManager 行政部cs)
        {
            人事部 = 人事部cs;
            新闻部 = 新闻部cs;
            行政部 = 行政部cs;
            log = 人事部.Resolve<ILoggerFacade>();
        }

        public ILoggerFacade log { get; set; }
        public bool Is启动 { get; private set; }

        public virtual void 启动()
        {
            Is启动 = true;
        }
    }
}