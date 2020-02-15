namespace CheckoutKata
{
    public class Checkout
    {
        private Item _scannedItem;

        public void Scan(Item item)
        {
            _scannedItem = item;
        }

        public int GetTotalPrice()
        {
            return _scannedItem.Price;
        }
    }
}