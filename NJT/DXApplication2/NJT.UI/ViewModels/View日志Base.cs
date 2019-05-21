using System.Collections.ObjectModel;
using DevExpress.Mvvm;
using DevExpress.Mvvm.Native;
using NJT.Core;
using NJT.Ext;
using NJT.Ext.Core;
using NJT.Prism;
using Unity;

namespace NJT.UI.ViewModels
{
    public class View日志Base<T> : ViewModelBase3 where T : EventArgs<I日志记录>, new()
    {
        private int _maxLenth = 100;


        public View日志Base()
        {
            清空Command = new DelegateCommand(清空Action);
            if (IsInDesignMode) return;
            if (Container人事部.IsRegistered<int>("日志记录保留长度"))
                MaxLenth = Container人事部.Resolve<int>("日志记录保留长度");
            Messenger.Default.Register<Event更新日志记录保留长度>(this, x => MaxLenth = x.Data);
            Messenger.Default.Register<T>(this, x => 日志记录Action(x.Data));
        }


        public IDelegateCommand 清空Command { get; set; }


        public int MaxLenth
        {
            get => _maxLenth;
            set
            {
                if (value >= 1)
                {
                    _maxLenth = value;
                    while (列表.Count > _maxLenth)
                        列表.RemoveAt(0);
                }
            }
        }


        public ObservableCollection<I日志记录> 列表 { get; } = new ObservableCollection<I日志记录>();


        private void 日志记录Action(I日志记录 obj)
        {
            UiHelper.RunAtUi(() => Add记录(obj), true);
        }


        private void Add记录(I日志记录 info)
        {
            列表.AddAndMax(info, MaxLenth);
        }


        private void 清空Action()
        {
            列表.Clear();
        }
    }
}