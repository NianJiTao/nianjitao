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

        string 类别 { get; set; }

        string 名称 { get; set; }

        object 值 { get; set; }

        DateTime 更新时间 { get; set; }

        DateTime 失效时间 { get; set; }

    }
}
