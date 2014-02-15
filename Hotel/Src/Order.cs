using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Hotel.Src
{
    public class Order
    {
        private const string Format = "ddMMMyyyy";
        public int DayOfWeek { get; set; }
        public int DayOfWeekend { get; set; }
        public CustomType CustomType { get; set; }

        public List<Order> Parse(IList<string> orders)
        {
            return orders.Select(Parse).ToList();
        }

        public  Order Parse(string order)
        {
            var infos = order.Split(':');
            var orderObject = new Order
                {
                    CustomType = (CustomType)Enum.Parse(typeof(CustomType), infos[0])
                };
            var days = infos[1].Split(',');
            foreach (var day in days)
            {
                ParseDay(day, orderObject);
            }
            return orderObject;
        }

        private static void ParseDay(string day, Order orderObject)
        {
            var start = day.IndexOf("(", StringComparison.Ordinal);
            var end = day.IndexOf(")", StringComparison.Ordinal);
            var parseDay = day.Substring(start + 1, end - start - 1);

            var dateTime = day.Substring(0, start);
            var specificCulture = CultureInfo.CreateSpecificCulture("en-US");
            DateTime datetime;
            try
            {
                datetime = DateTime.ParseExact(dateTime, Format, specificCulture);
            }
            catch (Exception)
            {
                
                throw new ArgumentException();
            }
           
            var datetimeDay = datetime.ToString("ddd", specificCulture);
            var fullDateTimeDay = datetime.ToString("dddd", specificCulture);

            DayValidation(parseDay, datetimeDay, fullDateTimeDay);
            
            if (IsWeekend(datetimeDay))
            {
                orderObject.DayOfWeekend++;
                return;
            }
            orderObject.DayOfWeek++;
        }

        private static bool IsWeekend(string datetimeDay)
        {
            return datetimeDay == "Sun" || datetimeDay == "Sat";
        }

        private static void DayValidation(string parseDay, string datetimeDay, string fullDateTimeDay)
        {
            if (!parseDay.StartsWith(datetimeDay, StringComparison.OrdinalIgnoreCase) ||
                !fullDateTimeDay.StartsWith(parseDay, StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException();
        }
    }
}