using System;
using DevExpress.Mvvm;

namespace NJT.Prism
{
    public class 树<T> : BindableBase
    {
        public T 数据 { get; set; }
        public T Parent { get; set; }

        public Guid ObjectId { get; set; } = Guid.Empty;

        public Guid ParentId { get; set; } = Guid.NewGuid();

        public bool Is选中 { get; set; }
        public object Tag { get; set; }
    }

    public class Vm树<T> : ViewModelBase3
    {
        public T 数据 { get; set; }
        public T Parent { get; set; }

        public Guid ObjectId { get; set; } = Guid.Empty;

        public Guid ParentId { get; set; } = Guid.NewGuid();

        public bool Is选中 { get; set; }
        public object Tag { get; set; }
    }
}