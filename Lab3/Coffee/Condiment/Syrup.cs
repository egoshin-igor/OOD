using Coffee.Beverage;
using Coffee.Condiment.Enum;

namespace Coffee.Condiment
{
    class Syrup : CondimentDecorator
    {
        private readonly SyrupType _type;

        public Syrup( IBeverage beverage, SyrupType syrupType )
            : base( beverage )
        {
            _type = syrupType;
        }

        protected override double GetCondimentCost()
        {
            return 15;
        }

        protected override string GetCondimentDescription()
        {
            return $"{_type.ToString()} syrup";
        }
    }
}
