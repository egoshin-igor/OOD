using Coffee.Beverage;

namespace Coffee.Condiment
{
    class ChocolateCrumbs : CondimentDecorator
    {
        private readonly uint _mass;

        public ChocolateCrumbs( IBeverage beverage, uint mass )
            : base( beverage )
        {
            _mass = mass;
        }

        protected override double GetCondimentCost()
        {
            return 2 * _mass;
        }

        protected override string GetCondimentDescription()
        {
            return $"Chocolate crumbs {_mass} g";
        }
    }
}
