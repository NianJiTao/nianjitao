using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace NJT.Core
{
    /// <summary>
    /// 帮助类
    /// </summary>
    public static class F1
    {
        public static ObservableCollection<T> Get动态集合<T>()
        {
            return new ObservableCollection<T>();
        }
        public static DispatcherTimer Get定时器()
        {
            return new DispatcherTimer();
        }
        public static void 授权复制(I授权配置 源, I授权配置 目标)
        {

            目标.客户名称 = 源.客户名称;
            目标.硬件码 = 源.硬件码;
            目标.注册码 = 源.注册码;
        }
    }
}
