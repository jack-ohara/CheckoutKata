using CheckoutKata;
using NUnit.Framework;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;

namespace CheckoutKataTests
{
    [TestFixture]
    public class CheckoutTests
    {
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
                yield return new object[] {new[] {Items["B"], Items["B"]}, 45};
                yield return new object[] {new[] {Items["A"], Items["A"], Items["A"], Items["B"], Items["B"]}, 175};
                yield return new object[] {new[] {Items["A"], Items["B"], Items["A"], Items["B"], Items["A"]}, 175};

                yield return new object[] {new[] {Items["C"], Items["B"], Items["D"], Items["A"], Items["B"]}, 125};
            }
        }

        [TestCaseSource(nameof(CheckoutTestData))]
        public void ReturnsThePriceOfASingleScannedItem(IEnumerable<Item> items, int expectedPrice)
        {
            var checkout = new Checkout(SpecialOffers);

            foreach (var item in items)
            {
                checkout.Scan(item);
            }

            var totalPrice = checkout.GetTotalPrice();

            Assert.That(totalPrice, Is.EqualTo(expectedPrice));
        }

        [Test]
        public void DoesNotThrowExceptionWhenGettingTotalIfSpecialOffersIsNull()
        {
            var checkout = new Checkout(null);

            checkout.Scan(Items["A"]);
            checkout.Scan(Items["B"]);
            checkout.Scan(Items["A"]);

            Assert.That(() => checkout.GetTotalPrice(), Throws.Nothing);
        }
    }
}