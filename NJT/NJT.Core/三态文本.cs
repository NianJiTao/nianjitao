using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NJT.Core
{
    public class 三态文本 : DependencyObject
    {
        public static readonly DependencyProperty 选中Property =
            DependencyProperty.Register("选中", typeof(string), typeof(三态文本), new PropertyMetadata("开"));

        public static readonly DependencyProperty 未选Property =
            DependencyProperty.Register("未选", typeof(string), typeof(三态文本), new PropertyMetadata("关"));

        public static readonly DependencyProperty 空Property =
            DependencyProperty.Register("空", typeof(string), typeof(三态文本), new PropertyMetadata("未知"));

        public static readonly DependencyProperty 当前Property =
            DependencyProperty.Register("当前", typeof(string), typeof(三态文本), new PropertyMetadata("未知"));

        public string 选中
        {
            get => (string)GetValue(选中Property);
            set => SetValue(选中Property, value);
        }

        public string 未选
        {
            get => (string)GetValue(未选Property);
            set => SetValue(未选Property, value);
        }

        public string 空
        {
            get => (string)GetValue(空Property);
            set => SetValue(空Property, value);
        }

        public string 当前
        {
            get => (string)GetValue(当前Property);
            set => SetValue(当前Property, value);
        }
    }
}
