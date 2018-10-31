using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Core
{
    /// <summary>
    /// 有此特性的属性.不调用克隆赋值功能.
    /// </summary>
    public class 禁止克隆 : Attribute
    {
    }

}
