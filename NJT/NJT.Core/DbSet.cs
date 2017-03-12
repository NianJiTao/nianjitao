using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NJT.Core
{
    [Serializable]
    public class DbSet
    {
        [XmlAttribute]
        public string 服务器名 { get; set; } = "."; //服务器名


        [XmlAttribute]
        public string 数据库名 { get; set; } = "Db2018"; //数据库名    


        [XmlAttribute]
        public string 用户名 { get; set; } = "sa"; //登录用户名


        [XmlAttribute]
        public string 登录密码 { get; set; } = "12345"; //登录密码
    }
}
