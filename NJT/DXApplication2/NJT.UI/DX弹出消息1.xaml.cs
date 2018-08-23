using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using DevExpress.Xpf.Core;
using NJT.Core;


namespace NJT.UI
{
    /// <summary>
    /// Interaction logic for DX弹出消息1.xaml
    /// </summary>
    public partial class DX弹出消息1 : ThemedWindow
    {
        public DX弹出消息1()
        {
            InitializeComponent();
        }

        private I弹出消息 _消息;

        private DispatcherTimer timer;

        public void Set消息(I弹出消息 obj)
        {
            _消息 = obj;
            DataContext = _消息;
        }

        public I弹出消息 消息
        {
            set
            {
                _消息 = value;
                DataContext = _消息;
                启动();
            }
        }

        private void DX弹出消息1_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
        public void 启动定时器()
        {
            if (_消息 == null)
                return;
            Closed += (s, e) => 停止定时器();
            timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(_消息.显示毫秒) };
            timer.Tick += (s, e) =>
            {
                timer.Stop();
                Close();
            };
            timer.Start();
        }
        public void 启动()
        {
            if (_消息 == null)
                return;
            启动定时器();
            Show();
        }

        public void 置顶启动()
        {
            if (_消息 == null)
                return;
            启动定时器();
            ShowDialog();

        }

        private void 停止定时器()
        {
            if ((timer != null) && timer.IsEnabled)
                timer.Stop();
        }
    }
}
