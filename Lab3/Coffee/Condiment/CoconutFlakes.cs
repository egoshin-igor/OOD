using Coffee.Beverage;

namespace Coffee.Condiment
{
    class CoconutFlakes : CondimentDecorator
    {
        private readonly uint _mass;

        public CoconutFlakes( IBeverage beverage, uint mass )
            : base( beverage )
        {
            _mass = mass;
        }

        protected override double GetCondimentCost()
        {
            return 1 * _mass;
        }

        protected override string GetCondimentDescription()
        {
            return $"Coconut flakes {_mass} g";
        }
    }
}
