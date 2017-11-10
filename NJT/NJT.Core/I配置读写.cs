using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Core
{
    public interface I配置读写<T>
    {
        string 配置文件名 { get; set; }
        运行结果<T> 读取();

        运行结果<T> 读取(string 文件名);

        T 读取(Func<T> 默认值);
        T 读取(Func<T> 默认值, string 文件名);

        运行结果 写入(T 配置);

        运行结果 写入(T 配置, string 文件名);

    }

    public class 配置读写<T> : I配置读写<T>
    {
        public string 配置文件名 { get; set; }

        public 配置读写(string 配置文件名x)
        {
            配置文件名 = 配置文件名x;
        }
        public 运行结果<T> 读取()
        {
            return 序列化.读出<T>(配置文件名);
        }
        public 运行结果<T> 读取(string 配置文件名x)
        {
            return 序列化.读出<T>(配置文件名x);
        }

        /// <summary>
        /// 如果读取失败,返回默认值
        /// </summary>
        /// <param name="默认值"></param>
        /// <returns></returns>
        public T 读取(Func<T> 默认值)
        {
            return 读取(默认值, 配置文件名);
        }

        public T 读取(Func<T> 默认值, string 文件名)
        {
            var read = 读取(文件名);
            return read.IsTrue ? read.Data : 默认值();
        }

        public 运行结果 写入(T 配置)
        {
            return 序列化.写入(配置, 配置文件名);
        }

        public 运行结果 写入(T 配置, string 配置文件名x)
        {
            return 序列化.写入(配置, string.IsNullOrEmpty(配置文件名x) ? 配置文件名 : 配置文件名x);
        }
    }
}
