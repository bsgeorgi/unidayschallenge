# UNiDAYS Discounts Coding Challenge

## Introduction
I have completed unidays discount coding challenge. The solution is written in C#. To test the programm, pull the repository and run Unidays.sln

## Pricing Rules

| Item | Price  | Discount |
| ---- | ------ | -------- |
| A    | £8.00  | None |
| B    | £12.00 | 2 for £20.00 |
| C    | £4.00  | 3 for £10.00 |
| D    | £7.00  | Buy 1 get 1 free |
| E    | £5.00  | 3 for the price of 2 |

You can add more pricing rules by editing pricingRules dictionary:
```csharp
var pricingRules = new Dictionary<string, DiscountType>()
{
    { "A", new DiscountType{ Promotion = "None", Price = 8.00 } },
    { "B", new DiscountType{ Promotion = "2 for £20.00", Price = 12.00, PricePerQuantity = 20.00, Quantity = 2 } },
    { "C", new DiscountType{ Promotion = "3 for £10.00", Price = 4.00, PricePerQuantity = 10.00, Quantity = 3 } },
    { "D", new DiscountType{ Promotion = "Buy 1 get 1 free", Price = 7.00, PricePerQuantity = 7.00, Quantity = 2 } },
    { "E", new DiscountType{ Promotion = "3 for the price of 2", Price = 5.00, PricePerQuantity = 10.00, Quantity = 3 } }
};
```

Current interface:
```csharp
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

var result = example.CalculateTotalPrice();

var totalPrice = result.Item1;
var deliveryCharge = result.Item2;
var overallTotal = totalPrice + deliveryCharge;
```

Any item that does not contain a corresponding pricing rule will be removed from the basket before the final prices are calculated.
