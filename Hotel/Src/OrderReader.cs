using System.Collections.Generic;
using System.IO;

namespace Hotel.Src
{
    public class OrderReader
    {
        public static IEnumerable<string> GetWholeOrders(TextReader textReader)
        {
            string order;
            while ((order = textReader.ReadLine()) != null)
            {
                yield return order;
            }
        }
    }
}