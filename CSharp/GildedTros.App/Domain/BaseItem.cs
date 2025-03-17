namespace GildedTros.App.Domain;
public class BaseItem : Item, IItem
{
    public int QualityStep => Constants.DefaultQualityStep;

    public int SellInStep => Constants.DefaultQualityStep;

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
