using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Core
{
    public class 值变化<T>
    {
        private T _历史值 = default(T);
        public bool Is变化(T 当前值)
        {
            if (_历史值.Equals(当前值))
            {
                return false;
            }
            _历史值 = 当前值;
            return true;
        }
    }
}
