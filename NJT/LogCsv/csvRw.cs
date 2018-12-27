using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogCsv
{
    public class CsvRw
    {

        /// <summary>
        /// 写入内容到csv文件
        /// </summary>
        /// <param name="obj"></param>
        public void 写入(Csv内容 obj)
        {
           var str= string.Join(" ", obj.内容); 
        }
    }
}