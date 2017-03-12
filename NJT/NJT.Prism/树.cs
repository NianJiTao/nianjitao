using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NJT.Core;

namespace NJT.Prism
{
    public class 树 : BindableBase2, I树枝
    {
        private 树 _选择项 = null;

        public 树 选择项
        {
            get { return _选择项; }
            set { SetProperty(ref _选择项, value); }
        }

        public ObservableCollection<树> 子 { get; } = new ObservableCollection<树>();

        public object Tag { get; set; }

        public string 标识 { get; set; } = string.Empty;

        public int 层次 { get; set; } = 0;

        public int Id { get; set; } = 1;

        public int 父Id { get; set; } = 0;
    }
}
