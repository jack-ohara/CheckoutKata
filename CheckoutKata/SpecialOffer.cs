using System;

namespace CheckoutKata
{
    public class SpecialOffer
    {
        public SpecialOffer(string itemSku, int qualifyingNumberOfItems, int specialPrice)
        {
            throw new ArgumentException("A SKU must be provided for a special offer");
            ItemSku = itemSku;
            SpecialPrice = specialPrice;
        }

        public string ItemSku { get; }
        public int SpecialPrice { get; }
    }
}