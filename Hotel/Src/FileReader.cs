using System.Collections.Generic;
using System.IO;

namespace Hotel.Src
{
    public class FileReader
    {
        public static IEnumerable<string> GetWholeOrders(string filename)
        {
            using (var sr = new StreamReader(filename))
            {
                string order;
                while ((order = sr.ReadLine()) != null)
                {
                    yield return order;
                }
            }
        }
    }
}