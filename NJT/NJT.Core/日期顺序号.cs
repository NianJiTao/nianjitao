using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Core
{
    public class 日期顺序号
    {
        private int _当天序号 = 0;
        private DateTime _日期 = DateTime.Today;

        /// <summary>
        /// 返回当前日期的顺序记录号,1开始,递增1
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int Get记录号(DateTime obj)
        {
            if (obj.Date != _日期)
            {
                _日期 = obj.Date;
                _当天序号 = 0;
            }
            return ++_当天序号;
        }
    }
}
