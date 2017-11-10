using NJT.Common;
using NJT.Events;
using NJT.接口;
using Prism.Events;
using Prism.Regions;
using Unity;

namespace NJT.Services
{
    public class 倒计时服务1 : 启动基类, I倒计时服务
    {
        private I倒计时窗口 上次倒计时窗口;

        public 倒计时服务1(IUnityContainer 人事部cs, IEventAggregator 新闻部cs, IRegionManager 模块cs)
            : base(人事部cs, 新闻部cs, 模块cs)
        {
        }

        public override void 启动()
        {
            if (Is启动) return;
            base.启动();

            新闻部.GetEvent<弹出倒计时Event>().Subscribe(弹出倒计时Action, true);
        }

        private void 弹出倒计时Action(I倒计时 obj)
        {
            if (上次倒计时窗口 != null)
            {
                上次倒计时窗口.关闭();
            }

            var 视图2 = 人事部.Resolve<I倒计时窗口>();
            视图2.启动(obj);
            上次倒计时窗口 = 视图2;
        }
    }
}