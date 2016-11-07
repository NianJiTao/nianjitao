using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Prism.Windows.Mvvm;
using 英文单词提取.ViewModels;

namespace 英文单词提取
{




    public class VmBase1 : Vm<object> { }

    public class Vm<T> : VmBase
    {
        private T _data;

        public T Data
        {
            get { return _data; }
            set
            {
                if (Equals(_data, value))
                {
                    return;
                }
                _data = value;
                OnPropertyChanged(nameof(Data));
            }
        }
    }


    public class VmBase : ViewModelBase
    {

        public Func<Type, string> Name => type => type.Name.EndsWith("Page") 
            ? type.Name.Remove(type.Name.Length-4) 
            : type.Name;
    }
}
