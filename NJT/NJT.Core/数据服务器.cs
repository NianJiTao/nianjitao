using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Core
{
    public class 数据服务器
    {

        public 数据服务器()
        {
            SQL.Add(0, new SqlServer());
            SQL.Add(1, new SqlServer());
            SQL.Add(2, new SqlServer());
            SQL.Add(3, new SqlServer());
        }

        public SqlServer CurServer
        {
            get
            {
                var f = SQL.Values.FirstOrDefault(x => x.Is可读写);
                return f ?? SQL.Values.FirstOrDefault();
            }
        }

        public IDictionary<int, SqlServer> SQL { get; } = new ConcurrentDictionary<int, SqlServer>();
    }
}