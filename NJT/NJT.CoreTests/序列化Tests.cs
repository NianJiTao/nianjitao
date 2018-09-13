using Xunit;
using NJT.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Core.Tests
{
    public class 序列化Tests
    {
        [Serializable]
        public class Test信息
        {
            public string Name { get; set; } = "test";
        }

        //string xmlFile = @"d:\test1.xml";
        //string txtFile = @"d:\test1.txt";
        //string txtFile2 = @"d:\test2.txt";
        //string txtFile3 = @"d:\test3.txt";

        [Fact()]
        public void 写入xmlTest()
        {
            string xmlFile = @"d:\"+Guid.NewGuid()+".xml";
            序列化.写入(new Test信息(), xmlFile);
            Assert.True(System.IO.File.Exists(xmlFile));
            System.IO.File.Delete(xmlFile);
        }

        [Fact()]
        public void 读出Test()
        {
            string xmlFile = @"d:\"+Guid.NewGuid()+".xml";
            序列化.写入(new Test信息(), xmlFile);
            Assert.True(序列化.读出<Test信息>(xmlFile).IsTrue);
            System.IO.File.Delete(xmlFile);
        }

        [Fact()]
        public void To二进制Test()
        {
            var r2 = 序列化.To二进制(new Test信息());
            Assert.True(r2 != null);
            Assert.True(r2.Length > 0);
        }

        [Fact()]
        public void From二进制Test()
        {
            var r3 = (Test信息) 序列化.From二进制(序列化.To二进制(new Test信息()));
            Assert.True(new Test信息().Name == r3.Name);
        }

        [Fact()]
        public void 写入二进制Test()
        {
            string txtFile = @"d:\"+Guid.NewGuid()+".txt";
            序列化.写入二进制(new Test信息(), txtFile);
            Assert.True(System.IO.File.Exists(txtFile));
            System.IO.File.Delete(txtFile);
        }

        [Fact()]
        public void 读出二进制Test()
        {
            string txtFile = @"d:\"+Guid.NewGuid()+".txt";
            序列化.写入二进制(new Test信息(), txtFile);
            Assert.True(序列化.读出二进制<Test信息>(txtFile).IsTrue);
            System.IO.File.Delete(txtFile);
        }

        [Fact()]
        public async void 合并txtTest()
        {
            string txtFile = @"d:\"+Guid.NewGuid()+".txt";
            string txtFile2 = @"d:\"+Guid.NewGuid()+".txt";
            string txtFile3 = @"d:\"+Guid.NewGuid()+".txt";
            await 序列化.写入txt(txtFile, "a");
            await 序列化.写入txt(txtFile2, "b");
            await 序列化.合并txt(new List<string>(){ txtFile,txtFile2 }, txtFile3);
            var r = await 序列化.读出txt(txtFile3);
            Assert.True(r.IsTrue);
            Assert.Equal("ab", r.Data);
            System.IO.File.Delete(txtFile);
            System.IO.File.Delete(txtFile2);
            System.IO.File.Delete(txtFile3);
        }

        [Fact()]
        public async void 写入txtTest()
        {
            string txtFile = @"d:\"+Guid.NewGuid()+".txt";
            var r = await 序列化.写入txt(txtFile, "a");
            Assert.True(r.IsTrue);
            System.IO.File.Delete(txtFile);
        }

        [Fact()]
        public async void 追加txtTest()
        {
            string txtFile = @"d:\"+Guid.NewGuid()+".txt";
            await 序列化.追加txt(txtFile, "a");
            await 序列化.追加txt(txtFile, "b");
            var r = await 序列化.读出txt(txtFile);
            Assert.True(r.IsTrue);
            Assert.Equal("ab", r.Data);
            System.IO.File.Delete(txtFile);
        }

        [Fact()]
        public async void 读出txtTest()
        {
            string txtFile = @"d:\"+Guid.NewGuid()+".txt";
            var rr = await 序列化.写入txt(txtFile, "abcdef");
            Assert.True(rr.IsTrue);

            var r = await 序列化.读出txt(txtFile);
            Assert.True(r.IsTrue);
            Assert.Equal("abcdef", r.Data);
            System.IO.File.Delete(txtFile);
        }

        [Fact()]
        public async void 插入首行txtTest()
        {
            string txtFile = @"d:\"+Guid.NewGuid()+".txt";
            await 序列化.写入txt(txtFile, "a");
            await 序列化.插入首行txt(txtFile, "b");
            var r = await 序列化.读出txt(txtFile);
            Assert.True(r.IsTrue);
            Assert.Equal("ba", r.Data);
            System.IO.File.Delete(txtFile);
        }
    }
}