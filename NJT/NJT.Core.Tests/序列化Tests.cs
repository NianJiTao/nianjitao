using Xunit;
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
        public string Name { get; set; }
    }

    public class 序列化Tests
    {

        string filePath = @"c:\temp\t.xml";
        string filePath2 = @"c:\temp\t2.txt";

        [Fact()]
        public void 写入Test()
        {
            var r = new Test信息() { Name = DateTime.Now.ToString() };
            序列化.写入(r, filePath);
            Assert.True(System.IO.File.Exists(filePath));
        }



        [Fact()]
        public void 读出Test()
        {
            var r = 序列化.读出<Test信息>(filePath);
            Assert.True(r.IsTrue);
        }

        [Fact()]
        public void To二进制Test()
        {
            var r = new Test信息() { Name = DateTime.Now.ToString() };
            var r2 = 序列化.To二进制(r);
            Assert.True(r2 != null);
            Assert.True(r2.Length > 0);

        }

        [Fact()]
        public void From二进制Test()
        {
            var r = new Test信息() { Name = DateTime.Now.ToString() };
            var r2 = 序列化.To二进制(r);
            var r3 = (Test信息)序列化.From二进制(r2);
            Assert.True(r.Name == r3.Name);

        }

        [Fact()]
        public void 写入二进制Test()
        {
            var r = new Test信息() { Name = DateTime.Now.ToString() };
            序列化.写入二进制(r, filePath2);
            Assert.True(System.IO.File.Exists(filePath2));
    
        }

        [Fact()]
        public void 读出二进制Test()
        {
            var r = 序列化.读出二进制<Test信息>(filePath2);
            Assert.True(r.IsTrue);
        }
    }
}