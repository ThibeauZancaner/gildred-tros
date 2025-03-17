namespace GildedTros.App.Domain;
public class SmellyItem : Item, IItem
{
    public int QualityStep => Constants.DefaultQualityStep * 2;

    public int SellInStep => Constants.DefaultSellInStep;

    public void UpdateQuality()
    {
        if (Quality > Constants.DefaultMinQuality)
        {
            Quality -= QualityStep;
            if (SellIn < 0)
            {
                Quality -= QualityStep;
            }
            if (Quality < Constants.DefaultMinQuality)
            {
                Quality = Constants.DefaultMinQuality;
            }
        }

    }

    public void UpdateSellIn()
    {
        SellIn -= SellInStep;
    }
}
