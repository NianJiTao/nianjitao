using System;
using System.Windows;
using System.Windows.Threading;
using NJT.Common;
using NJT.接口;

namespace NJT.ViewModels
{
    public class 消息窗口ViewModel : Vm基类<I消息 >, I启动
    {

        public 消息窗口ViewModel()
        {
            Model =new 消息1();
        }

        private DispatcherTimer timer;
        public Window 窗口 { get; set; }

        public bool Is启动 { get; private set; }

        public bool Is关闭 { get; private set; }

        public void 启动()
        {
            if (窗口 == null) return;
            窗口.Show();
            窗口.Closed += (s,e)=> { Is关闭 = true; };
            Is启动 = true;
            timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(Model.显示毫秒) };
            timer.Tick += timer_Tick;
            timer.Start();
        }

        public void 关闭()
        {
            timer?.Stop();
            if (窗口 != null)
            {
                if (!Is关闭)
                {
                    窗口.Close();
                }
            }
            Is关闭 = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            关闭();
        }
    }
}
