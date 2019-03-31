using NUnit.Framework;
using System.Collections.Generic;

namespace GildedRoseSolution
{

    [TestFixture]
    public class GildedRoseTests
    {
        //Normal item
        [Test]
        public void DownSellinValueByOneAtEndOfDay()
        {
            List<Item> itemList = new List<Item>();
            var item = new Item()
            {
                Name = "TestItem",
                Quality = 1,
                SellIn = 1
            };
            itemList.Add(item);
            var app = new GildedRose(itemList);
            app.UpdateQuality();
            Assert.AreEqual(0, item.SellIn);
        }

        [Test]
        public void DownQualityByOneIfSellInIsPositive()
        {
            List<Item> itemList = new List<Item>();
            var item = new Item()
            {
                Name = "TestItem",
                Quality = 1,
                SellIn = 1
            };
            itemList.Add(item);
            var app = new GildedRose(itemList);
            app.UpdateQuality();
            Assert.AreEqual(0, item.Quality);
        }

        [Test]
        public void DownQualityByTwoIfSellInIsNegative()
        {
            List<Item> itemList = new List<Item>();
            var item = new Item()
            {
                Name = "TestItem",
                Quality = 2,
                SellIn = -1
            };
            itemList.Add(item);
            var app = new GildedRose(itemList);
            app.UpdateQuality();
            Assert.AreEqual(0, item.Quality);
        }

        [Test]
        public void QualityCanNotBeNegative()
        {
            List<Item> itemList = new List<Item>()
            {
                new Item() { Name = "TestItem", Quality = 0, SellIn = -1 },
                new Item() { Name = "TestItem", Quality = 1, SellIn = 0 }
            };

            var app = new GildedRose(itemList);
            app.UpdateQuality();
            Assert.AreEqual(0, itemList[0].Quality);
            Assert.AreEqual(0, itemList[1].Quality);
        }
        //sulfuras item
        [Test]
        public void SulfurasDoesNotDecreaseItsQualityNorSellInDays()
        {
            List<Item> itemList = new List<Item>()
            {
                new Item() { Name = "Sulfuras", Quality = 10, SellIn = 20 }
            };

            var app = new GildedRose(itemList);
            app.UpdateQuality();
            Assert.AreEqual(10, itemList[0].Quality);
            Assert.AreEqual(20, itemList[0].SellIn);
        }
        //Conjured item
        [Test]
        public void ConjuredDecreaseQualityByTwoWhenSellInIsPositive()
        {
            List<Item> itemList = new List<Item>()
            {
                new Item() { Name = "Conjured", Quality = 10, SellIn = 20 }
            };

            var app = new GildedRose(itemList);
            app.UpdateQuality();
            Assert.AreEqual(8, itemList[0].Quality);
        }

        [Test]
        public void ConjuredDecreaseQualityByFourWhenSellInIsNegative()
        {
            List<Item> itemList = new List<Item>()
            {
                new Item() { Name = "Conjured", Quality = 4, SellIn = 0 }
            };

            var app = new GildedRose(itemList);
            app.UpdateQuality();
            Assert.AreEqual(0, itemList[0].Quality);
        }

        [Test]
        public void ConjuredQualityShouldNeverBeLowerThanZero()
        {
            List<Item> itemList = new List<Item>()
            {
                new Item() { Name = "Conjured", Quality = 4, SellIn = 5 },
            };
            var app = new GildedRose(itemList);
            for(int i = 0; i <10; i++)
            {
                app.UpdateQuality();
            }
            app.UpdateQuality();
            Assert.AreEqual(0, itemList[0].Quality);
        }
        //backstage item
        [Test]
        public void BackstageItemIncreasesQualityByOneIfSellInBiggerThanTen()
        {
            List<Item> itemList = new List<Item>()
            {
                new Item() { Name = "Backstage passes", Quality = 10, SellIn = 20 }
            };

            var app = new GildedRose(itemList);
            app.UpdateQuality();
            Assert.AreEqual(11, itemList[0].Quality);
        }

        [Test]
        public void BackstageItemIncreasesQualityByTwoIfSellInEqualOrLowerThanTen()
        {
            List<Item> itemList = new List<Item>()
            {
                new Item() { Name = "Backstage passes", Quality = 10, SellIn = 10 }
            };

            var app = new GildedRose(itemList);
            app.UpdateQuality();
            Assert.AreEqual(12, itemList[0].Quality);
        }

        [Test]
        public void BackstageItemIncreasesQualityByThreIfSellInEqualOrLowerThanFive()
        {
            List<Item> itemList = new List<Item>()
            {
                new Item() { Name = "Backstage passes", Quality = 10, SellIn = 5 }
            };

            var app = new GildedRose(itemList);
            app.UpdateQuality();
            Assert.AreEqual(13, itemList[0].Quality);
        }

        [Test]
        public void BackstageItemQualityIsZeroIfSellInIsNegative()
        {
            List<Item> itemList = new List<Item>()
            {
                new Item() { Name = "Backstage passes", Quality = 10, SellIn = 0 }
            };

            var app = new GildedRose(itemList);
            app.UpdateQuality();
            Assert.AreEqual(0, itemList[0].Quality);
        }

        [Test]
        public void BackstageItemQualityCanNotBeGreaterThanFifty()
        {
            List<Item> itemList = new List<Item>()
            {
                new Item() { Name = "Backstage passes", Quality = 49, SellIn = 11 },
                new Item() { Name = "Backstage passes", Quality = 49, SellIn = 10 },
                new Item() { Name = "Backstage passes", Quality = 49, SellIn = 5 },
            };

            var app = new GildedRose(itemList);
            app.UpdateQuality();
            Assert.AreEqual(50, itemList[0].Quality);
            Assert.AreEqual(50, itemList[1].Quality);
            Assert.AreEqual(50, itemList[2].Quality);
        }


        //Aged Brie
        [Test]
        public void AgedBrieItemIncreasesQualityByOneIfSellInIsPositive()
        {
            List<Item> itemList = new List<Item>()
            {
                new Item() { Name = "Aged Brie", Quality = 10, SellIn = 1 }
            };

            var app = new GildedRose(itemList);
            app.UpdateQuality();
            Assert.AreEqual(11, itemList[0].Quality);
        }

        [Test]
        public void AgedBrieItemIncreasesQualityByTwoIfSellInIsZeroOrNegative()
        {
            List<Item> itemList = new List<Item>()
            {
                new Item() { Name = "Aged Brie", Quality = 10, SellIn = 0 }
            };

            var app = new GildedRose(itemList);
            app.UpdateQuality();
            Assert.AreEqual(12, itemList[0].Quality);
        }

        [Test]
        public void AgedBrieItemCannotIncreaseQualityOverFifty()
        {
            List<Item> itemList = new List<Item>()
            {
                new Item() { Name = "Aged Brie", Quality = 49, SellIn = 10 },
                new Item() { Name = "Aged Brie", Quality = 49, SellIn = 0 },
                new Item() { Name = "Aged Brie", Quality = 49, SellIn = -2 },
            };

            var app = new GildedRose(itemList);
            app.UpdateQuality();
            Assert.AreEqual(50, itemList[0].Quality);
            Assert.AreEqual(50, itemList[1].Quality);
            Assert.AreEqual(50, itemList[2].Quality);
        }
    }
}
