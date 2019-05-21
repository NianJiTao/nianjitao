//using Xunit;
//using NJT.Ext;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace NJT.Ext.Tests
//{
//    public class 名称值test : I名称值
//    {
//        public 名称值test(string 名称, object 值)
//        {
//            this.名称 = 名称;
//            this.值 = 值;
//        }


//        public string 名称 { get; set; }
//        public object 值 { get; set; }
//    }

//    public class 反射Tests
//    {
//        [Fact()]
//        public void 赋值_正常Test()
//        {
//            var a = new SqlServer();
//            反射.赋值(a, new string[0], new I名称值[]
//            {
//                new 名称值test("用户名", "njt"),
//                new 名称值test("优先级", 9),
//            });

//            Assert.Equal("njt", a.用户名);
//            Assert.Equal(9, a.优先级);
//        }


//        [Fact()]
//        public void 赋值_带排除Test()
//        {
//            var a = new SqlServer();
//            反射.赋值(a, new string[] {"用户名"}, new I名称值[]
//            {
//                new 名称值test("用户名", "njt"),
//                new 名称值test("优先级", 9),
//            });

//            Assert.NotEqual("njt", a.用户名);
//            Assert.Equal(9, a.优先级);
//        }


//        [Fact()]
//        public void 赋值_排除为空Test()
//        {
//            var a = new SqlServer();
//            反射.赋值(a, null, new I名称值[]
//            {
//                new 名称值test("用户名", "njt"),
//                new 名称值test("优先级", 9),
//            });

//            Assert.Equal("njt", a.用户名);
//            Assert.Equal(9, a.优先级);
//        }
//    }
//}