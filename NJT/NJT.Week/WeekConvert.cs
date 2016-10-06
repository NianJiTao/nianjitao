using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Week
{
    public static class WeekConvert
    {

        public static string ToWeek中文(this DayOfWeek week)
        {
            return System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(week);
        }
       
    }
}
