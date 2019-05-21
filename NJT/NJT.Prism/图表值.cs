using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DevExpress.Mvvm;
using NJT.Core;

namespace NJT.Prism
{
    /// <summary>
    /// 简单实现,无通知
    /// </summary>
    public class 图表值3 : I图表值
    {
        public string 名称 { get; set; }
        public double 数据 { get; set; }
        public DateTime 时间 { get; set; }
    }

    /// <summary>
    ///     DependencyObject,  I名称值选择
    /// </summary>
    public class 图表值1 : DependencyObject, I图表值
    {
        public static readonly DependencyProperty 名称Property =
            DependencyProperty.Register("名称", typeof(string), typeof(图表值1),
                new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty 数据Property =
            DependencyProperty.Register("数据", typeof(double), typeof(图表值1),
                new PropertyMetadata(0d));

        public static readonly DependencyProperty 时间Property =
            DependencyProperty.Register("时间", typeof(DateTime), typeof(图表值1),
                new PropertyMetadata(常量.T2000年));

        public DateTime 时间
        {
            get => (DateTime) GetValue(时间Property);
            set => SetValue(时间Property, value);
        }

        public string 名称
        {
            get => (string) GetValue(名称Property);
            set => SetValue(名称Property, value);
        }

        public double 数据
        {
            get => (double) GetValue(数据Property);
            set => SetValue(数据Property, value);
        }
    }

    public class 图表值2 : BindableBase, I图表值
    {
        public 图表值2()
        {
            名称 = string.Empty;
            数据 = 0d;
            时间 = 常量.T2000年;
        }


        public double 数据
        {
            get { return GetProperty(() => 数据); }
            set { SetProperty(() => 数据, value); }
        }

        public DateTime 时间
        {
            get { return GetProperty(() => 时间); }
            set { SetProperty(() => 时间, value); }
        }

        public string 名称
        {
            get { return GetProperty(() => 名称); }
            set { SetProperty(() => 名称, value); }
        }
    }
}