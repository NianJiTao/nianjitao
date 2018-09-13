using Xunit;
using NJT.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Core.Tests
{
    public class 硬件信息Tests
    {
        [Fact()]
        public void Get网卡Test()
        {
            var r = new 硬件信息().Get网卡();
            Assert.True(r.Count > 0);
            var r2 = string.Join("\r\n", r);
            Assert.NotEqual("", r2);
        }

        [Fact()]
        public void GetCpuTest()
        {
            var r = new 硬件信息().GetCpu();
            Assert.True(r.Count > 0);
            var r2 = string.Join("\r\n", r);
            Assert.NotEqual("", r2);
        }

        [Fact()]
        public void Get主板Test()
        {
            var r = new 硬件信息().Get主板();
            Assert.True(r.Count > 0);
            var r2 = string.Join("\r\n", r);
            Assert.NotEqual("", r2);
        }

        [Fact()]
        public void Get硬盘Test()
        {
            var r = new 硬件信息().Get硬盘();
            Assert.True(r.Count > 0);
            var r2 = string.Join("\r\n", r);
            Assert.NotEqual("", r2);
        }

        [Fact()]
        public void Get特征码Test()
        {
            Assert.Equal("X4DPB8VMKQXT", (new 硬件信息().Get特征码()));
        }
    }
}