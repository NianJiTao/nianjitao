using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Core
{

    /// <summary>
    /// 泛型 数据和名称的组合.
    /// </summary>
    /// <typeparam name="T"></typeparam>
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
