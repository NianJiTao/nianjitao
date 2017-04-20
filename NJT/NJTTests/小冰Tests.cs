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
    public class 小冰Tests
    {
        [TestMethod()]
        public void 定位指针Test()
        {

            var data = new List<int>() {1,2,3,4,5 };

            //Assert.AreEqual(1, 小冰.定位指针(data, 0, false));
            //Assert.AreEqual(5, 小冰.定位指针(data, 4, false));
            //Assert.AreEqual(2, 小冰.定位指针(data, 6, true));

            //Assert.AreEqual(0, 小冰.定位指针(data, -1, false));


        }
    }
}