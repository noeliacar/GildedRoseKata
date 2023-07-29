using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items;
        private const string AgedBrie = "Aged Brie";
        private const string Backstage = "Backstage passes to a TAFKAL80ETC concert";
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                switch (item.Name)
                {
                    case Sulfuras:
                        UpdateSulfuras(item);
                        continue;
                    case AgedBrie:
                        UpdateBrie(item);
                        continue;
                    case Backstage:
                        UpdateBackstage(item);
                        continue;
                    default:
                        UpdateRegularItem(item);
                        continue;
                }
            }
        }

        private void UpdateSulfuras(Item item)
        {
            item.Quality = 80;
        }

        private void UpdateBrie(Item item)
        {
            item.SellIn -= 1;

            if (item.Quality < 50)
            {
                item.Quality += 1;
                if (item.SellIn < 0 && item.Quality < 50)
                    item.Quality += 1;
            }

        }

        private void UpdateBackstage(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality += 1;

                    if (item.SellIn < 11)
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality += 1;
                        }
                    }

                    if (item.SellIn < 6)
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality += 1;
                        }
                    }
            }
            item.SellIn -= 1;
            if (item.SellIn < 0)
            {
                item.Quality -= item.Quality;
            }
        }

        private void UpdateRegularItem(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality -= 1;
            }
            item.SellIn -= 1;

            if (item.SellIn < 0 && item.Quality > 0)
            {
                item.Quality -= 1;
            }
        }
    }
}
