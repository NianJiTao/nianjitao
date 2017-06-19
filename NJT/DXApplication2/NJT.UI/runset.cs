using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DevExpress.Mvvm;
using DevExpress.Mvvm.UI;

namespace NJT.UI
{
    public class RunSet
    {
        public static  INotificationService NotificationService1 { get; set; }

        public static void 发布通知(string 内容)
        {
            if (NotificationService1 == null)
                return;
            var ns = (NotificationService)NotificationService1;
            ns.CustomNotificationDuration = new TimeSpan(0, 0, Properties.Settings.Default.时长);
            var notification = NotificationService1.CreateCustomNotification(内容);
            Show(notification);
        }
        static void  Show(INotification notification)
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