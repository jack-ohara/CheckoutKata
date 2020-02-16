using CheckoutKata;
using NUnit.Framework;

namespace CheckoutKataTests
{
    [TestFixture]
    public class SpecialOfferTests
    {
        [TestCase(null)]
        [TestCase("")]
        [TestCase("       ")]
        public void ThrowsExceptionIfTheItemSkyIsNullOrWhitespace(string itemSku)
        {
            Assert.That(() => new SpecialOffer(itemSku, 0, 0),
                Throws.ArgumentException.With.Message.EqualTo("A SKU must be provided for a special offer"));
        }
    }
}