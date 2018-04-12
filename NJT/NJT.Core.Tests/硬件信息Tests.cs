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
            var r = new 硬件信息().Get网卡();
            Assert.IsTrue(r.Count > 0);
            var r2 = r.Aggregate("", (current, s) => current + "\r\n" + s);
            Assert.AreEqual("", r2);
        }

        [TestMethod()]
        public void GetCpuTest()
        {
            var r = new 硬件信息().GetCpu();
            Assert.IsTrue(r.Count > 0);
            var r2 = r.Aggregate("", (current, s) => current + "\r\n" + s);
            Assert.AreEqual("", r2);
        }

        [TestMethod()]
        public void Get主板Test()
        {
            var r = new 硬件信息().Get主板();
            Assert.IsTrue(r.Count > 0);
            var r2 = r.Aggregate("", (current, s) => current + "\r\n" + s);
            Assert.AreEqual("", r2);
        }

        [TestMethod()]
        public void Get硬盘Test()
        {
            var r = new 硬件信息().Get硬盘();
            Assert.IsTrue(r.Count > 0);
            var r2 = r.Aggregate("", (current, s) => current + "\r\n" + s);
            Assert.AreEqual("", r2);
        }

        [TestMethod()]
        public void Get特征码Test()
        {
            Assert.AreEqual("X4DPB8VMKQXT", (new 硬件信息().Get特征码()));
        }
    }
}