using System;
using Microsoft.Practices.Unity;
using NJT.Core;
using Prism.Events;

namespace NJT.Prism
{
    public class Message
    {
        private static IUnityContainer Container人事部 => RunUnity.Container人事部;
        private static IEventAggregator EventAggregator宣传部 => RunUnity.EventAggregator宣传部;

        /// <summary>
        ///     快速发布状态栏通知消息
        /// </summary>
        /// <param name="消息内容">The 消息内容.</param>
        public static void SendMess(string 消息内容)
        {
            EventAggregator宣传部.GetEvent<Event状态栏更新>()
                .Publish(new 状态栏Data2(消息内容));
        }

        /// <summary>
        ///     快速发布状态栏通知消息 ,并根据类别传送
        /// </summary>
        /// <param name="消息内容">The 消息内容.</param>
        /// <param name="类别">The 类别.</param>
        public static void SendMess(string 消息内容, string 类别)
        {
            EventAggregator宣传部.GetEvent<Event状态栏更新>()
                .Publish(new 状态栏Data2(消息内容, 类别));
        }

        public static void PubData<T>(EData<T> data1)
        {
            EventAggregator宣传部.GetEvent<PubEvent<T>>().Publish(data1);
        }

        public static void SubData<T>(Action<EData<T>> EDataTAction, string token)
        {
            EventAggregator宣传部
                .GetEvent<PubEvent<T>>()
                .Subscribe(EDataTAction, ThreadOption.PublisherThread, true, x => x.Name == token);
        }


        public static void PublishMenu(string MenuName)
        {
            EventAggregator宣传部.GetEvent<EventMenu>().Publish(MenuName);
        }

        public static void SubscribeMenu(Action<string> 开关Action, string token)
        {
            EventAggregator宣传部
                .GetEvent<EventMenu>()
                .Subscribe(开关Action, ThreadOption.PublisherThread, true, x => x == token);
        }
    }
}