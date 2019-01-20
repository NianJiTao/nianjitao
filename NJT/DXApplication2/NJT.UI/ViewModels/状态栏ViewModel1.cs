using System;
using System.Collections.Generic;
using DevExpress.Mvvm;
using NJT.Core;
using NJT.Prism;

namespace NJT.UI.ViewModels
{
    public class 状态栏ViewModel : ViewModelBase3
    {
        public 状态栏ViewModel()
        {
            UseWin8NotificationsIfAvailable = false;

            授权 = new 状态栏Data2 {标识 = "授权", 标签 = "授权:", 数据 = "未知"};
            用户 = new 状态栏Data2 {标识 = "用户", 标签 = "用户:", 数据 = "未知"};
            提示 = new 状态栏Data2 {标识 = "提示", 标签 = "提示:", 数据 = "初始化"};

            DataList.Add(授权.标识, 授权);
            DataList.Add(用户.标识, 用户);
            DataList.Add(提示.标识, 提示);
            if (!IsInDesignMode)
            {
                EventAggregator宣传部?.GetEvent<Event更新状态栏>().Subscribe(状态栏更新Action, true);
                EventAggregator宣传部?.GetEvent<Event更新状态栏2>().Subscribe(更新状态栏2Action, true);
                EventAggregator宣传部?.GetEvent<EventSms通知>().Subscribe(Sms通知Action, true);
                EventAggregator宣传部?.GetEvent<EventSms通知2>().Subscribe(Sms通知2Action, true);
            }
        }


        public bool UseWin8NotificationsIfAvailable
        {
            get { return GetProperty(() => UseWin8NotificationsIfAvailable); }
            set { SetProperty(() => UseWin8NotificationsIfAvailable, value); }
        }

        public Dictionary<string, I标识Data> DataList { get; } = new Dictionary<string, I标识Data>();

        public I标识Data 授权 { get; set; }

        public I标识Data 提示 { get; set; }

        public I标识Data 用户 { get; set; }


        private void Sms通知Action(Sms通知 obj)
        {
            Sms通知2Action(obj?.主标题);
        }


        private void Sms通知2Action(string obj)
        {
            if (obj == null)
                return;
            try
            {
                UiHelper.RunAtUi(() =>
                {
                    var ns = GetService<INotificationService>()?.CreateCustomNotification(obj);
                    ns?.ShowAsync();
                }, false);
            }
            catch (Exception e)
            {
                更新状态栏2Action(e.Message);
            }
        }


        private void 更新状态栏2Action(string obj)
        {
            提示.数据 = DateTime.Now + " " + obj;
        }


        private void 状态栏更新Action(I标识Data obj)
        {
            if (obj == null)
                return;
            if (!DataList.ContainsKey(obj.标识))
                return;
            var dataStr = obj.数据;
            if ("提示" == obj.标识)
                dataStr = DateTime.Now + " " + dataStr;
            DataList[obj.标识].数据 = dataStr;
        }
    }
}