using System;
//using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NJT.Core
{
    public class SqlServer
    {
        [XmlAttribute] public string 名称 { get; set; } = "数据库";

        [XmlAttribute] public string 服务器 { get; set; } = ".";

        [XmlAttribute] public string 数据库名 { get; set; } = "Db2018";

        [XmlAttribute] public string 用户名 { get; set; } = "sa";

        [XmlAttribute] public string 密码 { get; set; } = "123456";

        [XmlAttribute] public bool Is启用 { get; set; } = true;

        [XmlAttribute] public int 优先级 { get; set; }


        /// <summary>
        /// 如果true, 直接使用连接字符串.
        /// </summary>
        [XmlAttribute]
        public bool Is系统账户登录 { get; set; }

        public string Sql格式 { get; set; } =
            @"Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3};Connect Timeout=2";

        public string 连接字符串 { get; set; } =
            @"data source=.;initial catalog=Db2018;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";

        [XmlIgnore] public bool Is正常 { get; set; } = true;

        [XmlIgnore] public bool 测试中 { get; set; }

        [XmlIgnore] public bool Is可读写 => Is启用 && Is正常;


        public string GetSqlConn()
        {
            return string.Format(Sql格式, 服务器, 数据库名, 用户名, 密码);
        }


        ///// <summary>
        ///// 建议使用验证2
        ///// </summary>
        ///// <param name="obj"></param>
        ///// <returns></returns>
        //public bool 验证(object obj)
        //{
        //    return 验证2().IsTrue;
        //}


        //public async Task<I运行结果> 验证Async()
        //{
        //    var r = await Task.Run(() => 验证2());
        //    return r;
        //}


        //public I运行结果 验证2()
        //{
        //    if (测试中)
        //    {
        //        return new 运行结果(false, "测试中");
        //    }

        //    测试中 = true;
        //    try
        //    {
        //        var constr = GetUseConn();
        //        var sql1 = new SqlConnection(constr);
        //        sql1.Open();
        //        sql1.Close();
        //        Is正常 = true;
        //        return new 运行结果(true);
        //    }
        //    catch (Exception e)
        //    {
        //        Is正常 = false;
        //        return new 运行结果(false, e.Message);
        //        ;
        //    }
        //    finally
        //    {
        //        测试中 = false;
        //    }
        //}


        /// <summary>
        /// 根据是否系统用户登录,返回sql的连接字串
        /// </summary>
        /// <returns></returns>
        public string GetUseConn()
        {
            return Is系统账户登录 ? 连接字符串 : GetSqlConn();
        }
    }
}