using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;

namespace NJT.UI
{


    [POCOViewModel]
    public class 显示模版 //: ViewModelBase
    {
        public 显示模版()
        {
        }
        //ViewModelSource.Create(() => new CustomToastViewModel {
        //    Width = CustomNotificationWidth,
        //    Height = CustomNotificationHeight,
        //    Text = CustomNotificationText,
        //    Background = CustomNotificationBackgroundBrush
        //});
        public virtual  SolidColorBrush Background { get; set; } = Brushes.Black;
        public virtual double Width { get; set; } = 380;
        public virtual string Text { get; set; } = "有事发生";
        public virtual string Header { get; set; } = "标题";
        public virtual double Height { get; set; } = 100;
    }
}