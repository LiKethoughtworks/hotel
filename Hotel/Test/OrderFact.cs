using System;
using Hotel.Src;
using Xunit;
using Xunit.Extensions;


namespace Hotel.Test
{
    public class OrderFact
    {
        [Theory]
        [InlineData("Regular:16Mar2009(mon),17Mar2009(tues),18Mar2009(wed)", 3, 0)]
        [InlineData("Regular:20Mar2009(fri),21Mar2009(sat),22Mar2009(sun)", 1, 2)]
        public void should_get_regular_order_by_parse(string orderString, int dayOfWeek, int dayOfWeekend)
        {
            var order = Order.Parse(orderString);
            Assert.Equal(CustomType.Regular, order.CustomType);
            Assert.Equal(dayOfWeek, order.DayOfWeek);
            Assert.Equal(dayOfWeekend, order.DayOfWeekend);
        }
        
        [Theory]
        [InlineData("Reward:26Mar2009(thur),27Mar2009(fri),28Mar2009(sat)", 2, 1)]
        public void should_get_reward_order_by_parse(string orderString, int dayOfWeek, int dayOfWeekend)
        {
            var order = Order.Parse(orderString);
            Assert.Equal(CustomType.Reward, order.CustomType);
            Assert.Equal(dayOfWeek, order.DayOfWeek);
            Assert.Equal(dayOfWeekend, order.DayOfWeekend);
        }

        [Theory]
//        [InlineData("reh:26Mar2009(thur),27Mar2009(fri),28Mar2009(sat)")]
//        [InlineData("Regular:26Mar2009(thuer),27Mar2009(fri),28Mar2009(sat)")] 
        [InlineData("Regular:26Mar2009(mon),27Mar2009(fri),28Mar2009(sat)")]
        public void should_throw_ArgumentExpection_if_order_format_is_invalid(string orderString)
        {
            Assert.Throws<ArgumentException>(() => Order.Parse(orderString));
        }
    }
}