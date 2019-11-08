using System;
using System.Collections.Generic;
using System.Linq;

namespace Unidays
{
    sealed class UnidaysDiscountChallenge
    {
        private Dictionary<string, DiscountType> PricingRules;

        // Temporary Holder
        private List<UnidaysItem> Items = new List<UnidaysItem>();

        // Counter
        List<ItemCounter> ItemsCount;
        internal UnidaysDiscountChallenge(Dictionary<string, DiscountType> PricingRules)
        {
            this.PricingRules = PricingRules;
        }
        internal void AddToBasket(string itemID)
        {
            Items.Add( new UnidaysItem { Name = itemID } );
        }

        private void RemoveFromBasket(string itemID)
        {
            Items.RemoveAll(r => r.Name.Equals(itemID));
        }

        private void RemoveAllNoRules()
        {
            foreach (var item in ItemsCount)
            {
                if (!PricingRules.ContainsKey(item.Item))
                {
                    RemoveFromBasket(item.Item);
                }
            }
        }

        private List<ItemCounter> GetItems()
        {
            var itemGroups = Items.GroupBy( x => new { x.Name } )
                .Select(g => new ItemCounter { Item = g.Key.Name, Count = g.Count() }).ToList();
            return itemGroups;
        }

        internal Tuple<double, double> CalculateTotalPrice()
        {
            double result = 0;
            double charge = 7.00;

            // Get initial list
            ItemsCount = GetItems();

            // Check for items without pricing rules, remove them
            RemoveAllNoRules();

            // Reload the item list
            ItemsCount = GetItems();

            foreach (var item in ItemsCount)
            {
                if (PricingRules.ContainsKey(item.Item))
                {
                    var Promotion = PricingRules[item.Item].Promotion;
                    var Price = PricingRules[item.Item].Price;
                    var PricePerQ = PricingRules[item.Item].PricePerQuantity;
                    var Q = PricingRules[item.Item].Quantity;


                    // Check if we have enough items for promotion // Check if promotion exists
                    if ((PricePerQ != 00 && Q != 0) && item.Count >= Q)
                    {
                        int promotionCount = Math.DivRem(item.Count, Q, out int remainder);

                        // Apply promotion price
                        result += promotionCount * PricePerQ;

                        // Check if we have any items left without the promotion
                        if (remainder != 0)
                        {
                            // Apply normal price
                            result += Price;
                        }
                    }
                    else
                    {
                        // Apply price without the promotion
                        result += item.Count * Price;
                    }
                }
            }

            // If order is over 50 pound or there are no items in the basket, set delivery charge to 0
            if (result >= 50 || Items.Count == 0)
                charge = 0;

            return new Tuple<double, double>(result, charge);
        }
    }
}
