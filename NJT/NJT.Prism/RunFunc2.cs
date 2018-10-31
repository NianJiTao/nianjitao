using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NJT.Core;

namespace NJT.Prism
{
    public static class RunFunc2
    {
        public static void TryRunAndLog(Action 方法)
        {
            var r = RunFunc.TryRun(方法);
            if (!r.IsTrue)
                消息.通知并记录错误(r.Message);
        }

        public static void TryRunAndLog<T>(Func<T> 方法)
        {
            var r = RunFunc.TryRun(方法);
            if (!r.IsTrue)
                消息.通知并记录错误(r.Message);
        }

        public static async Task TryRunAsyncAndLog(Func<Task> 方法)
        {
            var r = await RunFunc.TryRunAsync(方法);
            if (!r.IsTrue)
                消息.通知并记录错误(r.Message);
        }

        public static async Task TryRunAsyncAndLog<T>(Func<Task<T>> 方法)
        {
            var r = await RunFunc.TryRunAsync(方法);
            if (!r.IsTrue)
                消息.通知并记录错误(r.Message);
        }
    }
}
