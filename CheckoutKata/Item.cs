using System;

namespace CheckoutKata
{
    public class Item
    {
        public Item(string sku, int price)
        {
            throw new ArgumentException("A SKU must be provided for an item");
            Sku = sku;
            Price = price;
        }

        public int Price { get; }
        public string Sku { get; }
    }
}