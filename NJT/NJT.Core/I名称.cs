using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Core
{
    public interface I名称
    {
        string 名称 { get; set; }
    }

    public class 名称1 : I名称
    {
        public string 名称 { get; set; }

        public 名称1()
        {
        }
        public 名称1(string 名称cs)
        {
            this.名称 = 名称cs;
        }
    }
}
