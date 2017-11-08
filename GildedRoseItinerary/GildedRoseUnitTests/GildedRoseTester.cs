using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using GildedRoseItinerary;

namespace GildedRoseUnitTests
{
    [TestFixture]
    public class GildedRoseTester
    {
        #region Update Tests
        [Test]
        public void TestNormalItemUpdateBeforeSellin([Values(2,1)] int sellin, [Values(2,55)] int quality)
        {
            InventoryItem normal = InventoryManager.CreateInstance($"Normal Item {sellin} {quality}");
            Assert.AreEqual(normal.GetType(), typeof(NormalItem));
            normal.Update();

            //sellin is reduced by 1
            Assert.AreEqual(normal.SellIn, sellin -1);

            //quality is reduced by 1
            Assert.AreEqual(normal.Quality, ConstrainedQuality(quality - 1) );
        }

        [Test]
        public void TestNormalItemUpdateAfterSellin([Values(0, -1, -2)] int sellin, [Values(2, 55)] int quality)
        {
            InventoryItem normal = InventoryManager.CreateInstance($"Normal Item {sellin} {quality}");
            Assert.AreEqual(normal.GetType(), typeof(NormalItem));
            normal.Update();

            //sellin is reduced by 1
            Assert.AreEqual(normal.SellIn, sellin - 1);

            //quality is reduced by 2
            Assert.AreEqual(normal.Quality, ConstrainedQuality(quality - 2));
        }

        [Test]
        public void TestAgedBrieItemUpdate([Values(-1, 1)] int sellin, [Values(1,2)] int quality)
        {
            InventoryItem brie = InventoryManager.CreateInstance($"Aged Brie {sellin} {quality}");
            Assert.AreEqual(brie.GetType(), typeof(AgedBrie));
            brie.Update();

            //sellin is reduced by 1
            Assert.AreEqual(brie.SellIn, sellin -1);

            //quality increases by 1
            Assert.AreEqual(brie.Quality, ConstrainedQuality(quality + 1));
        }

        [Test]
        public void TestBackstageItemUpdateTenDaysOrLess([Values(10, 9, 8, 7)] int sellinBeforeDec, [Values(2)] int quality)
        {
            InventoryItem backstage = InventoryManager.CreateInstance($"Backstage passes {sellinBeforeDec} {quality}");
            Assert.AreEqual(backstage.GetType(), typeof(BackStage));
            backstage.Update();

            //sellin is reduced by 1
            Assert.AreEqual(backstage.SellIn, sellinBeforeDec - 1);

            //quality is reduced by 2
            Assert.AreEqual(backstage.Quality, ConstrainedQuality(quality + 2));
        }

        [Test]
        public void TestBackstageItemUpdateFiveDaysOrLess([Values(6, 5, 4, 3, 2)] int sellinBeforeDec, [Values(2)] int quality)
        {
            InventoryItem backstage = InventoryManager.CreateInstance($"Backstage passes {sellinBeforeDec} {quality}");
            Assert.AreEqual(backstage.GetType(), typeof(BackStage));
            backstage.Update();

            //sellin is reduced by 1
            Assert.AreEqual(backstage.SellIn, sellinBeforeDec - 1);

            //quality is reduced by 2
            Assert.AreEqual(backstage.Quality, ConstrainedQuality(quality + 3));
        }

        [Test]
        public void TestBackstageItemUpdateAfterConcert([Values(1, 0, -1)] int sellinBeforeDec, [Values(2)] int quality)
        {
            InventoryItem backstage = InventoryManager.CreateInstance($"Backstage passes {sellinBeforeDec} {quality}");
            Assert.AreEqual(backstage.GetType(), typeof(BackStage));
            backstage.Update();

            //sellin is reduced by 1
            Assert.AreEqual(backstage.SellIn, sellinBeforeDec - 1);

            //quality is reduced by 2
            Assert.AreEqual(backstage.Quality, 0);
        }

        [Test]
        public void TestSulfurasItemUpdate([Values(-1, 0, 2)] int sellin, [Values(0, 1, 2)] int quality)
        {
            InventoryItem sulfuras = InventoryManager.CreateInstance($"Sulfuras {sellin} {quality}");
            Assert.AreEqual(sulfuras.GetType(), typeof(Sulfuras));
            sulfuras.Update();

            //sellin stays the same
            Assert.AreEqual(sulfuras.SellIn, sellin);

            //quality doesnt change
            Assert.AreEqual(sulfuras.Quality, ConstrainedQuality(quality));
        }

        [Test]
        public void TestConjuredItemUpdateBeforeSellin([Values(2)] int sellin, [Values(2, 5)] int quality)
        {
            InventoryItem conjured = InventoryManager.CreateInstance($"Conjured {sellin} {quality}");
            Assert.AreEqual(conjured.GetType(), typeof(Conjured));
            conjured.Update();

            //sellin is reduced by 1
            Assert.AreEqual(conjured.SellIn, sellin -1);

            //quality is reduced twice that of a normal item
            Assert.AreEqual(conjured.Quality, ConstrainedQuality(quality - 2));
        }

        [Test]
        public void TestConjuredItemUpdateAfterSellin([Values(-1)] int sellin, [Values(2, 5)] int quality)
        {
            InventoryItem conjured = InventoryManager.CreateInstance($"Conjured {sellin} {quality}");
            Assert.AreEqual(conjured.GetType(), typeof(Conjured));
            conjured.Update();

            //sellin is reduced by 1
            Assert.AreEqual(conjured.SellIn, sellin - 1);

            //quality is reduced twice that of a normal item
            Assert.AreEqual(conjured.Quality, ConstrainedQuality(quality - 4));
        }

        [Test]
        public void TestInvalidItemUpdate([Values(2)] int sellin, [Values(2)] int quality)
        {
            InventoryItem invalid = InventoryManager.CreateInstance($"INVALID ITEM {sellin} {quality}");
            Assert.AreEqual(invalid.GetType(), typeof(InvalidItem));
            invalid.Update();
            Assert.AreEqual(invalid.Output(), "NO SUCH ITEM\n");
        }
        #endregion

        #region Helper Methods
        //Quality cannot be negative, and has a maximum value of 50
        private int ConstrainedQuality(int quality)
        {
            return Math.Max(0, Math.Min(quality, 50));
        }
        #endregion
    }
}
