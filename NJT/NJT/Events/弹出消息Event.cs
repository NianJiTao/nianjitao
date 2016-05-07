using Prism.Events;
using NJT.接口;

namespace NJT.Events
{
    public class 弹出消息Event : PubSubEvent<I消息 >
    {
    }

    public class 弹出警告Event : PubSubEvent<I消息>
    {
    }
}
