using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Core
{
    public class 命令行参数
    {

        /// <summary>
        /// -消息 内容 标题
        /// </summary>
        /// <param name="源"></param>
        /// <param name="标识"></param>
        /// <param name="长度"></param>
        /// <returns></returns>
        public string[] 提取(string[] 源, string 标识, int 长度)
        {
            var find = Array.FindIndex(源, x => x == 标识);
            if (find >= 0)
            {
                var find2 = 源.Skip(find).Take(长度).ToArray();
                return find2;
            }
            else
            {
                return new string [0];
            }
        }
    }
}