using Xunit;
using NJT.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Core.Tests
{
    public class 斐波纳Tests
    {
        [Fact()]
        public void Get通用解Test()
        {
            Assert.Equal(1556111435, 斐波纳.Get尾递归解(1000));
            int[] a = new int[]
            {
                0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946, 17711
            };

            for (int i = 0; i < a.Length; i++)
            {
                Assert.Equal(a[i], 斐波纳.Get通用解(i));
            }
        }
        [Fact()]
        public void Get尾递归解Test()
        {
            Assert.Equal(1556111435, 斐波纳.Get尾递归解(1000));

            int[] a = new int[]
            {
                0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946, 17711
            };

            for (int i = 0; i < a.Length; i++)
            {
                Assert.Equal(a[i], 斐波纳.Get尾递归解(i));
            }
        }
    }
}