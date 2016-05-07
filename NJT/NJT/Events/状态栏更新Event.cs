using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Events;
using NJT.Common;
using NJT.接口;

namespace NJT.Events
{
    public class 状态栏更新Event : PubSubEvent<I状态栏Data>
    {
    }
}
