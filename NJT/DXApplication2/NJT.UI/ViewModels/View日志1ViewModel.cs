﻿using System;
using System.Collections.ObjectModel;
using DevExpress.Mvvm;
using DevExpress.Mvvm.Native;
using NJT.Core;
using NJT.Ext;
using NJT.Prism;
using Unity;

namespace NJT.UI.ViewModels
{
    public class View日志1ViewModel : View日志Base<Event更新日志记录>
    {
    }

    //public class View日志1ViewModel : ViewModelBase3
    //{
    //    private int _maxLenth = 100;

    //    public View日志1ViewModel()
    //    {
    //        标题 = "记录";

    //        清空Command = new DelegateCommand(清空Action);


    //        if (IsInDesignMode) return;
    //        if (Container人事部.IsRegistered<int>("日志记录保留长度"))
    //            ClearLenth = Container人事部.Resolve<int>("日志记录保留长度");
    //        EventAggregator宣传部?.GetEvent<Event更新日志记录保留长度>().Subscribe(x => ClearLenth = x, true);
    //        EventAggregator宣传部?.GetEvent<Event更新日志记录>().Subscribe(日志记录Action, true);
    //    }

    //    public IDelegateCommand 清空Command { get; set; }

    //    public string 标题
    //    {
    //        get { return GetProperty(() => 标题); }
    //        set { SetProperty(() => 标题, value); }
    //    }

    //    private int ClearLenth
    //    {
    //        get => _maxLenth;
    //        set
    //        {
    //            if (value >= 1)
    //            {
    //                _maxLenth = value;
    //                while (列表.Count > _maxLenth)
    //                    列表.RemoveAt(0);
    //            }
    //        }
    //    }


    //    public ObservableCollection<I日志记录> 列表 { get; } = new ObservableCollection<I日志记录>();


    //    private void 日志记录Action(I日志记录 obj)
    //    {
    //        UiHelper.RunAtUi(() => Add记录(obj), true);
    //    }


    //    private void Add记录(I日志记录 info)
    //    {
    //        列表.AddAndMax(info, ClearLenth);
    //    }

    //    private void 清空Action()
    //    {
    //        列表.Clear();
    //    }
    //}
}