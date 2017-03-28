using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NJT.Core
{
    public class SqlServer
    {

        public string 名称 { get; set; } = "数据库";

        public string 服务器 { get; set; } = ".";

        public string 数据库名 { get; set; } = "Db2018";

        public string 用户名 { get; set; } = "sa";

        public string 密码 { get; set; } = "12345";

        public int 优先级 { get; set; }

        public string Sql格式 { get; set; } = @"Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3};Connect Timeout=2";

        public bool Is启用 { get; set; } = true;

        [XmlIgnore]
        public bool Is正常 { get; set; } = true;

        [XmlIgnore]
        public bool 测试中 { get; set; }


        public string GetSqlConn()
        {
            return string.Format(Sql格式, 服务器, 数据库名, 用户名, 密码);
        }
        public bool 验证(object obj)
        {
            SqlConnection sql1 = null;
            测试中 = true;
            try
            {
                sql1 = new SqlConnection(GetSqlConn());
                sql1.Open();
                sql1.Close();
                Is正常 = true;
                return true;
            }
            catch
            {
                Is正常 = false;
                return false;
            }
            finally
            {
                测试中 = false;
            }
        }
    }
}
