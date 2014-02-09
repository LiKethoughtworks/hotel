using System.Collections.Generic;

namespace Hotel.Src
{
    public class MoneySaver
    {
        public static string Cheapest(IList<Hotel> hotels, Order order)
        {
            Hotel minHotel = null;
            int min = 0;
            foreach (var hotel in hotels)
            {
                var cost = GetCost(hotel, order);
                if (min == 0 || min > cost)
                {
                    min = cost;
                    minHotel = hotel;
                }
                else if (min == cost && minHotel.GetRatting() < hotel.GetRatting())
                {
                    minHotel = hotel;
                }
            }
            return minHotel.Name;
        }

        public static List<string> Cheapest(IList<Hotel> hotels, List<Order> orders)
        {
            List<string> cheapestHotelNames = new List<string>();
            foreach (var order in orders)
            {
                cheapestHotelNames.Add(Cheapest(hotels, order));
            }
            return cheapestHotelNames;
        }

        public static int GetCost(Hotel hotel, Order order)
        {
            if (order.CustomType == CustomType.Regular)
            {
                return order.DayOfWeek * hotel.GetRegularWeekDayCost() + order.DayOfWeekend * hotel.GetRegularWeekendDayCost();
            }
            else
            {
                return order.DayOfWeek * hotel.GetRewardWeekDayCost() + order.DayOfWeekend * hotel.GetRewardWeekendDayCost();
            }
        }

    }
}