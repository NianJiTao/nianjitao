using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Core
{
    public class EventArgs<T> : EventArgs
    {
        public EventArgs()
        {
        }


        public EventArgs(T data)
        {
            Data = data;
        }


        public T Data { get; set; } = default(T);
    }
}
