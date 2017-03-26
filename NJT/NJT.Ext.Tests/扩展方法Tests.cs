﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NJT.Ext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Ext.Tests
{
    [TestClass()]
    public class 扩展方法Tests
    {
        [TestMethod()]
        public void To分离数值Test()
        {
            var t1 = "abc123".To分离数值();
            Assert.AreEqual("abc",t1.Item1);
            Assert.AreEqual(123, t1.Item2);
            Assert.AreEqual(3,t1.Item3);
        }

        [TestMethod()]
        public void To文件大小Test()
        {
            var r = (long)Math.Pow(2, 20);
            Assert.AreEqual("1.0 MB", r.To文件大小());

            r = int.MaxValue;
            Assert.AreEqual("2.0 GB", r.To文件大小());

            r = long.MaxValue;
            Assert.AreEqual("8.0 EB", r.To文件大小());
        }

        [TestMethod()]
        public void To百分比Test()
        {
            Assert.AreEqual("13.14%", 扩展方法.To百分比(0.1314d));
            Assert.AreEqual("12.00%", 扩展方法.To百分比(0.12d));
            Assert.AreEqual("100.00%", 扩展方法.To百分比(1d));
            Assert.AreEqual("0.00%", 扩展方法.To百分比(0d));
        }

        [TestMethod()]
        public void ToIntTest()
        {
            Assert.AreEqual(123,"123".ToInt());
            Assert.AreEqual(0,"a".ToInt());
            Assert.AreEqual(0,"1.1".ToInt());
        }

        [TestMethod()]
        public void ToString2Test()
        {
            object t = null;
            Assert.AreEqual("", t.ToString2());
        }

        [TestMethod()]
        public void To目录合并Test()
        {
            Assert.AreEqual(@"d:\a\b", "d:\\a".To目录合并("b"));
        }

        [TestMethod()]
        public void Get首字母Test()
        {
            Assert.AreEqual("NJT", "年纪涛".Get首字母());
        }

        [TestMethod()]
        public void ToHexStringTest()
        {
        }

        [TestMethod()]
        public void HexToByteTest()
        {
        }

        [TestMethod()]
        public void ToJoinTest()
        {
            var r = new List<string>() { "a", "b" };
            Assert.AreEqual("ab", r.ToJoin());
            Assert.AreEqual("a-b", r.ToJoin("-"));
        }

        [TestMethod()]
        public void CreatDirTest()
        {
        }

        [TestMethod()]
        public void ToSpiltTest()
        {
        }

        [TestMethod()]
        public void to定长Test()
        {
            var r = new List<int>() { 1, 2, 3 };
            r.to定长(2);
            Assert.AreEqual(2, r.Count);

            r.Clear();
            r.to定长(2);
            Assert.AreEqual(0, r.Count);

            r.AddRange(new int[] { 4, 5, 6, 7, 8 });
            r.to定长(0);
            Assert.AreEqual(0, r.Count);
        }
    }
}