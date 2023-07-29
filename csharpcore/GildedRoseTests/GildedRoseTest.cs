using Xunit;
using System.Collections.Generic;
using GildedRoseKata;
using Moq;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        private readonly Mock<IStrategy> _strategy;

        public GildedRoseTest()
        {
            _strategy = new Mock<IStrategy>();
        }


        [Fact]
        public void foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items, _strategy.Object);
            app.UpdateQuality();
            Assert.Equal("foo", Items[0].Name);
        }
    }
}
