using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NJT.Core;

namespace NJT.Prism
{
    public class 连接验证
    {
        public async Task<I运行结果> 验证Async(SqlServer sql1)
        {
            var r = await Task.Run(() => 验证2(sql1));
            return r;
        }


        public I运行结果 验证2(SqlServer sql2)
        {
            var sql = sql2;
            if (sql.测试中)
            {
                return new 运行结果(false, "测试中");
            }

            sql.测试中 = true;
            try
            {
                var sql1 = new SqlConnection(sql.GetUseConn());
                sql1.Open();
                sql1.Close();
                sql.Is正常 = true;
                return new 运行结果(true);
            }
            catch (Exception e)
            {
                sql.Is正常 = false;
                return new 运行结果(false, e.Message);
            }
            finally
            {
                sql.测试中 = false;
            }
        }
    }
}
