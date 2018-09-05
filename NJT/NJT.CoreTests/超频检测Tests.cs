using Xunit;
using NJT.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Core.Tests
{
    public class 超频检测Tests
    {
        [Fact()]
        public void Is超频Test()
        {
            Assert.False(超频检测.Is超频("a", 常量.M5分));
            Assert.True(超频检测.Is超频("a", 常量.M5分));
            Assert.False(超频检测.Is超频("b", 常量.M5分));
            Assert.True(超频检测.Is超频("b", 常量.M5分));
        }
    }
}