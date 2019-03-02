using System;
using Coffee.Beverage;

namespace Coffee.Condiment
{
    class Lemon : CondimentDecorator
    {
        private readonly uint _quantity;

        public Lemon( IBeverage beverage, uint quantity = 1 )
            : base( beverage )
        {
            _quantity = quantity;
        }

        protected override double GetCondimentCost()
        {
            return 10 * _quantity;
        }

        protected override string GetCondimentDescription()
        {
            return $"Lemon x {_quantity}";
        }
    }
}
