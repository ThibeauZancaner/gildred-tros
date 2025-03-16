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
                if (IsSmellyItem(item.Name))
                {
                    //TODO
                }

                if (!IsGoodItem(item.Name)
                    && !IsBackStagePass(item.Name))
                {
                    if (item.Quality > 0)
                    {
                        if (!IsLegendaryItem(item.Name))
                        {
                            item.Quality = item.Quality - 1;
                        }
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;

                        if (IsBackStagePass(item.Name))
                        {
                            if (item.SellIn < 11)
                            {
                                if (item.Quality < 50)
                                {
                                    item.Quality = item.Quality + 1;
                                }
                            }

                            if (item.SellIn < 6)
                            {
                                if (item.Quality < 50)
                                {
                                    item.Quality = item.Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (!IsLegendaryItem(item.Name))
                {
                    item.SellIn = item.SellIn - 1;
                }

                if (item.SellIn < 0)
                {
                    if (!IsGoodItem(item.Name))
                    {
                        if (!IsBackStagePass(item.Name))
                        {
                            if (item.Quality > 0)
                            {
                                if (!IsLegendaryItem(item.Name))
                                {
                                    item.Quality = item.Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            item.Quality = item.Quality - item.Quality;
                        }
                    }
                    else
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality = item.Quality + 1;
                        }
                    }
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

    }
}
