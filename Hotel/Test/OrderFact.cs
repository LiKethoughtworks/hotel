using System;
using System.Collections.Generic;
using Hotel.Src;
using Xunit;
using Xunit.Extensions;


namespace Hotel.Test
{
    public class OrderFact
    {
        [Theory]
        [InlineData("Regular:16Mar2009(mon),17Mar2009(tues),18Mar2009(wed)", CustomType.Regular, 3, 0)]
        [InlineData("Regular:20Mar2009(fri),21Mar2009(sat),22Mar2009(sun)", CustomType.Regular, 1, 2)]
        [InlineData("Reward:26Mar2009(thur),27Mar2009(fri),28Mar2009(sat)", CustomType.Reward, 2, 1)]
        public void should_get_regular_order_by_parse(string orderString, CustomType customerType, int dayOfWeek, int dayOfWeekend)
        {
            var order = Order.Parse(orderString);
            Assert.Equal(customerType, order.CustomType);
            Assert.Equal(dayOfWeek, order.DayOfWeek);
            Assert.Equal(dayOfWeekend, order.DayOfWeekend);
        }

        [Fact]
        public void should_throw_AngrumentException_if_customer_type_is_in_bad_format()
        {
            const string orderString = "reh:26Mar2009(thur),27Mar2009(fri),28Mar2009(sat)";
            Assert.Throws<ArgumentException>(() => Order.Parse(orderString));
        }

        [Fact]
        public void should_throw_AugrumentException_if_week_type_is_in_bad_format()
        {
            const string orderString = "Regular:26Mar2009(thuer),27Mar2009(fri),28Mar2009(sat)";
            Assert.Throws<ArgumentException>(() => Order.Parse(orderString));
        }

        [Fact]
        public void should_throw_AugrumentException_if_week_is_not_align_with_date()
        {
            const string orderString = "Regular:26Mar2009(mon),27Mar2009(fri),18Mar2009(sat)";
            Assert.Throws<ArgumentException>(() => Order.Parse(orderString));
        }

        [Fact]
        public void should_throw_AgrumentException_if_Input_is_not_en_US()
        {
            const string orderString = "Regular:26三月2009(mon),27Mar2009(fri),18Mar2009(sat)";
            Assert.Throws<ArgumentException>(() => Order.Parse(orderString));
        }

    }
}
