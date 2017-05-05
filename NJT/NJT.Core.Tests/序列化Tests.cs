using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace NJT.Core.Tests
{
    [Serializable]
    public class Test信息
    {
        public string Name { get; set; } = "test";
    }

    public class 序列化Tests
    {
        string filePath = @"d:\test1.xml";
        string filePath2 = @"d:\test2.txt";

        [Fact]
        public void 写入Test()
        {
            序列化.写入(new Test信息(), filePath);
            Assert.True(System.IO.File.Exists(filePath));
            System.IO.File.Delete(filePath);
        }

        [Fact]
        public void 读出Test()
        {
            序列化.写入(new Test信息(), filePath);
            Assert.True(序列化.读出<Test信息>(filePath).IsTrue);
            System.IO.File.Delete(filePath);
        }

        [Fact]
        public void To二进制Test()
        {
            var r2 = 序列化.To二进制(new Test信息());
            Assert.True(r2 != null);
            Assert.True(r2.Length > 0);
        }

        [Fact]
        public void From二进制Test()
        {
            var r = new Test信息();
            var r2 = 序列化.To二进制(new Test信息());
            var r3 = (Test信息) 序列化.From二进制(r2);
            Assert.True(r.Name == r3.Name);
        }

        [Fact]
        public void 写入二进制Test()
        {
            序列化.写入二进制(new Test信息(), filePath2);
            Assert.True(System.IO.File.Exists(filePath2));
            System.IO.File.Delete(filePath2);
        }

        [Fact]
        public void 读出二进制Test()
        {
            序列化.写入二进制(new Test信息(), filePath2);
            var r = 序列化.读出二进制<Test信息>(filePath2);
            Assert.True(r.IsTrue);
            System.IO.File.Delete(filePath2);
        }

        [Fact]
        public async void 读写txtTest()
        {
            filePath2 = @"d:\temp\test2.txt";
            var rr = await 序列化.写入txt(filePath2, "abcdef");
            Assert.True(rr.IsTrue);

            var r = await 序列化.读出txt(filePath2);
            Assert.True(r.IsTrue);
            Assert.Equal("abcdef", r.Data);
            System.IO.File.Delete(filePath2);
        }

        [Fact]
        public async void 追加txtTest()
        {
            await 序列化.追加txt(filePath2, "abc");
            await 序列化.追加txt(filePath2, "def");
            var r = await 序列化.读出txt(filePath2);
            Assert.True(r.IsTrue);
            Assert.Equal("abcdef", r.Data);
            System.IO.File.Delete(filePath2);
        }
    }
}