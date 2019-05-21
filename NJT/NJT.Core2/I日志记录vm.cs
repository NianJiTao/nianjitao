using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace NJT.Core
{
    public interface I日志记录vm
    {
        ICommand 清空Command { get; set; }
        IList<I日志记录> 列表 { get; }
    }
}
