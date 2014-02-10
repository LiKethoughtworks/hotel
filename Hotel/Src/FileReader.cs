using System.Collections.Generic;
using System.IO;

namespace Hotel.Src
{
    public class FileReader
    {
        public static List<string> GetWholeOrders(string filename)
        {
            var orders = new List<string>();
            using (var sr = new StreamReader(filename))
            {
                string order;
                while ((order = sr.ReadLine()) != null)
                {
                    orders.Add(order);
                }
            }
            return (orders);
        }
    }
}