using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 年纪涛.简介.Models
{
    public class 基本信息
    {
        public DateTime 生日 { get; set; } = new DateTime(1982, 4, 24);
        public string 姓名 { get; set; } = "年纪涛";
        public bool 性别 { get; set; } = true;
        public int 年龄 => DateTime.Today.Year - 生日.Year;
        public string 学历 { get; set; } = "大专";
    }
}