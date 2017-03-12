using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Core
{
    public class EData<T>
    {
        public EData(T data, string name)
        {
            Data = data;
            Name = name;
        }
        public T Data { get; set; }
        public string Name { get; set; }

    }
}
