using System;
using System.Windows.Threading;
using NJT.Common;
using NJT.接口;


namespace NJT.ViewModels
{
    public class 倒计时窗口ViewModel : Vm基类<I倒计时>, I启动
    {
        private DispatcherTimer _timer;

        public 倒计时窗口ViewModel()
        {
            Model = new 倒计时1();
        }

        public bool Is启动 { get; private set; }

        public void 启动()
        {
            Is启动 = true;

            _timer = new DispatcherTimer {Interval = TimeSpan.FromSeconds(1)};
            _timer.Tick += TimerTick;
            _timer.Start();
        }

        public event EventHandler 倒计时结束 = delegate { };

        private void TimerTick(object sender, EventArgs e)
        {
            if (--Model.数字 <= 0)
            {
                Is启动 = false;
                _timer.Stop();
                倒计时结束(this, null);
            }
        }

        public void 关闭()
        {
            if (Is启动 && _timer != null)
            {
                _timer.Stop();
                倒计时结束(this, null);
            }
        }
    }
}