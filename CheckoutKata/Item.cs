namespace CheckoutKata
{
    public class Item
    {
        public Item(string sku, int price)
        {
            Price = price;
        }

        public int Price { get; }
    }
}