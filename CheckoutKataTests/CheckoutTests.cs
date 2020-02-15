using CheckoutKata;
using NUnit.Framework;
using System.Collections.Generic;

namespace CheckoutKataTests
{
    [TestFixture]
    public class CheckoutTests
    {
        private Checkout _checkout;

        private static readonly IDictionary<string, Item> Items = new Dictionary<string, Item>
        {
            {"A", new Item("A", 50)},
            {"B", new Item("B", 30)},
            {"C", new Item("C", 20)},
            {"D", new Item("D", 10)}
        };

        private static readonly HashSet<SpecialOffer> SpecialOffers = new HashSet<SpecialOffer>
            {new SpecialOffer("A", 3, 130), new SpecialOffer("B", 2, 45)};

        private static IEnumerable<object[]> CheckoutTestData
        {
            get
            {
                yield return new object[] {new[] {Items["A"]}, 50};
                yield return new object[] {new[] {Items["B"]}, 30};
                yield return new object[] {new[] {Items["C"]}, 20};
                yield return new object[] {new[] {Items["D"]}, 10};

                yield return new object[] {new[] {Items["A"], Items["A"]}, 100};
                yield return new object[] {new[] {Items["A"], Items["B"]}, 80};
                yield return new object[] {new[] {Items["B"], Items["C"]}, 50};

                yield return new object[] {new[] {Items["A"], Items["B"], Items["C"]}, 100};
                yield return new object[] {new[] {Items["B"], Items["D"], Items["A"]}, 90};

                yield return new object[] {new[] {Items["A"], Items["A"], Items["A"]}, 130};
            }
        }

        [SetUp]
        public void SetUp()
        {
            _checkout = new Checkout(SpecialOffers);
        }

        [TestCaseSource(nameof(CheckoutTestData))]
        public void ReturnsThePriceOfASingleScannedItem(IEnumerable<Item> items, int expectedPrice)
        {
            foreach (var item in items)
            {
                _checkout.Scan(item);
            }

            var totalPrice = _checkout.GetTotalPrice();

            Assert.That(totalPrice, Is.EqualTo(expectedPrice));
        }
    }
}