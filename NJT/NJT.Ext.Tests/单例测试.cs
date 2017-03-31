using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NJT.Ext.Tests
{

    public class a
    {
        public int k { get; set; }
    }

    [TestClass()]

    public class 单例测试
    {

        [TestMethod()]
        public void Lazy单例Tests()
        {
            var t = 单例模式<a>.单例;
            t.k = 10;
            var t2= 单例模式<a>.单例;
            Assert.AreEqual(10, t2.k);
            t.k = 11;
            Assert.AreEqual(11, t2.k);

        }
    }
}
