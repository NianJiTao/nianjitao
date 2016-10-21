using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 年纪涛.简介.Models
{
    public class 联系方式 : List<联系单项>
    {
        public 联系方式()
        {
            //Add(new 联系单项("手机","13913140677",new Uri("wtai://wp/mc;13913140677")));
            Add(new 联系单项("手机", "13913140677"));
            Add(new 联系单项("微信", "FMTV365"));
            Add(new 联系单项("QQ", "925007694" ,new Uri("tencent://message/?uin=925007694")));
            Add(new 联系单项("邮箱", "NianJiTao@Outlook.com" ,new Uri("mailTo:NianJiTao@Outlook.com")));
        }

    }

    public class 联系单项
    {
        public 联系单项()
        {
            
        }
        public 联系单项(string 名称, string 值)
        {
            this.名称 = 名称;
            this.值 = 值;
        }
        public 联系单项(string 名称, string 值, Uri 链接)
        {
            this.名称 = 名称;
            this.值 = 值;
            this.链接 = 链接;
        }
        public string 名称 { get; set; }
        public string 值 { get; set; }
        public Uri 链接 { get; set; }

    }
}
