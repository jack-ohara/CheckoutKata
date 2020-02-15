using CheckoutKata;
using NUnit.Framework;
using System.Collections.Generic;

namespace CheckoutKataTests
{
    [TestFixture]
    public class CheckoutTests
    {
        private Checkout _checkout;

        private static readonly IDictionary<string, Item> _items = new Dictionary<string, Item>
        {
            {"A", new Item("A", 50)},
            {"B", new Item("B", 30)},
            {"C", new Item("C", 20)},
            {"D", new Item("D", 10)}
        };

        private static readonly HashSet<SpecialOffer> _specialOffers = new HashSet<SpecialOffer>
            {new SpecialOffer("A", 3, 130), new SpecialOffer("B", 2, 45)};

        private static IEnumerable<object[]> CheckoutTestData
        {
            get
            {
                yield return new object[] {new[] {_items["A"]}, 50};
                yield return new object[] {new[] {_items["B"]}, 30};
                yield return new object[] {new[] {_items["C"]}, 20};
                yield return new object[] {new[] {_items["D"]}, 10};

                yield return new object[] {new[] {_items["A"], _items["A"]}, 100};
                yield return new object[] {new[] {_items["A"], _items["B"]}, 80};
                yield return new object[] {new[] {_items["B"], _items["C"]}, 50};

                yield return new object[] {new[] {_items["A"], _items["B"], _items["C"]}, 100};
                yield return new object[] {new[] {_items["B"], _items["D"], _items["A"]}, 90};

                yield return new object[] {new[] {_items["A"], _items["A"], _items["A"]}, 130};
            }
        }

        [SetUp]
        public void SetUp()
        {
            _checkout = new Checkout();
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