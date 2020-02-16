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
            var total = 0;

            var itemsAndCount = _scannedItems.GroupBy(item => item.Sku);

            foreach (var groupBySku in itemsAndCount)
            {
                var specialOffer = _specialOffers.FirstOrDefault(offer => offer.ItemSku.Equals(groupBySku.Key));

                if (specialOffer != null)
                {
                    total += groupBySku.Count() / specialOffer.QualifyingNumberOfItems * specialOffer.SpecialPrice;
                    total += (groupBySku.Count() % specialOffer.QualifyingNumberOfItems) * groupBySku.First().Price;
                }
                else
                {
                    total += groupBySku.Count() * groupBySku.First().Price;
                }
            }

            return total;
        }
    }
}