using GildedTros.App.Domain;
using System.Collections.Generic;

namespace GildedTros.App
{
    public class GildedTros
    {
        IList<IItem> Items;
        public GildedTros(IList<IItem> Items)
        {
            this.Items = Items;
        }

        public void UpdateItem()
        {
            foreach (IItem item in Items)
            {
                item.UpdateQuality();
                item.UpdateSellIn();
            }
        }
    }
}
