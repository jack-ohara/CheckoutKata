using CheckoutKata;
using NUnit.Framework;

namespace CheckoutKataTests
{
    [TestFixture]
    public class CheckoutTests
    {
        private Checkout _checkout;

        [SetUp]
        public void SetUp()
        {
            _checkout = new Checkout();
        }

        [Test]
        public void ReturnsThePriceOfASingleScannedItem()
        {
            var item = new Item("A", 50);

            _checkout.Scan(item);

            var totalPrice = _checkout.GetTotalPrice();

            Assert.That(totalPrice, Is.EqualTo(item.Price));
        }
    }

}