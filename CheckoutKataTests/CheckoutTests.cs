using CheckoutKata;
using NUnit.Framework;
using System.Collections.Generic;

namespace CheckoutKataTests
{
    [TestFixture]
    public class CheckoutTests
    {
        private Checkout _checkout;

        private static IEnumerable<object[]> CheckoutTestData
        {
            get
            {
                yield return new object[] {new[] {new Item("A", 50)}, 50};
                yield return new object[] {new[] {new Item("B", 30)}, 30};
                yield return new object[] {new[] {new Item("C", 20)}, 20};
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