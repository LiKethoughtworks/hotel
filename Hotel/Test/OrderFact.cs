using Hotel.Src;
using Xunit;

namespace Hotel.Test
{
    public class OrderFact
    {
        [Fact]
        public void should_get_order_by_parse()
        {
            const string orderString = "Regular:16Mar2009(mon),17Mar2009(tues),18Mar2009(wed)";
            var order = Order.Parse(orderString);
            Assert.Equal( CustomType.Regular, order.CustomType);
            Assert.Equal(3, order.DayOfWeek);
            Assert.Equal(0, order.DayOfWeekend);
        }
    }
}