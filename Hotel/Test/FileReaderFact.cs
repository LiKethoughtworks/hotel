using System.Collections.Generic;
using Hotel.Src;
using Xunit;

namespace Hotel.Test
{
    public class FileReaderFact
    {
        [Fact]
        public void should_get_whole_file_content()
        {
            List<string> orders = FileReader.GetWholeOrders(@"../../orders.txt");
            Assert.Equal(orders[0], "Regular:16Mar2009(mon),17Mar2009(tues),18Mar2009(wed)");
            Assert.Equal(orders[1], "Regular:20Mar2009(fri),21Mar2009(sat),22Mar2009(sun)");
            Assert.Equal(orders[2], "Reward:26Mar2009(thur),27Mar2009(fri),28Mar2009(sat)");
        }
    }
}