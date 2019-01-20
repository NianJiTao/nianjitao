using System;
using System.Collections.Generic;
using System.Windows.Input;
using Prism.Commands;

namespace NJT.Prism
{
    /// <summary>
    ///     自动生成DelegateCommand,可用cmd快捷键
    /// </summary>
    public class GetCommand
    {
        private readonly Dictionary<string, ICommand> _listI = new Dictionary<string, ICommand>();

        private readonly Dictionary<string, DelegateCommand<object>> _listT =
            new Dictionary<string, DelegateCommand<object>>();

        public Dictionary<string, DelegateCommand> List { get; } = new Dictionary<string, DelegateCommand>();


        public ICommand GetI(string name, Action action)
        {
            if (string.IsNullOrEmpty(name)) return null;
            if (!_listI.ContainsKey(name))
            {
                var c = new DelegateCommand(action);
                _listI.Add(name, c);
                return c;
            }

            return _listI[name];
        }


        public DelegateCommand Get(string name, Action action)
        {
            if (string.IsNullOrEmpty(name)) return null;
            if (!List.ContainsKey(name))
            {
                var c = new DelegateCommand(action);
                List.Add(name, c);
                return c;
            }

            return List[name];
        }


        public DelegateCommand<object> Get(string name, Action<object> action)
        {
            if (string.IsNullOrEmpty(name)) return null;
            if (!_listT.ContainsKey(name))
            {
                var c = new DelegateCommand<object>(action);
                _listT.Add(name, c);
                return c;
            }

            return _listT[name];
        }
    }
}