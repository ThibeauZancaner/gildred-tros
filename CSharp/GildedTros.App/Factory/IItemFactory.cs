using GildedTros.App.Domain;

namespace GildedTros.App.Factory;
public abstract class IItemFactory
{
    public abstract IItem CreateItem(string name, int sellIn, int quality);
}
