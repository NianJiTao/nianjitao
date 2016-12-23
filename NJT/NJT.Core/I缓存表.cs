using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Core
{
    public interface I缓存表
    {
        int Id { get; set; }

        string 功能 { get; set; }

        string 键 { get; set; }

        string 值 { get; set; }

        DateTime 更新时间 { get; set; }

        DateTime 失效时间 { get; set; }

    }
}
