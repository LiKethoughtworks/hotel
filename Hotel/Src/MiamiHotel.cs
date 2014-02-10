using System.Collections.Generic;

namespace Hotel.Src
{
    public class MiamiHotel
    {
        private static List<Hotel> _hotels;

        public static List<Hotel> GetHotels()
        {
            if (_hotels == null)
            {
                Create();
            }
            return _hotels;
        }

        private static void Create()
        {
            var lakeWood =
                new Hotel().SetRating(3)
                           .SetRegularWeekDayCost(110)
                           .SetRewardWeekDayCost(80)
                           .SetRegularWeekendDayCost(90)
                           .SetRewardWeekendkDayCost(80);
            lakeWood.Name = "lakewood";

            var bridgeWood =
                new Hotel().SetRating(4)
                           .SetRegularWeekDayCost(160)
                           .SetRewardWeekDayCost(110)
                           .SetRegularWeekendDayCost(60)
                           .SetRewardWeekendkDayCost(50);
            bridgeWood.Name = "bridgewood";

            var ridgeWood =
                new Hotel().SetRating(5)
                           .SetRegularWeekDayCost(220)
                           .SetRewardWeekDayCost(100)
                           .SetRegularWeekendDayCost(50)
                           .SetRewardWeekendkDayCost(40);
            ridgeWood.Name = "ridgewood";

            _hotels = new List<Hotel> {lakeWood, bridgeWood, ridgeWood};
        }
    }
}