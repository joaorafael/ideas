using System;

namespace WebIdeas.Helpers
{
    public class DateHelper
    {
        public static bool EqualsDateToTheMinute(DateTime one, DateTime two)
        {
            return
                one.Year == two.Year &&
                one.Month == two.Month &&
                one.Day == two.Day &&
                one.Hour == two.Hour &&
                one.Minute == two.Minute;
        }
    }
}