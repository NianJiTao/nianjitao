using System.Windows.Input;

namespace NJT.接口
{
    public interface I确定取消Command
    {
        ICommand 确定Command { get; set; }
        ICommand 取消Command { get; set; }
    }
}