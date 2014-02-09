using System;
using System.Collections.Generic;

namespace Hotel.Src
{
    public class Order
    {
        public int DayOfWeek { get; set; }
        public int DayOfWeekend { get; set; }
        public CustomType CustomType { get; set; }

        public static List<Order> Parse(List<string> orders)
        {
            List<Order> formattedOrders = new List<Order>();
            foreach (var order in orders)
            {
                formattedOrders.Add(Parse(order));
            }
            return formattedOrders;
        }

        public static Order Parse(string order)
        {
            var infos = order.Split(':');
            Order orderObject = new Order
                {
                    CustomType = (CustomType)Enum.Parse(typeof(CustomType), infos[0])

                };
            var days = infos[1].Split(',');
            foreach (var day in days)
            {
                int start = day.IndexOf("(", StringComparison.Ordinal);
                int end = day.IndexOf(")", StringComparison.Ordinal);
                string parseDay = day.Substring(start + 1, end - start - 1);
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