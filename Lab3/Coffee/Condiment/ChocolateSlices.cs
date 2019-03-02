using Coffee.Beverage;

namespace Coffee.Condiment
{
    class ChocolateSlices : CondimentDecorator
    {
        private readonly uint _quantity;

        public ChocolateSlices( IBeverage beverage, uint quantity )
            : base( beverage )
        {
            const int maxSlicesQuantity = 5;

            _quantity = quantity > maxSlicesQuantity ? maxSlicesQuantity : quantity;
        }

        protected override double GetCondimentCost()
        {
            return 10 * _quantity;
        }

        protected override string GetCondimentDescription()
        {
            return $"Chocolate slices x {_quantity}";
        }
    }
}
