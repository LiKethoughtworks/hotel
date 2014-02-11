using System;
using System.Collections.Generic;
using Hotel.Src;
using Xunit;
using Xunit.Extensions;


namespace Hotel.Test
{
    public class OrderFact
    {
       
        private readonly Dictionary<string, CustomType> _customTypes;

        public OrderFact()
        {
            _customTypes = new Dictionary<string, CustomType>
                {
                    {"regular", CustomType.Regular},
                    {"reward", CustomType.Reward}
                };
        }

        [Theory]
        [InlineData("Regular:16Mar2009(mon),17Mar2009(tues),18Mar2009(wed)", "regular", 3, 0)]
        [InlineData("Regular:20Mar2009(fri),21Mar2009(sat),22Mar2009(sun)", "regular", 1, 2)]
        [InlineData("Reward:26Mar2009(thur),27Mar2009(fri),28Mar2009(sat)", "reward", 2, 1)]
        public void should_get_regular_order_by_parse(string orderString, string customerType, int dayOfWeek, int dayOfWeekend)
        {
            var order = Order.Parse(orderString);
            Assert.Equal(_customTypes[customerType], order.CustomType);
            Assert.Equal(dayOfWeek, order.DayOfWeek);
            Assert.Equal(dayOfWeekend, order.DayOfWeekend);
        }

        [Theory]
        [InlineData("reh:26Mar2009(thur),27Mar2009(fri),28Mar2009(sat)")]
        [InlineData("Regular:26Mar2009(thuer),27Mar2009(fri),28Mar2009(sat)")] 
        [InlineData("Regular:26Mar2009(mon),27Mar2009(fri),18Mar2009(sat)")]
        public void should_throw_ArgumentExpection_if_order_format_is_invalid(string orderString)
        {
            Assert.Throws<ArgumentException>(() => Order.Parse(orderString));
        }
    }
}
