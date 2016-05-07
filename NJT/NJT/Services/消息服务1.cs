using Prism.Events;
using Prism.Regions;
using Microsoft.Practices.Unity;
using NJT.Common;
using NJT.Events;
using NJT.ViewModels;
using NJT.Views;
using NJT.接口;

namespace NJT.Services
{
    public class 消息服务1 : 启动基类, I消息服务
    {

        public 消息服务1(IUnityContainer 人事部cs, IEventAggregator 新闻部cs, IRegionManager 模块cs)
            : base(人事部cs, 新闻部cs, 模块cs)
        {
        }

        public override void 启动()
        {
            if (Is启动) return;
            base.启动();

            新闻部.GetEvent<弹出消息Event>().Subscribe(弹出消息Action, true);
        }

        private 消息窗口ViewModel 上次消息窗口ViewModel;
        private void 弹出消息Action(I消息  obj)
        {
            if (上次消息窗口ViewModel != null)
            {
                上次消息窗口ViewModel.关闭();
            }

            var 视图2 = 人事部.Resolve<消息窗口>();
            var 业务2 = 人事部.Resolve<消息窗口ViewModel>();
            视图2.DataContext = 业务2;
            业务2.窗口 = 视图2;
            业务2.Model = obj;
            业务2.启动();

            上次消息窗口ViewModel = 业务2;
        }
    }
}
