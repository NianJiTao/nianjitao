using System.Windows.Input;

namespace NJT.接口
{
    public interface I键盘事件
    {
        /// <summary>
        ///     用于处理键盘按键事件.
        /// </summary>
        ICommand 键盘Command { get; set; }
    }
}