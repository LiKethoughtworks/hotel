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
            var orders = FileReader.GetWholeOrders(@"../../orders.txt");
            Assert.Equal("Regular:16Mar2009(mon),17Mar2009(tues),18Mar2009(wed)", orders[0]);
            Assert.Equal("Regular:20Mar2009(fri),21Mar2009(sat),22Mar2009(sun)", orders[1]);
            Assert.Equal("Reward:26Mar2009(thur),27Mar2009(fri),28Mar2009(sat)", orders[2]);
        }
    }
}