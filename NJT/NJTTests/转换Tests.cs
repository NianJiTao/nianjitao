using Microsoft.VisualStudio.TestTools.UnitTesting;
using NJT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Tests
{
    [TestClass()]
    public class 转换Tests
    {
        [TestMethod()]
        public void 时间转换Test()
        {
            Assert.AreEqual(TimeSpan.Zero, 转换.时间转换("0:0:0").Item2);
            Assert.AreEqual(TimeSpan.FromSeconds(1), 转换.时间转换("0:0:1").Item2);
            Assert.AreEqual(false, 转换.时间转换("w").Item1);
            Assert.AreEqual(TimeSpan.Zero, 转换.时间转换("1").Item2);

        }

        [TestMethod()]
        public void 属性转换Test()
        {
            var t = new TimeTest {时间s = "00:00:01"};
            Assert.AreEqual(TimeSpan.FromSeconds(1), t.时间);
        }

        private class TimeTest
        {
            public TimeSpan 时间 { get; set; }

            public string 时间s
            {
                get { return 时间.ToString(); }
                set { 转换.属性转换(x => 时间 = x, 转换.时间转换, value); }
            }
        }


    }
}