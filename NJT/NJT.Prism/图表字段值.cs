using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DevExpress.Mvvm;
using NJT.Core;
using NJT.Core2;

namespace NJT.Prism
{
    public class 图表字段值1 : DependencyObject, I图表字段值
    {
        public 图表字段值1()
        {
            数据列表 = new ObservableCollection<I图表值>();
        }


        public static readonly DependencyProperty 字段名称Property =
            DependencyProperty.Register("字段名称", typeof(string), typeof(图表字段值1),
                new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty 数据列表Property =
            DependencyProperty.Register("数据列表", typeof(ObservableCollection<I图表值>), typeof(图表字段值1),
                new PropertyMetadata(new ObservableCollection<I图表值>()));

        public string 字段名称
        {
            get => (string) GetValue(字段名称Property);
            set => SetValue(字段名称Property, value);
        }

        public ObservableCollection<I图表值> 数据列表
        {
            get => (ObservableCollection<I图表值>) GetValue(数据列表Property);
            set => SetValue(数据列表Property, value);
        }
    }

    public class 图表字段值2 : BindableBase, I图表字段值
    {
        public 图表字段值2()
        {
            数据列表 = new ObservableCollection<I图表值>();
        }


        public string 字段名称
        {
            get { return GetProperty(() => 字段名称); }
            set { SetProperty(() => 字段名称, value); }
        }

        public ObservableCollection<I图表值> 数据列表
        {
            get { return GetProperty(() => 数据列表); }
            set { SetProperty(() => 数据列表, value); }
        }
    }
}