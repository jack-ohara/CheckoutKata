using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata
{
    public class Checkout
    {
        private readonly List<Item> _scannedItems;

        public Checkout()
        {
            _scannedItems = new List<Item>();
        }

        public void Scan(Item item)
        {
            _scannedItems.Add(item);
        }

        public int GetTotalPrice()
        {
            return _scannedItems.Sum(item => item.Price);
        }
    }
}