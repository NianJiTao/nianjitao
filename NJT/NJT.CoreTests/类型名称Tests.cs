using Xunit;
using NJT.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Core.Tests
{
    public class 类型名称Tests
    {
        [Fact()]
        public void 数值类型名称Test()
        {
            Assert.Equal("String", typeof(string).Name);
            Assert.Equal("Byte", typeof(byte).Name);
            Assert.Equal("Boolean", typeof(bool).Name);
            Assert.Equal("Int32", typeof(int).Name);
            Assert.Equal("Double", typeof(double).Name);
            Assert.Equal("Single", typeof(float).Name);
            Assert.Equal("DateTime", typeof(DateTime).Name);
            Assert.Equal("Int16", typeof(short).Name);
        }
    }
}