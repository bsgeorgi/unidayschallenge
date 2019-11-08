namespace Unidays
{
    sealed class DiscountType
    {
        public string Promotion { get; set; }
        public double Price { get; set; }

        public double PricePerQuantity { get; set; }

        public int Quantity { get; set; }
    }
}
