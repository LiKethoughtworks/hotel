using System.Collections.Generic;
using System.Linq;

namespace Hotel.Src
{
    public class HotelReservationService
    {
        public string GetCheapestHotelName(IList<Hotel> hotels, string order)
        {
            var parseOrder = Order.Parse(order);
            return Cheapest(hotels, parseOrder);
        }

        public List<string> GetCheapestHotelName(IList<Hotel> hotels, IList<string> orders)
        {
            var parseOrders = Order.Parse(orders);
            return Cheapest(hotels, parseOrders);
        }

        public List<string> Cheapest(IList<Hotel> hotels, IList<Order> orders)
        {
            return orders.Select(order => Cheapest(hotels, order)).ToList();
        }

        private static string Cheapest(IEnumerable<Hotel> hotels, Order order)
        {
            Hotel minHotel = null;
            var min = 0;
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

        private static int GetCost(Hotel hotel, Order order)
        {
            if (order.CustomType == CustomType.Regular)
            {
                return order.DayOfWeek * hotel.GetRegularWeekDayCost() + order.DayOfWeekend * hotel.GetRegularWeekendDayCost();
            }
            return order.DayOfWeek * hotel.GetRewardWeekDayCost() + order.DayOfWeekend * hotel.GetRewardWeekendDayCost();
        }
    }
}