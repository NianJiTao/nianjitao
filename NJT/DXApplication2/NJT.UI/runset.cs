using System;
using System.Threading.Tasks;
using System.Windows;
using DevExpress.Mvvm;
using DevExpress.Mvvm.UI;

namespace NJT.UI
{
    public class RunSet
    {
        public static INotificationService NotificationService1 { get; set; }

        public static int 时长 { get; set; } = 5;


        public static void 发布通知(string 内容)
        {
            if (NotificationService1 == null)
                return;
            var ns = (NotificationService) NotificationService1;
            ns.CustomNotificationDuration = new TimeSpan(0, 0, 时长);
            var notification = NotificationService1.CreateCustomNotification(内容);
            Show(notification);
        }


        private static void Show(INotification notification)
        {
            notification.ShowAsync().ContinueWith(OnNotificationShown,
                TaskScheduler.FromCurrentSynchronizationContext());
        }


        private static void OnNotificationShown(Task<NotificationResult> arg1)
        {
            Application.Current.Shutdown();
        }
    }
}