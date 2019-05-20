using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NJT.Core
{
    public class 数值限制表
    {
        [XmlAttribute]
        public string 名称 { get; set; }
        public 数值限制组[] 列表 { get; set; } = { };
    }

    public class 数值限制组
    {
        [XmlAttribute]
        public bool Is启用 { get; set; } = true;

        /// <summary>
        /// 消息类型名称
        /// </summary>
        [XmlAttribute]
        public string 名称 { get; set; }

        /// <summary>
        /// 可用来定位合金编号的字段
        /// </summary>
        [XmlAttribute]
        public string 组字段名 { get; set; }

        public 数值限制[] 列表 { get; set; } = { };
    }
}
