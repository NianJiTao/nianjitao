﻿using System;
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

    public interface IView弹出窗口 : IView
    {
        bool Is自动关闭 { get; set; }
        int 自动关闭秒数 { get; set; }
        string Title { get; set; }
        void Show();
        bool? ShowDialog();

    }

    public interface IView主窗口 : IView
    {
        void Show();
        bool? ShowDialog();
    }
    public interface IView日志 : IView { }


    public interface IView主视图 : IView { }

    public interface IView关于 : IView { }

    public interface IView系统设置 : IView { }
    public interface IView系统注册 : IView { }
    public interface IView时钟 : IView { }
}
