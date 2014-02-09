using System.Collections.Generic;
using System.IO;

namespace Hotel.Src
{
    public class FileReader
    {
        public static List<string> GetWholeOrders(string filename)
        {
            List<string> orders = new List<string>();
            using (StreamReader sr = new StreamReader(filename))
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