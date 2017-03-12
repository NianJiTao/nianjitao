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
        private I硬件信息 info;
        public 硬件信息Tests()
        {
            info = new 硬件信息();
        }
        [Fact()]
        public void GetCpuTest()
        {
            var r = info.GetCpu();
            Assert.True(r.Count > 0);
            Assert.False(string.IsNullOrEmpty(r.FirstOrDefault()));
        }
        [Fact()]
        public void Get主板Test()
        {
            var r = info.Get主板();
            Assert.True(r.Count > 0);
            Assert.False(string.IsNullOrEmpty(r.FirstOrDefault()));
        }

        [Fact()]
        public void Get硬盘Test()
        {
            var r = info.Get硬盘();
            Assert.True(r.Count > 0);
            Assert.False(string.IsNullOrEmpty(r.FirstOrDefault()));
        }
        [Fact()]
        public void Get网卡Test()
        {
            var r = info.Get网卡() ;
            Assert.True(r.Count > 0);
            Assert.False(string.IsNullOrEmpty(r.FirstOrDefault()));
        }
        [Fact()]
        public void Get特征码Test()
        {
            var r = info.Get特征码();
            Assert.False(string.IsNullOrEmpty(r));
        }
    }
}