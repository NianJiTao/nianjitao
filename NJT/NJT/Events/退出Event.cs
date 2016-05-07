using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Events;

namespace NJT.Events
{
    /// <summary>
    /// 程序退出后的处理.后台线程可订阅此事件.参数为null.
    /// </summary>
    public class 退出Event : PubSubEvent<object>
    {
    }
}
