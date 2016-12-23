using Xunit;
using NJT.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Core.Tests
{
    public class SqlServerTests
    {
        [Fact()]
        public void GetSqlConnTest()
        {
            var conn = @"Data Source=.;Initial Catalog=audio;Persist Security Info=True;User ID=sa;Password=12345;Connect Timeout=2";
            var server = new SqlServer();
            var r = server.GetSqlConn();
            Assert.Equal(conn, r);
        }
    }
}