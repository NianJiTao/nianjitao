using Microsoft.VisualStudio.TestTools.UnitTesting;
using NJT.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Core.Tests
{
    [TestClass()]
    public class 硬件信息Tests
    {
        [TestMethod()]
        public void Get网卡Test()
        {
            Assert.IsTrue(new 硬件信息().Get网卡().Count > 0);
        }

        [TestMethod()]
        public void GetCpuTest()
        {
            Assert.IsTrue(new 硬件信息().GetCpu().Count > 0);
        }

        [TestMethod()]
        public void Get主板Test()
        {
            Assert.IsTrue(new 硬件信息().Get主板().Count > 0);
        }

        [TestMethod()]
        public void Get硬盘Test()
        {
            Assert.IsTrue(new 硬件信息().Get硬盘().Count > 0);
        }

        [TestMethod()]
        public void Get特征码Test()
        {
            Assert.IsFalse(string.IsNullOrEmpty(new 硬件信息().Get特征码()));
        }
    }
}