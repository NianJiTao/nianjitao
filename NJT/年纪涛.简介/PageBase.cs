using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace 年纪涛.简介
{

    /// <summary>
    /// 继承此page,可以带属性更新通知功能.
    /// </summary>
    public class PageBase : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


    /// <summary>
    /// 继承此page,可以带属性更新通知和vm更新通知功能.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageBase<T> : Page, INotifyPropertyChanged where T : class
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public PageBase()  
        {
            DataContextChanged += (s, e) => VM.Data = DataContext as T;
        }
        public Vm<T> VM { get; } = new Vm<T>();

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
