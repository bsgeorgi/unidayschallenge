using System;
using System.Collections.Generic;

namespace Unidays
{
    class Program
    {
        static void Main(string[] args)
        {
            var pricingRules = new Dictionary<string, DiscountType>()
            {
                { "A", new DiscountType{ Promotion = "None", Price = 8.00 } },
                { "B", new DiscountType{ Promotion = "2 for £20.00", Price = 12.00, PricePerQuantity = 20.00, Quantity = 2 } },
                { "C", new DiscountType{ Promotion = "3 for £10.00", Price = 4.00, PricePerQuantity = 10.00, Quantity = 3 } },
                { "D", new DiscountType{ Promotion = "Buy 1 get 1 free", Price = 7.00, PricePerQuantity = 7.00, Quantity = 2 } },
                { "E", new DiscountType{ Promotion = "3 for the price of 2", Price = 5.00, PricePerQuantity = 10.00, Quantity = 3 } }
            };

            var example = new UnidaysDiscountChallenge(pricingRules);
            example.AddToBasket("E");
            example.AddToBasket("D");
            example.AddToBasket("C");
            example.AddToBasket("B");
            example.AddToBasket("A");
            example.AddToBasket("E");

            example.AddToBasket("D");
            example.AddToBasket("B");
            example.AddToBasket("C");
            example.AddToBasket("C");

            var result = example.CalculateTotalPrice();

            var totalPrice = result.Item1;
            var deliveryCharge = result.Item2;
            var overallTotal = totalPrice + deliveryCharge;

            Console.WriteLine($"Total price: {totalPrice}. Delivery charge: {deliveryCharge}. Overall: {overallTotal}");

            Console.ReadKey();
        }
    }
}
