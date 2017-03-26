using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Core
{
    public interface IView
    {
        object DataContext { get; set; }
    }

    public interface IView<T>
    {
        object DataContext { get; set; }
        T Vm { get; set; }
    }

    public interface IView菜单 : IView { }

    public interface IView状态栏 : IView { }

    public interface IView导航栏 : IView { }

    public interface IView弹出窗口 : IView { }

    public interface IView主窗口 : IView { }
    public interface IView日志 : IView { }

  

    public interface IView主视图 : IView { }

    public interface IView关于 : IView { }
}
