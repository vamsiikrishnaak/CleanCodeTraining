using Moq;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System.Collections.Generic;

namespace hamaraBasket.Tests
{
    [TestFixture]
    public class HamaraBasketTest
    {

        [Test]
        public void SellByValueShouldBeReducedByOneAtEOD()
        {
            int sellIn = 10;
            int quality = 10;
            string name = "Lux Soap";
            DomainFactory domainFactory = new DomainFactory();
            IList<Item> items = domainFactory.PrepareSingleItemList(name, sellIn, quality);

            Item item = domainFactory.GetItemAfterHamaraBasketUpdate(items);

            Assert.That(sellIn - 1, Is.EqualTo(item.SellIn));
        }

        [Test]
        public void QualityValueShouldBeReducedByOneAtEOD()
        {
            int sellIn = 10;
            int quality = 10;
            string name = "Lux Soap";
            DomainFactory domainFactory = new DomainFactory();
            IList<Item> items = domainFactory.PrepareSingleItemList(name, sellIn, quality);

            Item item = domainFactory.GetItemAfterHamaraBasketUpdate(items);

            Assert.That(quality - 1, Is.EqualTo(item.Quality));
        }

        [Test]
        public void QualityValueShouldBeReducedTwoAfterEODOnceSellByDateIsPassed()
        {
            int sellIn = -1;
            int quality = 10;
            string name = "Lux Soap";
            DomainFactory domainFactory = new DomainFactory();
            IList<Item> items = domainFactory.PrepareSingleItemList(name, sellIn, quality);

            Item item = domainFactory.GetItemAfterHamaraBasketUpdate(items);

            Assert.That(quality - 2, Is.EqualTo(item.Quality));
        }

        [Test]
        public void QualityValueIsNeverNegative()
        {
            int sellIn = -50;
            int quality = 1;
            string name = "Lux Soap";
            DomainFactory domainFactory = new DomainFactory();
            IList<Item> items = domainFactory.PrepareSingleItemList(name, sellIn, quality);

            Item item = domainFactory.GetItemAfterHamaraBasketUpdate(items);

            Assert.That(item.Quality, Is.EqualTo(0));
        }

        [Test]
        public void QualityValueShouldBeIncreasedForIndianWineAtEOD()
        {
            int sellIn = 10;
            int quality = 10;
            string name = "Indian Wine";
            DomainFactory domainFactory = new DomainFactory();
            IList<Item> items = domainFactory.PrepareSingleItemList(name, sellIn, quality);

            Item item = domainFactory.GetItemAfterHamaraBasketUpdate(items);

            Assert.That(item.Quality, Is.GreaterThanOrEqualTo(quality));
        }

        [Test]
        public void QualityValueNeverCrosses50ForIndianWine()
        {
            int sellIn = 10;
            int quality = 50;
            string name = "Indian Wine";
            DomainFactory domainFactory = new DomainFactory();
            IList<Item> items = domainFactory.PrepareSingleItemList(name, sellIn, quality);

            Item item = domainFactory.GetItemAfterHamaraBasketUpdate(items);

            Assert.That(item.Quality, Is.LessThanOrEqualTo(50));
        }

        [Test]
        public void QualityValueNeverCrosses50ForMovieTickets()
        {
            int sellIn = 5;
            int quality = 50;
            string name = "Movie Tickets";
            DomainFactory domainFactory = new DomainFactory();
            IList<Item> items = domainFactory.PrepareSingleItemList(name, sellIn, quality);

            Item item = domainFactory.GetItemAfterHamaraBasketUpdate(items);

            Assert.That(item.Quality, Is.LessThanOrEqualTo(50));
        }

        [Test]
        public void QualityValueNeverReducesForForestHoney()
        {
            int sellIn = 10;
            int quality = 10;
            string name = "Forest Honey";
            DomainFactory domainFactory = new DomainFactory();
            IList<Item> items = domainFactory.PrepareSingleItemList(name, sellIn, quality);

            Item item = domainFactory.GetItemAfterHamaraBasketUpdate(items);

            Assert.That(item.Quality, Is.EqualTo(quality));
        }

        [Test]
        public void QualityValueIncreasesBy2ForMovieTickets10daysBeforeShow()
        {
            int sellIn = 10;
            int quality = 10;
            string name = "Movie Tickets";
            DomainFactory domainFactory = new DomainFactory();
            IList<Item> items = domainFactory.PrepareSingleItemList(name, sellIn, quality);

            Item item = domainFactory.GetItemAfterHamaraBasketUpdate(items);

            Assert.That(quality + 2, Is.EqualTo(item.Quality));
        }

        [Test]
        public void QualityValueIncreasesBy3ForMovieTickets5daysBeforeShow()
        {
            int sellIn = 5;
            int quality = 10;
            string name = "Movie Tickets";
            DomainFactory domainFactory = new DomainFactory();
            IList<Item> items = domainFactory.PrepareSingleItemList(name, sellIn, quality);

            Item item = domainFactory.GetItemAfterHamaraBasketUpdate(items);

            Assert.That(quality + 3, Is.EqualTo(item.Quality));
        }

        [Test]
        public void QualityValueIs0ForMovieTicketsAfterShow()
        {
            int sellIn = 0;
            int quality = 10;
            string name = "Movie Tickets";
            DomainFactory domainFactory = new DomainFactory();
            IList<Item> items = domainFactory.PrepareSingleItemList(name, sellIn, quality);

            Item item = domainFactory.GetItemAfterHamaraBasketUpdate(items);

            Assert.That(0, Is.EqualTo(item.Quality));
        }

        [Test]
        public void QualityIs0AtEODIfInitialValueIsNegative()
        {
            int sellIn = 10;
            int quality = -10;
            string name = "Lux Soap";
            DomainFactory domainFactory = new DomainFactory();
            IList<Item> items = domainFactory.PrepareSingleItemList(name, sellIn, quality);

            Item item = domainFactory.GetItemAfterHamaraBasketUpdate(items);

            Assert.That(item.Quality, Is.EqualTo(0));
        }

        [Test]
        public void QualityRemainsAt50AtEODIfInitialValueIsAbove50()
        {
            int sellIn = 10;
            int quality = 55;
            string name = "Lux Soap";
            DomainFactory domainFactory = new DomainFactory();
            IList<Item> items = domainFactory.PrepareSingleItemList(name, sellIn, quality);

            Item item = domainFactory.GetItemAfterHamaraBasketUpdate(items);

            Assert.That(item.Quality, Is.EqualTo(50));
        }

        [Test]
        public void UpdateQualityCalledForItem()
        {
            DomainFactory domainFactory = new DomainFactory();
            Mock<Item> itemMock = new Mock<Item>();

            _ = domainFactory.GetItemAfterHamaraBasketUpdate(new List<Item>() { itemMock.Object });

            itemMock.Verify(i => i.UpdateQuality(), Times.Once);
        }

        [Test]
        public void QualityReducesBy2ForSoftDrinkItem()
        {
            int sellIn = 10;
            int quality = 10;
            string name = "Soft Drink";
            DomainFactory domainFactory = new DomainFactory();
            IList<Item> items = domainFactory.PrepareSingleItemList(name, sellIn, quality);

            Item item = domainFactory.GetItemAfterHamaraBasketUpdate(items);

            Assert.That(quality - 2, Is.EqualTo(item.Quality));
        }

        [Test]
        public void QualityReducesBy4ForSoftDrinkItemAfterSellByDate()
        {
            int sellIn = -1;
            int quality = 10;
            string name = "Soft Drink";
            DomainFactory domainFactory = new DomainFactory();
            IList<Item> items = domainFactory.PrepareSingleItemList(name, sellIn, quality);

            Item item = domainFactory.GetItemAfterHamaraBasketUpdate(items);

            Assert.That(quality - 4, Is.EqualTo(item.Quality));
        }
    }
}
