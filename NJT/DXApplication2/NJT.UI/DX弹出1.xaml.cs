using System;
using System.Windows;
using System.Windows.Threading;
using DevExpress.Mvvm;
using DevExpress.Xpf.Core;
using NJT.Core;
using NJT.Prism;

namespace NJT.UI
{
    /// <summary>
    ///     Interaction logic for DX弹出1.xaml
    /// </summary>
    public partial class DX弹出1 : DXWindow, IView弹出窗口
    {
        private DispatcherTimer _timer;
        private int _当前次数;


        public DX弹出1()
        {
            InitializeComponent();
            Loaded += Win弹出1_Loaded;
        }


        public int 自动关闭秒数 { get; set; } = 5;

        public bool Is自动关闭 { get; set; }


        private void Win弹出1_Loaded(object sender, RoutedEventArgs e)
        {
            启动自动关闭();
            Messenger.Default.Register<Event关闭弹出窗口>(this,x=> Close());
            //RunUnity.EventAggregator宣传部?.GetEvent<Event关闭弹出窗口>().Subscribe(Close, true);
        }


        private void 启动自动关闭()
        {
            if (Is自动关闭)
            {
                _timer = new DispatcherTimer();
                _timer.Interval = TimeSpan.FromSeconds(1);
                _timer.Tick += TimerTick;
                _timer.Start();
            }
        }


        private void TimerTick(object sender, EventArgs e)
        {
            if (IsActive)
                _当前次数 = 0;
            else
                _当前次数++;
            if (_当前次数 >= 自动关闭秒数)
            {
                _timer?.Stop();
                Close();
            }
        }
    }
}