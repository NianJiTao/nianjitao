using Microsoft.VisualStudio.TestTools.UnitTesting;
using NJT.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Core.Tests
{

    [Serializable]
    public class Test信息
    {
        public string Name { get; set; } = "test";
    }

    [TestClass()]
    public class 序列化Tests
    {
        string filePath = @"d:\test1.xml";
        string filePath2 = @"d:\test2.txt";
        [TestMethod()]
        public void 写入Test()
        {
            序列化.写入(new Test信息() , filePath);
            Assert.IsTrue(System.IO.File.Exists(filePath));
            System.IO.File.Delete(filePath);
        }

        [TestMethod()]
        public void 读出Test()
        {
            序列化.写入(new Test信息()  , filePath);
            Assert.IsTrue(序列化.读出<Test信息>(filePath).IsTrue);
            System.IO.File.Delete(filePath);
        }

        [TestMethod()]
        public void To二进制Test()
        {
            var r2 = 序列化.To二进制(new Test信息());
            Assert.IsTrue(r2 != null);
            Assert.IsTrue(r2.Length > 0);
        }

        [TestMethod()]
        public void From二进制Test()
        {
            var r = new Test信息()  ;
            var r2 = 序列化.To二进制(new Test信息());
            var r3 = (Test信息)序列化.From二进制(r2);
            Assert.IsTrue(r.Name == r3.Name);
        }

        [TestMethod()]
        public void 写入二进制Test()
        {
            序列化.写入二进制(new Test信息(), filePath2);
            Assert.IsTrue(System.IO.File.Exists(filePath2));
            System.IO.File.Delete(filePath2);

        }

        [TestMethod()]
        public void 读出二进制Test()
        {
            序列化.写入二进制(new Test信息(), filePath2);
            var r = 序列化.读出二进制<Test信息>(filePath2);
            Assert.IsTrue(r.IsTrue);
            System.IO.File.Delete(filePath2);
        }
    }
}