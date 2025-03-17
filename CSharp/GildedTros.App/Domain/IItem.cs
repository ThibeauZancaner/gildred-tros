namespace GildedTros.App.Domain;
public interface IItem
{
    public int QualityStep { get; }
    public int SellInStep { get; }
    public string Name { get; }
    public int SellIn { get; }
    public int Quality { get; }

    void UpdateQuality();
    void UpdateSellIn();
}
