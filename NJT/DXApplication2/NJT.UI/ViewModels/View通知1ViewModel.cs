using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DevExpress.Mvvm;
using DevExpress.Mvvm.Native;
using DevExpress.Mvvm.UI;
using NJT.Prism;

namespace NJT.UI.ViewModels
{
    public class View通知1ViewModel : ViewModelBase
    {
        public View通知1ViewModel()
        {
            时长 = 5;
            RunSet.NotificationService1 = NotificationService1;
        }

        public int 时长
        {
            get { return GetProperty(() => 时长); }
            set { SetProperty(() => 时长, value); }
        }


        public string 标题
        {
            get { return GetProperty(() => 标题); }
            set { SetProperty(() => 标题, value); }
        }

        public string 内容
        {
            get { return GetProperty(() => 内容); }
            set { SetProperty(() => 内容, value); }
        }

        public IDelegateCommand 发送通知Com => this.GetCom(nameof(发送通知Com), 发送通知Act);

        private INotificationService NotificationService1 => GetService<INotificationService>();

        private void 发送通知Act()
        {
            var ns = (NotificationService) NotificationService1;
            ns.CustomNotificationDuration = new TimeSpan(0, 0, Properties.Settings.Default.时长);

            //View通知显示1 view = new View通知显示1
            //{
            //    DataContext = new View通知显示1ViewModel()
            //    {
            //        标题 = 标题,
            //        内容 = 内容,
            //    },
            //};

            INotification notification = NotificationService1.CreateCustomNotification(内容);
            Show(notification);
        }

        void Show(INotification notification)
        {
            notification.ShowAsync().ContinueWith(OnNotificationShown,
                TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void OnNotificationShown(Task<NotificationResult> arg1)
        {
           //Application.Current.Shutdown();
        }
    }
}