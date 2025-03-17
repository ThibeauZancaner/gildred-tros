namespace GildedTros.App.Domain;
public class LegendaryItem : Item, IItem
{
    public int QualityStep => Constants.DefaultQualityStep;

    public int SellInStep => Constants.DefaultSellInStep;

    public void UpdateQuality()
    {
        return;
    }

    public void UpdateSellIn()
    {
        return;
    }
}
