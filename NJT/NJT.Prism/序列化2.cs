using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NJT.Core;
using NJT.Ext;

namespace NJT.Prism
{
    public static partial class 序列化2
    {
        public static void 异步写入<T>(T config, string fileName)
        {
            if (config == null)
                return;
            if (string.IsNullOrEmpty(fileName))
                return;
            fileName.CreatDir();
            Task.Factory.StartNew(() => { 序列化.写入(config, fileName); });
        }
    }
}
