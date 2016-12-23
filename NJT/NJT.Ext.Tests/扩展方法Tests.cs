using Xunit;
using NJT.Ext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Ext.Tests
{
    public class 扩展方法Tests
    {
        [Fact()]
        public void to定长Test()
        {
            var r = new List<int>() { 1, 2, 3 };
            r.to定长(2);
            Assert.Equal(2, r.Count);

            r.Clear();
            r.to定长(2);
            Assert.Equal(0, r.Count);

            r.AddRange(new int[] { 4, 5, 6, 7, 8 });
            r.to定长(0);
            Assert.Equal(0, r.Count);

        }

        [Fact()]
        public void To文件大小Test()
        {
            var r = (long)Math.Pow(2, 20);
            Assert.Equal("1.0 MB", r.To文件大小());

            r = int.MaxValue;
            Assert.Equal("2.0 GB", r.To文件大小());

            r = long.MaxValue;
            Assert.Equal("8.0 EB", r.To文件大小());

        }

        [Fact()]
        public void To串联字符串Test()
        {
            var r= new  List<string>() {"a","b"};
            Assert.Equal("ab", r.ToJoin());
            Assert.Equal("a-b", r.ToJoin("-"));

        }
    }
}