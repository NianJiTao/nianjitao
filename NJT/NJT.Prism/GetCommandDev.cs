using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using DevExpress.Mvvm.Native;

namespace NJT.Prism
{
    /// <summary>
    /// 自动生成DelegateCommand,可用cmd快捷键
    /// </summary>
    public class GetCommandDev
    {
        private Dictionary<string, IDelegateCommand> ListD { get; } = new Dictionary<string, IDelegateCommand>();

        public IDelegateCommand Get(string name, Action action)
        {
            if (ListD.ContainsKey(name))
            {
                return ListD[name];
            }
            var c = new DelegateCommand(action);
            ListD.Add(name, c);
            return c;
        }
        public IDelegateCommand Get(string name, Action action, Func<bool> 可执行)
        {
            if (ListD.ContainsKey(name))
            {
                return ListD[name];
            }
            var c = new DelegateCommand(action, 可执行);
            ListD.Add(name, c);
            return c;
        }
        public IDelegateCommand Get(string name, Action<object> action)
        {
            if (ListD.ContainsKey(name))
            {
                return (ListD[name]);
            }
            var c = new DelegateCommand<object>(action);
            ListD.Add(name, c);
            return c;
        }

        public IDelegateCommand GetF(string name, Func<IDelegateCommand> action)
        {
            if (ListD.ContainsKey(name))
            {
                return ListD[name];
            }
            var c = action();
            ListD.Add(name, c);
            return c;
        }
    }
}
