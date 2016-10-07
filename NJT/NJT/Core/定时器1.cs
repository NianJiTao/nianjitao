
using System;
using System.Windows.Threading;
using NJT.接口;

namespace NJT.Common
{
    public class 定时器1 : I定时器
    {
        private readonly DispatcherTimer timer;

        public 定时器1()
        {
            timer = new DispatcherTimer {Interval = TimeSpan.FromSeconds(1)};
            timer.Tick += (o, e) => 事件(o, e);
            事件 += delegate { };
        }

        public event EventHandler 事件 = delegate { };

        public TimeSpan 间隔
        {
            get { return timer.Interval; }
            set { timer.Interval = value; }
        }

        public bool Is启动
        {
            get { return timer.IsEnabled; }
            set { timer.IsEnabled = value; }
        }
    }
}