using NJT.Ext;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NJT.Core;
using NJT.Ext.Core;
using Xunit;

namespace NJT.Ext.Tests
{
    public class 扩展Tests
    {
        public class testA
        {
            public static string B { get; set; } = "b";
            public string Name { get; set; } = "";
            [禁止克隆] public string NoClone { get; set; } = "";
        }

        [Fact]
        public void AddAndMaxTest()
        {
            var r = Enumerable.Range(1, 5).ToList();
            r.AddAndMax(6, 5);
            Assert.Equal(2, r.First());
        }

        [Fact]
        public void AddAndMaxTest1()
        {
            var r = Enumerable.Range(1, 5).ToObservabler();
            r.AddAndMax(6, 5);
            Assert.Equal(2, r.First());
        }

        [Fact]
        public void ConvertBCDToIntTest()
        {
            Assert.Equal(20, ((byte) 32).ConvertBCDToInt());
        }


        [Fact]
        public void ConvertToBCDTest()
        {
            Assert.Equal(32, ((byte) 20).ConvertToBCD());
        }

        [Fact]
        public void CreatDirTest()
        {
            var dir1 = "d:\\temp\\" + Guid.NewGuid().ToString().Remove(5);
            var a = dir1.CreatDir();
            Assert.True(a.Item1, a.Item2);
            Directory.Delete(dir1);
        }

        [Fact]
        public void DateTimeTo整秒Test()
        {
            Assert.Equal(DateTime.MinValue, DateTime.MinValue.AddMilliseconds(100).To整秒());
            Assert.Equal(DateTime.Today, DateTime.Today.AddMilliseconds(100).To整秒());
        }

        [Fact]
        public void ForEachDoTest()
        {
            var r = Enumerable.Range(1, 5).Select(x => new 运行结果(false)).ToList();
            r.ForEachDo(x => x.IsTrue = true);
            Assert.True(r.All(x => x.IsTrue));
        }

        [Fact]
        public void GetDateTime14Test()
        {
            Assert.Equal(new DateTime(2020, 1, 2, 3, 4, 5), "20200102030405".GetDateTime14());
        }

        [Fact]
        public void GetDateTime8Test()
        {
            Assert.Equal(new DateTime(2020, 1, 2), "20200102".GetDateTime8());
        }

        [Fact]
        public void GetDateTimeTest()
        {
            Assert.Equal(new DateTime(2018, 1, 1), "2018-01-01".GetDateTime("yyyy-MM-dd"));
        }

        [Fact]
        public void GetFileNameTest()
        {
            Assert.Equal("abc", "d:\\abc.txt".GetFileName());
            Assert.Equal("abc", "abc.txt".GetFileName());
        }

        [Fact]
        public void GetListTest()
        {
            Array r = new[] {1, 2};
            r.GetList<int>();
            Assert.Equal(2, r.GetList<int>().Count);
        }

        [Fact]
        public void GetNumberTest()
        {
            Assert.Equal(1, "第1段".GetNumber());
            Assert.Equal(16, "第16段".GetNumber());
            Assert.Equal(16, "第16".GetNumber());
            Assert.Equal(16, "16段".GetNumber());
            Assert.Equal(0, "段".GetNumber());
            Assert.Equal(0, "".GetNumber());
            Assert.Equal(1, "1a2".GetNumber());
        }


        [Fact]
        public void GetStringTest()
        {
            Assert.Equal("年纪涛", Encoding.UTF8.GetBytes("年纪涛").GetString());
            Assert.Equal("abc", Encoding.UTF8.GetBytes("abc").GetString());
        }

        //[Fact]
        //public void Get参数值Test()
        //{
        //    var a = new EData<EData<string>>("a1", new EData<string>("a2", "v2"));
        //    Assert.Equal("v2", a.Get参数值("Data.Data").Data);
        //    Assert.Equal("a2", a.Get参数值("Data.Name").Data);
        //    Assert.Equal("a1", a.Get参数值("Name").Data);
        //}

        [Fact]
        public void Get静态属性Test()
        {
            Assert.True(typeof(testA).Get静态属性().Any());
        }

        [Fact]
        public void Get静态字段Test()
        {
            Assert.True(typeof(常量).Get静态字段().Any());
        }

        [Fact]
        public void Get时间差Test()
        {
            Assert.Equal(TimeSpan.Zero, NJT.Ext.Core.扩展.Get时间差(null, null));
            Assert.Equal(TimeSpan.Zero, NJT.Ext.Core.扩展.Get时间差(DateTime.Today, null));
            Assert.Equal(TimeSpan.Zero, NJT.Ext.Core.扩展.Get时间差(DateTime.Today, DateTime.Today));
            Assert.Equal(TimeSpan.FromHours(1), NJT.Ext.Core.扩展.Get时间差(DateTime.Today, DateTime.Today.AddHours(1)));
        }

        [Fact]
        public void Get首字母Test()
        {
            Assert.Equal("NJT", 拼音.首字母("年纪涛"));
            Assert.Equal("NJT",("年纪涛".Get首字母()));
        }

        [Fact]
        public void Get顺序号Test()
        {
            Assert.Equal(1, DateTime.Today.Get顺序号());
            Assert.Equal(2, DateTime.Today.Get顺序号());
            Assert.Equal(1, DateTime.Today.AddDays(1).Get顺序号());
            Assert.Equal(2, DateTime.Today.AddDays(1).Get顺序号());
        }

        [Fact]
        public void HexToByteTest()
        {
            Assert.Equal(new byte[] {21}, "15".HexToByte());
            //Convert.ToInt64("0x"+"F", 16);
            Assert.Equal(15,  Convert.ToInt64("0x" + "F", 16));
            //Assert.Equal(new byte[] {15}, "F".HexToByte());
        }

        [Fact]
        public void IfDoTest()
        {
            var a = new 标识Data1 {标识 = "a", 数据 = "1"};

            a.IfDo(x =>
            {
                x.数据 = "2";
                return x;
            }, x => x.标识 == "a");

            Assert.Equal("2", a.数据);
        }

        [Fact]
        public void IndexOf2Test()
        {
            var r = new List<string> {"a", "b"};
            Assert.Equal(-1, r.IndexOf2(x => x == "c"));
            Assert.Equal(1, r.IndexOf2(x => x == "b"));
        }

        [Fact]
        public void Is空Test()
        {
            var r = new List<string> {"a"};
            Assert.False(r.Is空());
            Assert.True(new List<string>().Is空());
        }


        [Fact]
        public void NotNullDoTest()
        {
            (null as 运行结果).NotNullDo(x => x.Message = "b");
            Assert.Equal("a", new 运行结果(true).NotNullDo(x => x.Message = "a").Message);
        }

        [Fact]
        public void Remove2Test()
        {
            Assert.Equal("a", "abcde".Remove2(1, 10));
            Assert.Equal("", "ab".Remove2(3, 10));
        }

        [Fact]
        public void Remove非目录字符Test()
        {
            Assert.Equal("abc", "abc<>".Remove非目录字符());
        }

        [Fact]
        public void Remove非文件名字符Test()
        {
            Assert.Equal("abc", "abc\\".Remove非文件名字符());
        }

        [Fact]
        public void Remove字符Test()
        {
            Assert.Equal("ab", "abc".Remove字符(new[] {'c'}));
        }

        [Fact]
        public void Substring2Test()
        {
            Assert.Equal("cd", "abcde".Substring2(2, 2));
            Assert.Equal("cde", "abcde".Substring2(2, 5));
        }

        [Fact]
        public void TimeSpanTo整秒Test1()
        {
            Assert.Equal(new TimeSpan(0, 1, 1, 1, 0), new TimeSpan(0, 1, 1, 1, 1).To整秒());
        }

        [Fact]
        public void ToBoolTest()
        {
            Assert.True("true".ToBool());
            Assert.True("1".ToBool());
            Assert.False("0".ToBool());
        }

        [Fact]
        public void ToDateTimeTest()
        {
            Assert.Equal(new DateTime(2020, 1, 2, 3, 4, 5), new DateTime(2020, 1, 2, 3, 4, 5).ToDateTime2());
            Assert.Equal(new DateTime(2020, 1, 2, 3, 4, 5),
                new DateTime(2020, 1, 2, 3, 4, 5).ToString().ToDateTime2());
        }

        [Fact]
        public void ToDouble2Test()
        {
            Assert.Equal(2d, "2".ToDouble2());
            Assert.Equal(2.2d, "2.2".ToDouble2());
            Assert.Equal(2d, ((object) 2d).ToDouble2());
        }


        [Fact]
        public void ToDoubleTest()
        {
            Assert.Equal(2d, "2".ToDouble());
            Assert.Equal(2.2d, "2.2".ToDouble());
            Assert.Equal(0d, "0".ToDouble());
            Assert.Equal(0d, "a".ToDouble());
        }

        [Fact]
        public void ToFloat2Test()
        {
            Assert.Equal(2f, "2".ToFloat2());
            Assert.Equal(2.2f, "2.2".ToFloat2());
            Assert.Equal(2f, ((object) 2f).ToFloat2());
        }

        [Fact]
        public void ToFloatTest()
        {
            Assert.Equal(1.1f, "1.1".ToFloat());
            Assert.Equal(1f, "1".ToFloat());
        }

        [Fact]
        public void ToHexStringTest()
        {
            Assert.Equal("000A", new byte[] {0, 10}.ToHexString());
            Assert.Equal("0F0F", new byte[] {15, 15}.ToHexString());
        }

        [Fact]
        public void ToIntTest()
        {
            Assert.Equal(123, "123".ToInt());
            Assert.Equal(0, "a".ToInt());
            Assert.Equal(0, "1.1".ToInt());
        }


        [Fact]
        public void ToProgressVal_double_Test()
        {
            Assert.Equal(57, 0.566d.ToProgressVal());
            Assert.Equal(56, 0.56d.ToProgressVal());
            Assert.Equal(0, (-0.1d).ToProgressVal());
            Assert.Equal(100, 1.1d.ToProgressVal());
        }

        [Fact]
        public void ToProgressVal_float_Test()
        {
            Assert.Equal(56, 0.56f.ToProgressVal());
            Assert.Equal(57, 0.566f.ToProgressVal());
            Assert.Equal(0, (-0.1f).ToProgressVal());
            Assert.Equal(100, 1.1f.ToProgressVal());
        }

        [Fact]
        public void ToString00NTest()
        {
            Assert.Equal("002", 2.ToString00N(3));
            Assert.Equal("02", 2.ToString00N(2));
            Assert.Equal("2", 2.ToString00N(0));
        }

        [Fact]
        public void ToString2Test()
        {
            Assert.Equal(string.Empty, ((object) null).ToString2());
            Assert.Equal("a", "a".ToString2());
        }

        [Fact]
        public void ToTimeSpanTest()
        {
            Assert.Equal(TimeSpan.Zero, 0.ToTimeSpan());
            Assert.Equal(TimeSpan.FromSeconds(1), 1.ToTimeSpan());
        }

        [Fact]
        public void To百分比Test()
        {
            Assert.Equal("13.14%", 0.1314d.To百分比());
            Assert.Equal("12.00%", 0.12d.To百分比());
            Assert.Equal("100.00%", 1d.To百分比());
            Assert.Equal("0.00%", 0d.To百分比());
        }

        [Fact]
        public void To串联Test()
        {
            var r = new List<string> {"a", "b"};
            Assert.Equal("ab", r.To串联());
            Assert.Equal("a-b", r.To串联("-"));
        }


        [Fact]
        public void To定长Test()
        {
            Assert.Equal(2, new List<int> {1, 2, 3}.To定长(2).Count);
            Assert.Empty(new List<int>().To定长(2));
            Assert.Empty(new List<int> {1, 2, 3}.To定长(0));
        }

        [Fact]
        public void To分割Test()
        {
            var r = "a;b;".To分割();
            Assert.Equal(2, r.Length);
            Assert.Equal("a", r[0]);
            Assert.Equal("b", r[1]);

            Assert.Equal("a", "a,;b".To分割(",;")[0]);
            Assert.Equal("a", "a;b".To分割(",;")[0]);
        }

        [Fact]
        public void To分离数值Test()
        {
            var t1 = "abc123".To分离数值();
            Assert.Equal("abc", t1.Item1);
            Assert.Equal(123, t1.Item2);
            Assert.Equal(3, t1.Item3);
        }

        [Fact]
        public void To合并文件名Test()
        {
            Assert.Equal(@"d:\a\b.txt", "d:\\a".To合并文件名("b.txt"));
        }

        [Fact]
        public void To目录合并Test()
        {
            Assert.Equal(@"d:\a\b", "d:\\a".To目录合并("b"));
            Assert.Equal(@"d:\a\b", "d:\\a\\".To目录合并("b"));
        }

        [Fact]
        public void To年月日时分秒Test()
        {
            Assert.Equal("2017-09-10T17_30_15", new DateTime(2017, 9, 10, 17, 30, 15).To年月日时分秒());
            Assert.Equal("0001-01-01T00_00_00", DateTime.MinValue.To年月日时分秒());
        }

        [Fact]
        public void To求和Test()
        {
            var a = Enumerable.Range(1, 3).Select(x => new TimeSpan(0, 0, x)).ToList();
            Assert.Equal(TimeSpan.FromSeconds(6), a.To求和());
        }

        [Fact]
        public void To时分秒Test()
        {
            Assert.Equal("17:30:15", new DateTime(2017, 9, 10, 17, 30, 15).To时分秒());
            Assert.Equal("00:00:00", DateTime.MinValue.To时分秒());
        }

        [Fact]
        public void To文件大小Test()
        {
            Assert.Equal("1.0 MB", ((long) Math.Pow(2, 20)).To文件大小());
            Assert.Equal("2.0 GB", ((long) int.MaxValue).To文件大小());
            Assert.Equal("8.0 EB", long.MaxValue.To文件大小());
        }

        [Fact]
        public void To星期Test()
        {
            Assert.Equal("星期三", new DateTime(2020, 1, 1).To星期());
        }

        [Fact]
        public void 等于OrBoolTest()
        {
            Assert.True("true".等于OrBool("1"));
            Assert.True("1".等于OrBool("1"));
            Assert.True("a".等于OrBool("a"));
            Assert.False("false".等于OrBool("1"));
            Assert.False("false".等于OrBool(""));
        }

        [Fact]
        public void 等于Test()
        {
            Assert.True("a".等于("A"));
            Assert.True("".等于(""));
            Assert.False("a".等于(""));
        }

        [Fact]
        public void 范围限制Test()
        {
            Assert.Equal(1, 0.范围限制(1, 10));
            Assert.Equal(10, 100.范围限制(1, 10));
            Assert.Equal(0d, (-0.3d).范围限制(0, 1));
            Assert.Equal(1d, 2.3d.范围限制(0, 1));
        }

        [Fact]
        public void 分组_异常分_Test1()
        {
            var r = Enumerable.Range(1, 10).分组(3).ToList();
            Assert.Equal(4, r.Count);
            Assert.True(r.Last().Count == 1);
        }

        [Fact]
        public void 分组_正常分_Test1()
        {
            var r = Enumerable.Range(1, 50).分组(10).ToList();
            Assert.Equal(5, r.Count);
            Assert.True(r.All(x => x.Count == 10));
        }

        [Fact]
        public void 分组Test()
        {
            var r = Enumerable.Range(1, 50).分组(5, 10).ToList();
            Assert.Equal(5, r.Count);
            Assert.True(r.All(x => x.Count == 10));
        }

        [Fact]
        public void 更换扩展名Test()
        {
            Assert.Equal("d:\\a.pdf", "d:\\a.xlsx".更换扩展名(".pdf"));
            Assert.Equal("d:\\a.pdf", "d:\\a.xlsx".更换扩展名("pdf"));
            Assert.Equal("a.pdf", "a.dat".更换扩展名(".pdf"));
            Assert.Equal("a.pdf", "a.b".更换扩展名(".pdf"));
            Assert.Equal("a.pdf", "a.xlsx".更换扩展名(".pdf"));
        }

        [Fact]
        public void 更新Test()
        {
            var r = new Dictionary<string, int> {{"a", 1}, {"b", 2}};
            r.更新("a", 3);
            r.更新("d", 4);
            Assert.Equal(3, r["a"]);
            Assert.Equal(4, r["d"]);
        }

        [Fact]
        public void 交换Test()
        {
            var r = Enumerable.Range(1, 2).ToList();
            Assert.True(r.交换(0, 1));
            Assert.Equal(2, r[0]);
        }


        [Fact]
        public void 上移Test()
        {
            var r = Enumerable.Range(1, 2).ToList();
            Assert.True(r.上移(1));
            Assert.Equal(2, r[0]);
        }

        [Fact]
        public void 数字长度修正Test()
        {
            Assert.Equal("001", "1".数字长度修正(3));
            Assert.Equal("000", ((string) null).数字长度修正(3));
        }

        [Fact]
        public void 下移Test()
        {
            var r = Enumerable.Range(1, 2).ToList();
            Assert.True(r.下移(0));
            Assert.Equal(2, r[0]);
        }

        [Fact]
        public void 小数位_double_Test1()
        {
            Assert.Equal(1.235d, 1.23456.小数位());
            Assert.Equal(1.2d, 1.23456.小数位(1));
            Assert.Equal(1d, 1.23456.小数位(0));
        }

        [Fact]
        public void 小数位_float_Test()
        {
            Assert.Equal(1.235f, 1.23456f.小数位());
            Assert.Equal(1.2f, 1.23456f.小数位(1));
            Assert.Equal(1f, 1.23456f.小数位(0));
        }

        [Fact]
        public void 选择Test()
        {
            Assert.Equal(2, Enumerable.Range(1, 10).ToList().选择(1));
            Assert.Equal(1, Enumerable.Range(1, 10).ToList().选择(-1));
            Assert.Equal(10, Enumerable.Range(1, 10).ToList().选择(11));
        }

        [Fact]
        public void 移除Test()
        {
            Assert.Equal("c", new List<string> {"a", "b", "c"}.移除("b"));
            Assert.Equal("b", new List<string> {"a", "b", "c"}.移除("a"));
            Assert.Equal("b", new List<string> {"a", "b", "c"}.移除("c"));
        }

        [Fact]
        public void 长度修正Test()
        {
            Assert.Equal("ab  ", "ab".长度修正(4));
            Assert.Equal("ab", "abc".长度修正(2));
            Assert.Equal("   ", ((string) null).长度修正(3));
        }

        [Fact()]
        public void 反射克隆值Test()
        {
            var a = new testA().反射克隆值(new testA() {Name = "a1", NoClone = "a2"});
            Assert.Equal("a1", a.Name);
            Assert.Equal("", a.NoClone);
        }

      
        [Fact]
        public void 毫秒Test()
        {
            Assert.Equal(TimeSpan.Zero, 0.毫秒());
            Assert.Equal(TimeSpan.FromMilliseconds(2),  2.毫秒());
            Assert.Equal(TimeSpan.FromMilliseconds(-2),  -2.毫秒());
        }
        [Fact]
        public void 秒Test()
        {
            Assert.Equal(TimeSpan.Zero, 0.秒());
            Assert.Equal(TimeSpan.FromSeconds(2), 2.秒());
            Assert.Equal(TimeSpan.FromSeconds(-2), -2.秒());
        }
        [Fact]
        public void 分钟Test()
        {
            Assert.Equal(TimeSpan.Zero, 0.分钟());
            Assert.Equal(TimeSpan.FromMinutes(2), 2.分钟());
            Assert.Equal(TimeSpan.FromMinutes(-2), -2.分钟());
        }
        [Fact]
        public void 小时Test()
        {
            Assert.Equal(TimeSpan.Zero, 0.小时());
            Assert.Equal(TimeSpan.FromHours(2), 2.小时());
            Assert.Equal(TimeSpan.FromHours(-2), -2.小时());
        }
        [Fact]
        public void GetList2Test()
        {
            Assert.Equal(2, 2.GetList<名称1>().Count);
            Assert.Equal(new 名称1().名称, 2.GetList<名称1>()[0].名称);
        }
    }
}