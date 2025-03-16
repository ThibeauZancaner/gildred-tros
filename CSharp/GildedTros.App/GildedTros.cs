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
            foreach (Item item in Items)
            {
                bool isSmellyItem = IsSmellyItem(item.Name);
                bool isBackStagePass = IsBackStagePass(item.Name);
                bool isLegendaryItem = IsLegendaryItem(item.Name);
                bool isGoodItem = IsGoodItem(item.Name);

                if (isSmellyItem)
                {
                    UpdateSmellyItem(item);
                }
                else if (isLegendaryItem)
                {
                    UpdateLegendaryItem(item);
                }
                else if (isGoodItem)
                {
                    UpdateGoodItem(item);
                }
                else if (isBackStagePass)
                {
                    UpdateBackStageItem(item);
                }
                else
                {
                    UpdateItem(item);
                }
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

        private void UpdateSmellyItem(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality -= 2;
                if (item.SellIn < 0)
                {
                    item.Quality -= 2;
                }
            }
            item.SellIn--;
        }

        private void UpdateItem(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality--;
                if (item.SellIn < 0)
                {
                    item.Quality--;
                }
            }
            item.SellIn--;
        }

        private void UpdateLegendaryItem(Item item)
        {
            // Legendary items do not change
        }

        private void UpdateGoodItem(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality++;
            }
            item.SellIn--;
        }

        private void UpdateBackStageItem(Item item)
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
        }
    }
}
