using System.Xml.Serialization;

namespace NJT.Core
{
    public interface I授权配置
    {
        string 客户名称 { get; set; }
        string 硬件码 { get; set; }
        string 注册码 { get; set; }
    }

    public class 授权配置 : I授权配置
    {
        public 授权配置()
        {
            注册码 = "联系供应商";
        }

        [XmlAttribute]
        public string 客户名称 { get; set; }

        [XmlAttribute]
        public string 硬件码 { get; set; }

        public string 注册码 { get; set; }
    }
}