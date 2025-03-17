namespace GildedTros.App.Domain;
public class GoodItem : Item, IItem
{
    public int QualityStep => Constants.DefaultQualityStep;

    public int SellInStep => Constants.DefaultSellInStep;

    public void UpdateQuality()
    {
        if (Quality + QualityStep > Constants.DefaultMaxQuality)
        {
            Quality = Constants.DefaultMaxQuality;
        }
        else
        {
            Quality += QualityStep;
        }
    }

    public void UpdateSellIn()
    {
        SellIn -= SellInStep;
    }
}
