using NJT.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NJT.Core.Tests
{
    public class 命令行参数Tests
    {
        [Fact]
        public void 提取Test()
        {
            var str = "-消息 内容 标题".Split(' ');
            var 参数 = new 命令行参数();
            var find = 参数.提取(str, "-消息", 3);
            Assert.Equal("内容", find[1]);
            Assert.Equal("标题", find[2]);

            str = "-消息 内容".Split(' ');

            find = 参数.提取(str, "-消息", 3);
            Assert.Equal("内容", find[1]);
            //Assert.Equal("", find[2]);
        }
    }
}