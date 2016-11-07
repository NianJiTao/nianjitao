using Microsoft.VisualStudio.TestTools.UnitTesting;
using NJT.Tree.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Tree.Wpf.Tests
{
    [TestClass()]
    public class 文件夹Tests
    {
        [TestMethod()]
        public void 刷新Test()
        {
            var r = new 文件夹();
            r.刷新();
            Assert.IsTrue(r.可展开);

        }

       
    }
}