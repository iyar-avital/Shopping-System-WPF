using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_system.Tools
{
    public enum Month
    {
        January = 1,
        February = 2,
        March = 3,
        April = 4,
        May = 5,
        June = 6,
        July = 7,
        August = 8,
        September = 9,
        October = 10,
        November = 11,
        December = 12
    }
    public static class DatesDB
    {
        public static List<Month> getMonth()
        {
            return new List<Month>() { Month.January, Month.February, Month.March, Month.April, Month.May,
                Month.June, Month.July, Month.August, Month.September, Month.October, Month.November, Month.December };
        }

        public static List<int> getDays()
        {
            List<int> days = new List<int>();
            for (int i = 1; i < 32; i++)
            {
                days.Add(i);
            }
            return days;
        }
    }
}
