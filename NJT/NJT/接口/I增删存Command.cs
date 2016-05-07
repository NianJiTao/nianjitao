using System.Windows.Input;

namespace NJT.接口
{
    public interface I增删存Command
    {
        ICommand 新增Command { get; set; }
        ICommand 删除Command { get; set; }
        ICommand 保存Command { get; set; }
    }
}