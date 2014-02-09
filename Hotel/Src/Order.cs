using System;
using System.Collections.Generic;
using System.Linq;

namespace Hotel.Src
{
    public class Order
    {
        public int DayOfWeek { get; set; }
        public int DayOfWeekend { get; set; }
        public CustomType CustomType { get; set; }

        public static List<Order> Parse(List<string> orders)
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
                var end = day.IndexOf(")", StringComparison.Ordinal);
                var parseDay = day.Substring(start + 1, end - start - 1);
                if (Date.IsWeekDay(parseDay))
                {
                    orderObject.DayOfWeek++;

                }
                else if (Date.IsWeekend(parseDay))
                {
                    orderObject.DayOfWeekend++;
                }
            }
            return orderObject;
        }
    }
}