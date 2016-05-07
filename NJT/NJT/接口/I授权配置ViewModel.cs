using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NJT.接口
{
    public interface I授权配置ViewModel : I授权配置
    {
        ICommand 验证Command { get; set; }
        ICommand 复制Command { get; set; }
        ICommand 粘贴Command { get; set; }
        ICommand 保存Command { get; set; }
        bool Is验证中 { get; }
        bool Is验证成功 { get; }
        string 硬件码 { get; set; }
        string 公钥 { get; set; }

    }
}
