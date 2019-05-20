using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Core
{
    public interface I树枝 : I身份证
    {
        string 标识 { get; set; }

        int 层次 { get; set; }

        int Id { get; set; }

        int 父Id { get; set; }
    }

    public interface I树枝<T>
    {
        T 数据 { get; set; }
    }
}
