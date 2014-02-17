using System.IO;
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
            var reader = new StringReader(
                "Regular:16Mar2009(mon),17Mar2009(tues),18Mar2009(wed)\r\n"+
                "Regular:20Mar2009(fri),21Mar2009(sat),22Mar2009(sun)\r\n"+
                "Reward:26Mar2009(thur),27Mar2009(fri),28Mar2009(sat)"
                );
            
            var orders = OrderReader.GetWholeOrders(reader).ToList();
            var hotelReservationService = new HotelReservationService();
            var cheapestHotelName = hotelReservationService.GetCheapestHotelName(MiamiHotel.GetHotels(), orders);
           
            Assert.Equal("lakewood", cheapestHotelName[0]);
            Assert.Equal("bridgewood", cheapestHotelName[1]);
            Assert.Equal("ridgewood", cheapestHotelName[2]);
        }


    }
}