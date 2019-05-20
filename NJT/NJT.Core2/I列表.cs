using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Core
{
    public interface I列表<T>
    {
        ObservableCollection<T> 列表 { get; set; }
        T 选择项 { get; set; }
    }

    public interface I列表2<T>
    {
        ObservableCollection<T> 列表2 { get; set; }
        T 选择项2 { get; set; }
    }

    public interface I列表3<T>
    {
        ObservableCollection<T> 列表3 { get; set; }
        T 选择项3 { get; set; }
    }
    public interface I列表4<T>
    {
        ObservableCollection<T> 列表4 { get; set; }
        T 选择项4 { get; set; }
    }
}
