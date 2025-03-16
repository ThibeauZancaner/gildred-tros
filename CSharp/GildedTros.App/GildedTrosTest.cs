using System.Collections.Generic;
using Xunit;

namespace GildedTros.App
{
    public class GildedTrosTest
    {
        [Fact]
        public void Foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal("foo", Items[0].Name);
        }

        [Fact]
        public void UpdateStandardItemSellInPositive()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "standardItem", SellIn = 10, Quality = 10 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal(9, Items[0].SellIn);
            Assert.Equal(9, Items[0].Quality);
        }

        [Fact]
        public void UpdateStandardItemSellInNegative()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "standardItem", SellIn = -1, Quality = 10 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal(-2, Items[0].SellIn);
            Assert.Equal(8, Items[0].Quality);
        }

        [Fact]
        public void UpdateStandardItemQualityZero()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "standardItem", SellIn = 10, Quality = 0 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal(9, Items[0].SellIn);
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void UpdateSmellyItemSellInPositive()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "Duplicate Code", SellIn = 10, Quality = 10 },
                new Item { Name = "Long Methods", SellIn = 11, Quality = 9 },
                new Item { Name = "Ugly Variable Names", SellIn = 12, Quality = 8 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal(9, Items[0].SellIn);
            Assert.Equal(8, Items[0].Quality);
            Assert.Equal(10, Items[1].SellIn);
            Assert.Equal(7, Items[1].Quality);
            Assert.Equal(11, Items[2].SellIn);
            Assert.Equal(6, Items[2].Quality);
        }

        [Fact]
        public void UpdateSmellyItemSellInNegative()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "Duplicate Code", SellIn = -1, Quality = 10 },
                new Item { Name = "Long Methods", SellIn = -2, Quality = 11 },
                new Item { Name = "Ugly Variable Names", SellIn = -3, Quality = 12 },
            };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal(-2, Items[0].SellIn);
            Assert.Equal(6, Items[0].Quality);
            Assert.Equal(-3, Items[1].SellIn);
            Assert.Equal(7, Items[1].Quality);
            Assert.Equal(-4, Items[2].SellIn);
            Assert.Equal(8, Items[2].Quality);
        }

        [Fact]
        public void UpdateSmellyItemQualityZero()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "Duplicate Code", SellIn = 10, Quality = 0 },
                new Item { Name = "Long Methods", SellIn = 11, Quality = 0 },
                new Item { Name = "Ugly Variable Names", SellIn = 12, Quality = 0 },
            };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal(9, Items[0].SellIn);
            Assert.Equal(0, Items[0].Quality);
            Assert.Equal(10, Items[1].SellIn);
            Assert.Equal(0, Items[1].Quality);
            Assert.Equal(11, Items[2].SellIn);
            Assert.Equal(0, Items[2].Quality);
        }

        [Fact]
        public void UpdateLegendaryItemSellInPositive()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "B-DAWG Keychain", SellIn = 10, Quality = 80 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal(10, Items[0].SellIn);
            Assert.Equal(80, Items[0].Quality);
        }

        [Fact]
        public void UpdateLegendaryItemSellInNegative()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "B-DAWG Keychain", SellIn = -1, Quality = 80 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal(-1, Items[0].SellIn);
            Assert.Equal(80, Items[0].Quality);
        }

        [Fact]
        public void UpdateGoodItemSellInPositive()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Good Wine", SellIn = 10, Quality = 10 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal(9, Items[0].SellIn);
            Assert.Equal(11, Items[0].Quality);
        }

        [Fact]
        public void UpdateGoodItemQualityZero()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Good Wine", SellIn = 10, Quality = 0 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal(9, Items[0].SellIn);
            Assert.Equal(1, Items[0].Quality);
        }

        [Fact]
        public void UpdateBackStageItemSellInPositive()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes for Re:factor", SellIn = 15, Quality = 20 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal(14, Items[0].SellIn);
            Assert.Equal(21, Items[0].Quality);
        }

        [Fact]
        public void UpdateBackStageItemSellIn10OrLess()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes for Re:factor", SellIn = 10, Quality = 20 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal(9, Items[0].SellIn);
            Assert.Equal(22, Items[0].Quality);
        }
        [Fact]
        public void UpdateBackStageItemSellIn5OrLess()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes for Re:factor", SellIn = 5, Quality = 20 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal(4, Items[0].SellIn);
            Assert.Equal(23, Items[0].Quality);
        }

        [Fact]
        public void UpdateBackStageItemSellIn0OrLess()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes for Re:factor", SellIn = 0, Quality = 20 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal(-1, Items[0].SellIn);
            Assert.Equal(0, Items[0].Quality);
        }

    }
}