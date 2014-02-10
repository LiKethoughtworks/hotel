using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Hotel.Src
{
    public class Order
    {
        public int DayOfWeek { get; set; }
        public int DayOfWeekend { get; set; }
        public CustomType CustomType { get; set; }

        public static List<Order> Parse(IList<string> orders)
        {
            return orders.Select(Parse).ToList();
        }

        public static Order Parse(string order)
        {
            var infos = order.Split(':');
            var orderObject = new Order
                {
                    CustomType = (CustomType)Enum.Parse(typeof(CustomType), infos[0])
                };
            var days = infos[1].Split(',');
            foreach (var day in days)
            {
                var start = day.IndexOf("(", StringComparison.Ordinal);
                var dateTime = day.Substring(0, start);
                //16Mar2009
                const string format = "DDMMMyyyy";
                var datetime = DateTime.ParseExact(dateTime, format, CultureInfo.CreateSpecificCulture("en-US"));

                var end = day.IndexOf(")", StringComparison.Ordinal);
                var parseDay = day.Substring(start + 1, end - start - 1);
                //date.week == parseDay
                if (Date.IsWeekDay(parseDay))
                {
                    orderObject.DayOfWeek++;

                }
                else if (Date.IsWeekend(parseDay))
                {
                    orderObject.DayOfWeekend++;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            return orderObject;
        }
    }
}