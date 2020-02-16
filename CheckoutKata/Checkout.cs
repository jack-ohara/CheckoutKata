using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata
{
    public class Checkout
    {
        private readonly HashSet<SpecialOffer> _specialOffers;
        private readonly List<Item> _scannedItems;

        public Checkout(HashSet<SpecialOffer> specialOffers)
        {
            _specialOffers = specialOffers;
            _scannedItems = new List<Item>();
        }

        public void Scan(Item item)
        {
            _scannedItems.Add(item);
        }

        public int GetTotalPrice()
        {
            return _specialOffers
                       .FirstOrDefault(offer => _scannedItems.Select(item => item.Sku).Contains(offer.ItemSku))
                       ?.SpecialPrice ?? _scannedItems.Sum(item => item.Price);
        }
    }
}