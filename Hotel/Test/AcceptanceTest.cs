using System.Collections.Generic;
using Hotel.Src;
using Xunit;

namespace Hotel.Test
{
    public class AcceptanceTest
    {
        [Fact]
        public void should_get_the_cheapest_hotel()
        {
            HotelFactory miamiHotels = new HotelFactory();

            var lakeWood =
                new Src.Hotel().SetRating(3)
                               .SetRegularWeekDayCost(110)
                               .SetRewardWeekDayCost(80)
                               .SetRegularWeekendDayCost(90)
                               .SetRewardWeekendkDayCost(80);
            lakeWood.Name = "lakewood";

            var bridgeWood =
                new Src.Hotel().SetRating(4)
                               .SetRegularWeekDayCost(160)
                               .SetRewardWeekDayCost(110)
                               .SetRegularWeekendDayCost(60)
                               .SetRewardWeekendkDayCost(50);
            bridgeWood.Name = "bridgewood";

            var ridgeWood =
                new Src.Hotel().SetRating(5)
                               .SetRegularWeekDayCost(220)
                               .SetRewardWeekDayCost(100)
                               .SetRegularWeekendDayCost(50)
                               .SetRewardWeekendkDayCost(40);
            ridgeWood.Name = "ridgewood";
            miamiHotels.Add(lakeWood);
            miamiHotels.Add(bridgeWood);
            miamiHotels.Add(ridgeWood);

            List<string> orders = FileReader.GetWholeOrders(@"../../orders.txt");
            List<Order> parseOrders = Order.Parse(orders);

            var cheapestHotelName = MoneySaver.Cheapest(miamiHotels.GetHotels(), parseOrders);
            Assert.Equal("lakewood", cheapestHotelName[0]);
            Assert.Equal("bridgewood", cheapestHotelName[1]);
            Assert.Equal("ridgewood", cheapestHotelName[2]);
        }
    }
}