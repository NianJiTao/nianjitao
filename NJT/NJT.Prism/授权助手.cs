using System;
using NJT.Core;

namespace NJT.Prism
{
    public class 授权助手
    {
        public static void 保存授权配置(授权配置 源, 授权配置 目标, Action<授权配置> 保存方法)
        {
            if (源 == null) return;
            F1.授权复制(源, 目标);
            授权信息.注册码 = 源.注册码;
            消息.通知并记录("保存授权配置");
            保存方法?.Invoke(源);
        }


        public static void 保存授权配置(授权配置 源, Action<授权配置> 保存方法)
        {
            保存授权配置(源, null, 保存方法);
        }
    }
}