using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NJT.接口
{
    public interface I键盘
    {
        /// <summary>
        ///     用于处理键盘按键事件.
        /// </summary>
        ICommand 键盘Command { get; set; }
    }
}
