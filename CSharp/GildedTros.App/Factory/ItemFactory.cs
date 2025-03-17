using GildedTros.App.Domain;
using System.Linq;

namespace GildedTros.App.Factory;
public class ItemFactory : IItemFactory
{
    public override IItem CreateItem(string name, int sellIn, int quality)
    {
        switch (name)
        {
            case var _ when Constants.SmellyItems.Contains(name):

                return new SmellyItem
                {
                    Name = name,
                    SellIn = sellIn,
                    Quality = quality
                };

            case var _ when Constants.LegendaryItems.Contains(name):
                return new LegendaryItem
                {
                    Name = name,
                    SellIn = sellIn,
                    Quality = quality
                };

            case var _ when Constants.BackStagePasses.Contains(name):
                return new BackstagePass
                {
                    Name = name,
                    SellIn = sellIn,
                    Quality = quality
                };

            case var _ when Constants.GoodItems.Contains(name):
                return new GoodItem
                {
                    Name = name,
                    SellIn = sellIn,
                    Quality = quality
                };
            default:
                return new BaseItem
                {
                    Name = name,
                    SellIn = sellIn,
                    Quality = quality
                };
        }
    }
}
