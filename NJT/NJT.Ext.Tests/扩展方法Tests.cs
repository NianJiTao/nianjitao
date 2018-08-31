using Microsoft.VisualStudio.TestTools.UnitTesting;
using NJT.Ext;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            Assert.AreEqual("abc", t1.Item1);
            Assert.AreEqual(123, t1.Item2);
            Assert.AreEqual(3, t1.Item3);
        }

        [TestMethod()]
        public void To文件大小Test()
        {
            var r = (long) Math.Pow(2, 20);
            Assert.AreEqual("1.0 MB", r.To文件大小());

            r = int.MaxValue;
            Assert.AreEqual("2.0 GB", r.To文件大小());

            r = long.MaxValue;
            Assert.AreEqual("8.0 EB", r.To文件大小());
        }

        [TestMethod()]
        public void To百分比Test()
        {
            Assert.AreEqual("13.14%", 0.1314d.To百分比());
            Assert.AreEqual("12.00%", 0.12d.To百分比());
            Assert.AreEqual("100.00%", 1d.To百分比());
            Assert.AreEqual("0.00%", 0d.To百分比());
        }

        [TestMethod()]
        public void ToIntTest()
        {
            Assert.AreEqual(123, "123".ToInt());
            Assert.AreEqual(0, "a".ToInt());
            Assert.AreEqual(0, "1.1".ToInt());
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
            var r = new List<string>() {"a", "b"};
            Assert.AreEqual("ab", r.To串联());
            Assert.AreEqual("a-b", r.To串联("-"));
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
            var r = new List<int>() {1, 2, 3};
            r.To定长(2);
            Assert.AreEqual(2, r.Count);

            r.Clear();
            r.To定长(2);
            Assert.AreEqual(0, r.Count);

            r.AddRange(new int[] {4, 5, 6, 7, 8});
            r.To定长(0);
            Assert.AreEqual(0, r.Count);
        }

        [TestMethod()]
        public void To年月日时分秒Test()
        {
            var dt = DateTime.Now;
            var str = dt.To年月日时分秒().Replace("_", ":"); //替换后可逆转为时间
            var str1 = dt.ToString("s");
            Assert.AreEqual(str, str1);
            DateTime.TryParse(str, out DateTime dt2);
            Assert.AreEqual(dt.ToString(), dt2.ToString());
        }

        [TestMethod()]
        public void From年月日Test()
        {
            var str = "2017-03-30";
            Assert.AreEqual(true, DateTime.TryParse(str, out DateTime dt2));

            str = "20171231";
            var a = DateTime.ParseExact(str, "yyyyMMdd", CultureInfo.CurrentCulture, DateTimeStyles.AllowWhiteSpaces);
            var b = DateTime.ParseExact("20171231121212", "yyyyMMddHHmmss", CultureInfo.CurrentCulture,
                DateTimeStyles.AllowWhiteSpaces);
            var c = DateTime.ParseExact("20171231121212", "yyyyMMddHHmmss", CultureInfo.CurrentCulture,
                DateTimeStyles.None);
        }


        [TestMethod()]
        public void 长度修正Test()
        {
            Assert.AreEqual("abc ", "abc".长度修正(4));
            Assert.AreEqual("ab", "abc".长度修正(2));
        }
    }
}