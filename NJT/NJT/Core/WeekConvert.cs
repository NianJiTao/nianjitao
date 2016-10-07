using System;

namespace NJT.Common
{
    public static class WeekConvert
    {

        public static string ToWeek中文(this DayOfWeek week)
        {
            return System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(week);
        }
       
    }
}
