using System;
using System.Collections.Generic;
using DevExpress.Mvvm;
using DevExpress.Mvvm.Native;

namespace NJT.Prism
{
    public static partial class 扩展
    {
        public static void 更新命令状态(this IDelegateCommand command, string 提示消息, Action func)
        {
            func?.Invoke();
            更新命令状态(command, 提示消息);
        }


        public static void 更新命令状态(this IDelegateCommand command, string 提示消息)
        {
            command?.RaiseCanExecuteChanged();
            消息.更新状态栏(提示消息);
        }


        public static Dictionary<int, GetCommandDev> List { get; } = new Dictionary<int, GetCommandDev>();


        public static IDelegateCommand GetCom(this BindableBase vmBase, string name, Action action)
        {
            var com = FindGetCommand(vmBase);
            return com.Get(name, action);
        }


        public static IDelegateCommand GetCom(this BindableBase vmBase, string name, Action action, Func<bool> 可执行)
        {
            var com = FindGetCommand(vmBase);
            return com.Get(name, action, 可执行);
        }


        public static IDelegateCommand GetCom(this BindableBase vmBase, string name, Action<object> action)
        {
            var com = FindGetCommand(vmBase);
            return com.Get(name, action);
        }


        public static IDelegateCommand GetComF(this BindableBase vmBase, string name, Func<DelegateCommand> action)
        {
            var com = FindGetCommand(vmBase);
            return com.GetF(name, action);
        }


        private static GetCommandDev FindGetCommand(BindableBase vmBase)
        {
            var hash = vmBase?.GetHashCode() ?? string.Empty.GetHashCode();
            GetCommandDev com;
            if (List.ContainsKey(hash))
            {
                com = List[hash];
            }
            else
            {
                com = new GetCommandDev();
                List.Add(hash, com);
            }

            return com;
        }
    }
}