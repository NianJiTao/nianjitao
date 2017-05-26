using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Core
{
    public static class RunFunc
    {
        public static 运行结果 TryRun(Action 方法)
        {
            try
            {
                方法();
                return new 运行结果(istrue: true);
            }
            catch (Exception exc)
            {
                return new 运行结果(istrue: false) { ErrorMess = exc.Message };
            }
        }

        public static 运行结果<T> TryRun<T>(Func<T> 方法)
        {
            try
            {
                return new 运行结果<T>(istrue: true) { Data = 方法() };
            }
            catch (Exception exc)
            {
                return new 运行结果<T>(istrue: false) { ErrorMess = exc.Message };
            }
        }


        public static async Task<运行结果> TryRunAsync(Func<Task> 方法)
        {
            try
            {
                await 方法();
                return new 运行结果(istrue: true);
            }
            catch (Exception exc)
            {
                return new 运行结果(istrue: false) { ErrorMess = exc.Message };
            }
        }

        public static async Task<运行结果<T>> TryRunAsync<T>(Func<Task<T>> 方法)
        {
            try
            {
                var r = await 方法();
                return new 运行结果<T>(istrue: true) { Data = r };
            }
            catch (Exception exc)
            {
                return new 运行结果<T>(istrue: false) { ErrorMess = exc.Message };
            }
        }
    }
}
