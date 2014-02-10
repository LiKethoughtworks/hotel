using System.Linq;

namespace Hotel.Src
{
    public class Date
    {
        private static readonly string[] Weekday = { "mon", "tues", "wed", "thur", "fri" };
        private static readonly string[] Weekend = { "sun", "sat" };
        public static bool IsWeekDay(string currentDay)
        {
            return Weekday.Contains(currentDay);
        }

        public static bool IsWeekend(string currentDay)
        {
            return Weekend.Contains(currentDay);
        }
    }
}