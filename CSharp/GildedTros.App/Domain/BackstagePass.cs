namespace GildedTros.App.Domain;
public class BackstagePass : Item, IItem
{
    public int QualityStep => Constants.DefaultQualityStep;

    public int SellInStep => Constants.DefaultSellInStep;

    public void UpdateQuality()
    {
        if (Quality + Constants.DefaultQualityStep > Constants.DefaultMaxQuality)
        {
            Quality = Constants.DefaultMaxQuality;
        }
        else
        {
            Quality += Constants.DefaultQualityStep;
            if (SellIn < 11)
            {
                if (Quality < Constants.DefaultMaxQuality)
                {
                    Quality += Constants.DefaultQualityStep;
                }
            }
            if (SellIn < 6)
            {
                if (Quality < Constants.DefaultMaxQuality)
                {
                    Quality += Constants.DefaultQualityStep;
                }
            }
        }
    }

    public void UpdateSellIn()
    {
        SellIn -= SellInStep;
        if (SellIn < 0)
        {
            Quality = Constants.DefaultMinQuality;
        }
    }
}
