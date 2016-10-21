using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Windows.Mvvm;

namespace 年纪涛.简介
{

    /// <summary>
    /// 继承于prism的vm基类,为本项目方便添加扩展.
    /// </summary>
    public class VmBase : ViewModelBase
    {

    }

    /// <summary>
    /// T为vm类型,方便 page 的 DataContext 更新用.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Vm<T> : ViewModelBase
    {
        private T _data;

        public T Data
        {
            get { return _data; }
            set { SetProperty(ref _data, value); }
        }
    }

}
