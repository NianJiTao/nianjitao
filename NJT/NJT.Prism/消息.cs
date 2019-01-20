using NJT.Core;
using Prism.Events;

namespace NJT.Prism
{
    public static class 消息
    {
        private static IEventAggregator EventAggregator宣传部 => RunUnity.EventAggregator宣传部;
        private static I日志 Log1 => RunUnity.Log;


        /// <summary>
        ///     快速发布状态栏通知消息
        /// </summary>
        /// <param name="消息内容">The 消息内容.</param>
        public static void 更新状态栏(string 消息内容)
        {
            EventAggregator宣传部?.GetEvent<Event更新状态栏2>().Publish(消息内容);
        }


        /// <summary>
        ///     快速发布状态栏通知消息 ,并根据类别传送
        /// </summary>
        /// <param name="消息内容">The 消息内容.</param>
        /// <param name="类别">The 类别.</param>
        public static void 更新状态栏(string 消息内容, string 类别)
        {
            EventAggregator宣传部?.GetEvent<Event更新状态栏>().Publish(new 状态栏Data2(消息内容, 类别));
        }


        public static void 发布消息(string 消息内容)
        {
            EventAggregator宣传部?.GetEvent<EventSms通知2>().Publish(消息内容);
        }


        public static void 发布消息(string 消息内容, string 标题)
        {
            EventAggregator宣传部?.GetEvent<EventSms通知>().Publish(new Sms通知(标题, 消息内容));
        }


        /// <summary>
        ///     右下角Sms
        /// </summary>
        /// <param name="消息内容"></param>
        public static void Sms(string 消息内容)
        {
            EventAggregator宣传部?.GetEvent<EventSms通知2>().Publish(消息内容);
        }


        /// <summary>
        ///     右下角Sms
        /// </summary>
        /// <param name="消息内容"></param>
        /// <param name="标题"></param>
        public static void Sms(string 消息内容, string 标题)
        {
            EventAggregator宣传部?.GetEvent<EventSms通知>().Publish(new Sms通知(标题, 消息内容));
        }


        /// <summary>
        ///     更新状态栏并调用 Log.Info
        /// </summary>
        /// <param name="info"></param>
        public static void 通知并记录(string info)
        {
            更新状态栏(info);
            Log1?.Info(info);
        }


        /// <summary>
        ///     更新状态栏并调用 Log.Error
        /// </summary>
        /// <param name="info"></param>
        public static void 通知并记录错误(string info)
        {
            更新状态栏(info);
            Log1?.Error(info);
        }


        /// <summary>
        ///     更新状态栏并调用 Log.Debug
        /// </summary>
        /// <param name="info"></param>
        public static void 通知并记录调试(string info)
        {
            更新状态栏(info);
            Log1?.Debug(info);
        }
    }
}