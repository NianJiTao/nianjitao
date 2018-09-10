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
        public void ToFloat2Test()
        {
            Assert.Equal(2f, "2".ToFloat2());
            Assert.Equal(2.2f, "2.2".ToFloat2());
            Assert.Equal(2f, ((object) 2f).ToFloat2());
        }

        [Fact()]
        public void ToIntTest()
        {
            Assert.Equal(123, "123".ToInt());
            Assert.Equal(0, "a".ToInt());
            Assert.Equal(1, "1.1".ToInt());
        }

        [Fact()]
        public void ToString2Test()
        {
            Assert.Equal(string.Empty, ((object) null).ToString2());
        }

        [Fact()]
        public void ToDouble2Test()
        {
            Assert.Equal(2d, "2".ToDouble2());
            Assert.Equal(2.2d, "2.2".ToDouble2());
            Assert.Equal(2d, ((object) 2d).ToDouble2());
        }

        [Fact()]
        public void ToDateTimeTest()
        {
            Assert.True(false, "This test needs an implementation");
        }


        [Fact()]
        public void ToIntTest1()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void ToString2Test1()
        {
            Assert.True(false, "This test needs an implementation");
        }


        [Fact()]
        public void ToDateTimeTest1()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void Get静态属性Test()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void Get静态字段Test()
        {
            Assert.True(false, "This test needs an implementation");
        }


        [Fact()]
        public void NotNullDoTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void GetListTest()
        {
            Array r = new int[] {1, 2};
            r.GetList<int>();
            Assert.Equal(2, r.GetList<int>().Count);
        }

        [Fact()]
        public void IfDoTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void 范围限制Test()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void 选择Test()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void 移除Test()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void 移除Test1()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void 上移Test()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void 下移Test()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void 交换Test()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void 随机选取Test()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void 洗牌Test()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void To定长Test()
        {
            Assert.Equal(2, new List<int> {1, 2, 3}.To定长(2).Count);
            Assert.Empty(new List<int>().To定长(2));
            Assert.Empty(new List<int> {1, 2, 3}.To定长(0));
        }

        [Fact()]
        public void AddAndMaxTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void AddAndMaxTest1()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void ForEachDoTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void IndexOf2Test()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void 分组Test()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void To串联Test()
        {
            var r = new List<string>() {"a", "b"};
            Assert.Equal("ab", r.To串联());
            Assert.Equal("a-b", r.To串联("-"));
        }

        [Fact()]
        public void Is空Test()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void To时分秒Test()
        {
            Assert.Equal("17点30分15秒", new DateTime(2017, 9, 10, 17, 30, 15).To时分秒());
            Assert.Equal("0点0分0秒", DateTime.MinValue.To时分秒());
        }

        [Fact()]
        public void To年月日时分秒Test()
        {
            Assert.Equal("2017年9月10日17点30分15秒", new DateTime(2017, 9, 10, 17, 30, 15).To年月日时分秒());
            Assert.Equal("0000年1月1日0点0分0秒", DateTime.MinValue.To年月日时分秒());
        }

        [Fact()]
        public void To星期Test()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void DateTimeTo整秒Test()
        {
            Assert.Equal(DateTime.MinValue, DateTime.MinValue.AddMilliseconds(100).To整秒());
            Assert.Equal(DateTime.Today, DateTime.Today.AddMilliseconds(100).To整秒());
        }

        [Fact()]
        public void TimeSpanTo整秒Test1()
        {
            Assert.Equal(new TimeSpan(0, 1, 1, 1, 0), new TimeSpan(0, 1, 1, 1, 1).To整秒());
        }

        [Fact()]
        public void Get顺序号Test()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void To求和Test()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void 小数位Test()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void 小数位Test1()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void 小数位Test2()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void ToProgressValTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void ToProgressValTest1()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void ConvertToBCDTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void ConvertBCDToIntTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void To文件大小Test()
        {
            Assert.Equal("1.0 MB", ((long) Math.Pow(2, 20)).To文件大小());
            Assert.Equal("2.0 GB", ((long) int.MaxValue).To文件大小());
            Assert.Equal("8.0 EB", long.MaxValue.To文件大小());
        }

        [Fact()]
        public void To百分比Test()
        {
            Assert.Equal("13.14%", 0.1314d.To百分比());
            Assert.Equal("12.00%", 0.12d.To百分比());
            Assert.Equal("100.00%", 1d.To百分比());
            Assert.Equal("0.00%", 0d.To百分比());
        }

        [Fact()]
        public void ToHexStringTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void 长度修正Test()
        {
            Assert.Equal("ab  ", "ab".长度修正(4));
            Assert.Equal("ab", "abc".长度修正(2));
            Assert.Equal("   ", ((string) null).长度修正(3));
        }

        [Fact()]
        public void 数字长度修正Test()
        {
            Assert.Equal("001", "1".数字长度修正(3));
            Assert.Equal("000", ((string) null).数字长度修正(3));
        }

        [Fact()]
        public void ToTimeSpanTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void GetListTest1()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void GetStringTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void GetFileNameTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void ToBoolTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void Remove2Test()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void Substring2Test()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void ToString00NTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void Remove非文件名字符Test()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void Remove非目录字符Test()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void Remove字符Test()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void To分离数值Test()
        {
            var t1 = "abc123".To分离数值();
            Assert.Equal("abc", t1.Item1);
            Assert.Equal(123, t1.Item2);
            Assert.Equal(3, t1.Item3);
        }

        [Fact()]
        public void ToFloatTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void To目录合并Test()
        {
            Assert.Equal(@"d:\a\b", "d:\\a".To目录合并("b"));
            Assert.Equal(@"d:\a\b", "d:\\a\\".To目录合并("\\b"));
        }

        [Fact()]
        public void To合并文件名Test()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void Get首字母Test()
        {
            Assert.Equal("NJT", "年纪涛".Get首字母());
        }

        [Fact()]
        public void HexToByteTest()
        {
            Assert.Equal(new byte[] {21}, "15".HexToByte());
        }

        [Fact()]
        public void CreatDirTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void To分割Test()
        {
            var r = "a;b;".To分割();
            Assert.Equal(2, r.Length);
            Assert.Equal("a", r[0]);
            Assert.Equal("b", r[1]);

            Assert.Equal("a", "a,;b".To分割(",;")[0]);
            Assert.Equal("a", "a;b".To分割(",;")[0]);
        }

        [Fact()]
        public void 等于Test()
        {
            Assert.True("a".等于("A"));
            Assert.True("".等于(""));
            Assert.False("a".等于(""));
        }


        [Fact()]
        public void ToDoubleTest()
        {
            Assert.Equal(2d, "2".ToDouble());
            Assert.Equal(2.2d, "2.2".ToDouble());
            Assert.Equal(0d, "0".ToDouble());
            Assert.Equal(0d, "a".ToDouble());
        }

        [Fact()]
        public void 等于OrBoolTest()
        {
            Assert.True("true".等于OrBool("1"));
            Assert.True("1".等于OrBool("1"));
            Assert.True("a".等于OrBool("a"));
            Assert.False("false".等于OrBool("1"));
            Assert.False("false".等于OrBool(""));
        }

        [Fact()]
        public void GetDateTime14Test()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void GetDateTime8Test()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void GetDateTimeTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void 更新Test()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void Get时间差Test()
        {
            Assert.Equal(TimeSpan.Zero, 扩展.Get时间差(null, null));
            Assert.Equal(TimeSpan.Zero, 扩展.Get时间差(DateTime.Today, null));
            Assert.Equal(TimeSpan.Zero, 扩展.Get时间差(DateTime.Today, DateTime.Today));
            Assert.Equal(TimeSpan.FromHours(1), 扩展.Get时间差(DateTime.Today, DateTime.Today.AddHours(1)));
        }
    }
}