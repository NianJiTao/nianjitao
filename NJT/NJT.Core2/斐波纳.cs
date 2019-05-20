using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Core
{
    public static class 斐波纳
    {
        /// <summary>
        /// 通用解法
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static long Get通用解(int n)
        {
            if (n <= 1)
                return n;
            var b = Math.Sqrt(5);
            return (long) ((Math.Pow((1 + b) / 2, n) - Math.Pow((1 - b) / 2, n)) / b);
        }


        public static long Get尾递归解(int n)
        {
            if (n < 2)
                return n;
            return fib(n, 0, 1, 2);
        }


        private static long fib(int n, int l1, int l2, int l3)
        {
            if (n == l3)
            {
                return l1 + l2;
            }

            l3++;
            return fib(n, l2, l1 + l2, l3);
        }
    }
}