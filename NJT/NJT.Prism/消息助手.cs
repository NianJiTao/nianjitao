using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Prism
{
    public static class 消息助手
    {
        /// <summary>
        /// 调用 Log.Info
        /// </summary>
        /// <param name="info"></param>
        public static void 通知并记录(string info)
        {
            Message.SendMess(info);
            RunUnity.Log.Info(info);
        }

        /// <summary>
        /// 调用 Log.Error
        /// </summary>
        /// <param name="info"></param>
        public static void 通知并记录错误(string info)
        {
            Message.SendMess(info);
            RunUnity.Log.Error(info);
        }

        /// <summary>
        /// 调用 Log.Debug
        /// </summary>
        /// <param name="info"></param>
        public static void 通知并记录调试(string info)
        {
            Message.SendMess(info);
            RunUnity.Log.Debug(info);
        }
    }
}