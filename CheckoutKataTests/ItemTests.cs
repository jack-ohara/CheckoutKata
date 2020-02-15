using CheckoutKata;
using NUnit.Framework;

namespace CheckoutKataTests
{
    [TestFixture]
    public class ItemTests
    {
        [TestCase(null)]
        [TestCase("")]
        [TestCase("      ")]
        public void ThrowsAnErrorIfProvidedWithANullOrEmptySkuValue(string sku)
        {
            Assert.That(() => new Item(sku, 0),
                Throws.ArgumentException.With.Message.EqualTo("A SKU must be provided for an item"));
        }
    }
}