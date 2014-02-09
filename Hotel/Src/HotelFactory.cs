using System.Collections.Generic;

namespace Hotel.Src
{
    public class HotelFactory
    {
        private List<Hotel> _hotels;

        public HotelFactory()
        {
            _hotels = new List<Hotel>();
        }

        public void Add(Hotel hotel)
        {
            _hotels.Add(hotel);
        }

        public List<Hotel> GetHotels()
        {
            return _hotels;
        }

    }
}