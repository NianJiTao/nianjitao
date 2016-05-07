using System;
using System.Collections.ObjectModel;
using Microsoft.Practices.Prism.Mvvm;

namespace NJT.接口
{
    public interface I泛型树枝
    {
        Guid 唯一编号 { get; set; }
        string 名称 { get; set; }
        bool Is选中 { get; set; }
        bool Is展开 { get; set; }
        bool 可展开 { get; set; }
        int 深度 { get; set; }
        I泛型树枝 选择项 { get; set; }
        I泛型树枝 父 { get; set; }
        dynamic 数据 { get; set; }
        ObservableCollection<I泛型树枝> 子 { get; set; }
    }

    public class 树枝<T> : BindableBase, I泛型树枝
    {
        private bool _is选中;
        private bool _is展开;
        private bool _可展开;
        private string _名称;
        private int _深度;
        private T _数据;
        private I泛型树枝 _选择项;

        public 树枝()
        {
            唯一编号 = Guid.NewGuid();
            子 = new ObservableCollection<I泛型树枝>();
        }

        public Guid 唯一编号 { get; set; }

        public string 名称
        {
            get { return _名称; }
            set { SetProperty(ref _名称, value); }
        }

        public bool Is选中
        {
            get { return _is选中; }
            set { SetProperty(ref _is选中, value); }
        }

        public bool Is展开
        {
            get { return _is展开; }
            set { SetProperty(ref _is展开, value); }
        }

        public bool 可展开
        {
            get { return _可展开; }
            set { SetProperty(ref _可展开, value); }
        }

        public int 深度
        {
            get { return _深度; }
            set { SetProperty(ref _深度, value); }
        }

        public I泛型树枝 选择项
        {
            get { return _选择项; }
            set { SetProperty(ref _选择项, value); }
        }

        public I泛型树枝 父 { get; set; }

        public dynamic 数据
        {
            get { return _数据; }
            set { SetProperty(ref _数据, value); }
        }

        public ObservableCollection<I泛型树枝> 子 { get; set; }

        public override string ToString()
        {
            return 名称;
        }
    }
}