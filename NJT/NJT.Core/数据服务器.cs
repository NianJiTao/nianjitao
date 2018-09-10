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

        /// <summary>
        /// 当前使用的Server ,自动切换启用,正常的Server,如果都不正常,返回Server1
        /// </summary>
        public SqlServer CurServer
        {
            get
            {
                var f = SQL.Values.FirstOrDefault(x => x != null && x.Is可读写);
                return f ?? SQL.Values.FirstOrDefault();
            }
        }

        public SqlServer SqlServer1 => SQL[0];
        public SqlServer SqlServer2 => SQL[1];
        public SqlServer SqlServer3 => SQL[2];
        public SqlServer SqlServer4 => SQL[3];
        public IDictionary<int, SqlServer> SQL { get; } = new ConcurrentDictionary<int, SqlServer>();

        public static string GetSql格式()
        {
            return
                "data source={0};initial catalog={1};persist security info=True;user id={2};password={3};connect timeout=5;connectretrycount=3;MultipleActiveResultSets=True;App=EntityFramework";
        }

        /// <summary>
        /// 返回本机sql,可用户名登录的连接字串
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public static string Get连接字符串(string db)
        {
            return
                $"data source =.;initial catalog = {db};integrated security = True;MultipleActiveResultSets = True;App = EntityFramework";
        }
    }
}