using System.Collections.Generic;
using System.Linq;
using Hotel.Src;
using Xunit;

namespace Hotel.Test
{
    public class AcceptanceTest
    {
        [Fact]
        public void should_get_the_cheapest_hotel()
        {
            var orders = OrderReader.GetWholeOrders(@"../../orders.txt").ToList();
            var hotelReservationService = new HotelReservationService();
            var cheapestHotelName = hotelReservationService.GetCheapestHotelName(MiamiHotel.GetHotels(), orders);
           
            Assert.Equal("lakewood", cheapestHotelName[0]);
            Assert.Equal("bridgewood", cheapestHotelName[1]);
            Assert.Equal("ridgewood", cheapestHotelName[2]);
        }


    }
}