using System.Collections.Generic;
using System.Linq;

namespace GildedTros.App
{
    public class GildedTros
    {
        private readonly string[] _smellyItems = { "Duplicate Code", "Long Methods", "Ugly Variable Names" };
        private readonly string[] _backStagePasses = { "Backstage passes for Re:factor", "Backstage passes for HAXX" };
        private readonly string[] _legendaryItems = { "B-DAWG Keychain" };
        private readonly string[] _goodItems = { "Good Wine" };

        IList<Item> Items;
        public GildedTros(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (int i = 0; i < Items.Count; i++)
            {
                Item item = Items[i];
                bool isSmellyItem = IsSmellyItem(item.Name);
                bool isBackStagePass = IsBackStagePass(item.Name);
                bool isLegendaryItem = IsLegendaryItem(item.Name);
                bool isGoodItem = IsGoodItem(item.Name);

                if (isSmellyItem)
                {
                    item = UpdateSmellyItem(item);
                }
                else if (isLegendaryItem)
                {
                    item = UpdateLegendaryItem(item);
                }
                else if (isGoodItem)
                {
                    item = UpdateGoodItem(item);
                }
                else if (isBackStagePass)
                {
                    item = UpdateBackStageItem(item);
                }
                else
                {
                    item = UpdateItem(item);
                }

                Items[i] = item;
            }
        }

        private bool IsSmellyItem(string name)
        {
            return _smellyItems.Contains(name);
        }

        private bool IsBackStagePass(string name)
        {
            return _backStagePasses.Contains(name);
        }

        private bool IsLegendaryItem(string name)
        {
            return _legendaryItems.Contains(name);
        }

        private bool IsGoodItem(string name)
        {
            return _goodItems.Contains(name);
        }
        private Item UpdateSmellyItem(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality = item.Quality - 2;
            }
            item.SellIn--;
            return item;
        }

        private Item UpdateItem(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality--;
            }
            item.SellIn--;
            return item;
        }

        private Item UpdateLegendaryItem(Item item)
        {
            return item;
        }

        private Item UpdateGoodItem(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality++;
            }
            item.SellIn--;
            return item;
        }

        private Item UpdateBackStageItem(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality++;
                if (item.SellIn < 11)
                {
                    if (item.Quality < 50)
                    {
                        item.Quality++;
                    }
                }
                if (item.SellIn < 6)
                {
                    if (item.Quality < 50)
                    {
                        item.Quality++;
                    }
                }
            }
            item.SellIn--;
            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }
            return item;
        }
    }
}
