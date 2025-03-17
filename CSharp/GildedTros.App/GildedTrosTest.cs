using GildedTros.App.Domain;
using System.Collections.Generic;
using Xunit;

namespace GildedTros.App
{
    public class GildedTrosTest
    {
        [Fact]
        public void Foo()
        {
            IList<IItem> Items = new List<IItem> { new BaseItem { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateItem();
            Assert.Equal("foo", Items[0].Name);
        }

        [Fact]
        public void UpdateStandardItemSellInPositive()
        {
            IList<IItem> Items = new List<IItem> { new BaseItem { Name = "standardItem", SellIn = 10, Quality = 10 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateItem();
            Assert.Equal(9, Items[0].SellIn);
            Assert.Equal(9, Items[0].Quality);
        }

        [Fact]
        public void UpdateStandardItemSellInNegative()
        {
            IList<IItem> Items = new List<IItem> { new BaseItem { Name = "standardItem", SellIn = -1, Quality = 10 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateItem();
            Assert.Equal(-2, Items[0].SellIn);
            Assert.Equal(8, Items[0].Quality);
        }

        [Fact]
        public void UpdateStandardItemQualityZero()
        {
            IList<IItem> Items = new List<IItem> { new BaseItem { Name = "standardItem", SellIn = 10, Quality = 0 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateItem();
            Assert.Equal(9, Items[0].SellIn);
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void UpdateSmellyItemSellInPositive()
        {
            IList<IItem> Items = new List<IItem> {
                new SmellyItem { Name = "Duplicate Code", SellIn = 10, Quality = 10 },
                new SmellyItem { Name = "Long Methods", SellIn = 11, Quality = 9 },
                new SmellyItem { Name = "Ugly Variable Names", SellIn = 12, Quality = 8 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateItem();
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
            IList<IItem> Items = new List<IItem> {
                new SmellyItem { Name = "Duplicate Code", SellIn = -1, Quality = 10 },
                new SmellyItem { Name = "Long Methods", SellIn = -2, Quality = 11 },
                new SmellyItem { Name = "Ugly Variable Names", SellIn = -3, Quality = 12 },
            };
            GildedTros app = new GildedTros(Items);
            app.UpdateItem();
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
            IList<IItem> Items = new List<IItem> {
                new SmellyItem { Name = "Duplicate Code", SellIn = 10, Quality = 0 },
                new SmellyItem { Name = "Long Methods", SellIn = 11, Quality = 0 },
                new SmellyItem { Name = "Ugly Variable Names", SellIn = 12, Quality = 0 },
            };
            GildedTros app = new GildedTros(Items);
            app.UpdateItem();
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
            IList<IItem> Items = new List<IItem> { new LegendaryItem { Name = "B-DAWG Keychain", SellIn = 10, Quality = 80 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateItem();
            Assert.Equal(10, Items[0].SellIn);
            Assert.Equal(80, Items[0].Quality);
        }

        [Fact]
        public void UpdateLegendaryItemSellInNegative()
        {
            IList<IItem> Items = new List<IItem> { new LegendaryItem { Name = "B-DAWG Keychain", SellIn = -1, Quality = 80 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateItem();
            Assert.Equal(-1, Items[0].SellIn);
            Assert.Equal(80, Items[0].Quality);
        }

        [Fact]
        public void UpdateGoodItemSellInPositive()
        {
            IList<IItem> Items = new List<IItem> { new GoodItem { Name = "Good Wine", SellIn = 10, Quality = 10 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateItem();
            Assert.Equal(9, Items[0].SellIn);
            Assert.Equal(11, Items[0].Quality);
        }

        [Fact]
        public void UpdateGoodItemQualityZero()
        {
            IList<IItem> Items = new List<IItem> { new GoodItem { Name = "Good Wine", SellIn = 10, Quality = 0 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateItem();
            Assert.Equal(9, Items[0].SellIn);
            Assert.Equal(1, Items[0].Quality);
        }

        [Fact]
        public void UpdateBackStageItemSellInPositive()
        {
            IList<IItem> Items = new List<IItem> {
                new BackstagePass { Name = "Backstage passes for Re:factor", SellIn = 15, Quality = 20 },
                new BackstagePass { Name = "Backstage passes for HAXX", SellIn = 15, Quality = 20 }
            };
            GildedTros app = new GildedTros(Items);
            app.UpdateItem();
            Assert.Equal(14, Items[0].SellIn);
            Assert.Equal(21, Items[0].Quality);
            Assert.Equal(14, Items[1].SellIn);
            Assert.Equal(21, Items[1].Quality);
        }

        [Fact]
        public void UpdateBackStageItemSellIn10OrLess()
        {
            IList<IItem> Items = new List<IItem> {
                new BackstagePass { Name = "Backstage passes for Re:factor", SellIn = 10, Quality = 20 },
                new BackstagePass { Name = "Backstage passes for HAXX", SellIn = 10, Quality = 20 },
            };
            GildedTros app = new GildedTros(Items);
            app.UpdateItem();
            Assert.Equal(9, Items[0].SellIn);
            Assert.Equal(22, Items[0].Quality);
            Assert.Equal(9, Items[1].SellIn);
            Assert.Equal(22, Items[1].Quality);
        }
        [Fact]
        public void UpdateBackStageItemSellIn5OrLess()
        {
            IList<IItem> Items = new List<IItem> {
                new BackstagePass { Name = "Backstage passes for Re:factor", SellIn = 5, Quality = 20 },
                new BackstagePass { Name = "Backstage passes for HAXX", SellIn = 5, Quality = 20 },
            };
            GildedTros app = new GildedTros(Items);
            app.UpdateItem();
            Assert.Equal(4, Items[0].SellIn);
            Assert.Equal(23, Items[0].Quality);
            Assert.Equal(4, Items[1].SellIn);
            Assert.Equal(23, Items[1].Quality);
        }

        [Fact]
        public void UpdateBackStageItemSellIn0OrLess()
        {
            IList<IItem> Items = new List<IItem> {
                new BackstagePass { Name = "Backstage passes for Re:factor", SellIn = 0, Quality = 20 },
                new BackstagePass { Name = "Backstage passes for HAXX", SellIn = 0, Quality = 20 }, };
            GildedTros app = new GildedTros(Items);
            app.UpdateItem();
            Assert.Equal(-1, Items[0].SellIn);
            Assert.Equal(0, Items[0].Quality);
            Assert.Equal(-1, Items[1].SellIn);
            Assert.Equal(0, Items[1].Quality);
        }

    }
}