using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items;
        private IStrategy _strategy;
        private const string AgedBrie = "Aged Brie";
        private const string Backstage = "Backstage passes to a TAFKAL80ETC concert";
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        // todo conjured

        public GildedRose(IList<Item> Items, IStrategy strategy)
        {
            this.Items = Items;
            _strategy = strategy;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                _strategy = item.Name switch
                {
                    Sulfuras => new SulfurasStrategy(),
                    AgedBrie => new BrieStrategy(),
                    Backstage => new BackstageStrategy(),
                    _ => new RegularItemStrategy()
                };
                _strategy.UpdateItem(item);
            }
        }
    }

    public interface IStrategy
    {
        void UpdateItem(Item item);
    }

    public class RegularItemStrategy : IStrategy
    {
        public void UpdateItem(Item item)
        {

            UpdateQuality(item);
            UpdateSellin(item);
        }

        private void UpdateQuality(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality -= 1;
            }
        }

        private void UpdateSellin(Item item)
        {
            item.SellIn -= 1;

            if (item.SellIn < 0)
            {
                UpdateQuality(item);
            }
        }
    }

    public class BrieStrategy : IStrategy
    {
        public void UpdateItem(Item item)
        {
            UpdateQuality(item);
            UpdateSellin(item);
        }

        private static void UpdateQuality(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality += 1;
            }
        }

        private void UpdateSellin(Item item)
        {
            item.SellIn -= 1;
            if (item.SellIn < 0)
                UpdateQuality(item);
        }
    }

    public class SulfurasStrategy : IStrategy
    {
        public void UpdateItem(Item item)
        {
            //item.Quality = 80;
        }
    }

    public class BackstageStrategy : IStrategy
    {
        public void UpdateItem(Item item)
        {
            UpdateQuality(item);
            UpdateSellin(item);
        }

        private static void UpdateQuality(Item item)
        {
            IncreaseQuality(item);

            if (item.SellIn < 11)
            {
                IncreaseQuality(item);
            }

            if (item.SellIn < 6)
            {
                IncreaseQuality(item);
            }
        }

        private static void IncreaseQuality(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality += 1;
            }
        }

        private static void UpdateSellin(Item item)
        {
            item.SellIn -= 1;
            if (item.SellIn < 0)
            {
                item.Quality -= item.Quality;
            }
        }

    }
}
