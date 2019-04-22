using Xunit;
using NJT.Prism;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Prism.Tests
{
    public class RunUnityTests
    {
        [Fact()]
        public void ResolveOrInit_自动初始化Test()
        {
            //var container1 = new UnityContainer()
            //var a = container1.ResolveOrInit<HashSet<string>>("自动确认");
            //a.Add("a");
            //var b = container1.ResolveOrInit<HashSet<string>>("自动确认");
            //Assert.Contains("a", b);

            //var c = container1.ResolveOrInit<IList<string>>("自动确认", () => new List<string>());
            //c.Add("c");
            //c = container1.ResolveOrInit<IList<string>>("自动确认", () => new List<string>());
            //Assert.Contains("c", c);
        }
    }
}