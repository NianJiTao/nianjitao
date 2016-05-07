using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NJT.Model;
using NJT.接口;
using Prism.Events;

namespace NJT.Events
{
    /// <summary>
    ///     true :已注册;  false :未注册
    /// </summary>
    public class 授权状态更新Event : PubSubEvent<bool>
    {
    }


    /// <summary>
    ///     Class 授权验证Event.string 公钥，I授权配置
    /// </summary>
    public class 授权验证Event : PubSubEvent<Tuple<string, I授权配置>>
    {
    }


    public class 保存授权配置Event : PubSubEvent<授权配置>
    {
    }
    public class 更新公钥Event : PubSubEvent<string>
    {

    }
    public class 取消授权Event : PubSubEvent<object>
    {

    }
}
