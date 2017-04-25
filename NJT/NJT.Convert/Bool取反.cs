using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace NJT.Convert
{
    public class Bool取反 : BoolToValue<bool>
    {
        public Bool取反()
        {
            TrueValue = false;
            FalseValue = true;
        }
    }
}
