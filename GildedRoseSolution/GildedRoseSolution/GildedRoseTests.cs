using NUnit.Framework;
using System.Collections.Generic;

namespace GildedRoseSolution
{

    [TestFixture]
    public class GildedRoseTests
    {
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
    }
}
