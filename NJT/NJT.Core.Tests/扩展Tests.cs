using Xunit;
using NJT.Ext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Ext.Tests
{
    public class 扩展Tests
    {
        [Fact()]
        public void HexToByteTest()
        {
            Assert.Equal(new byte[] { 21 }, "15".HexToByte());
        }

        [Fact()]
        public void To分割Test()
        {
            Assert.Equal("a", "a,;b".To分割(",;")[0]);
            Assert.Equal("a", "a;b".To分割(",;")[0]);
        }

        [Fact()]
        public void 长度修正Test()
        {
            string a = null;
            a.长度修正(3);
            Assert.Equal("   ", a.长度修正(3));
        }

        [Fact()]
        public void 数字长度修正Test()
        {
            string a = null;
            a.长度修正(3);
            Assert.Equal("000", a.数字长度修正(3));
        }
    }
}