using Coffee.Beverage;
using Coffee.Condiment.Enum;

namespace Coffee.Condiment
{
    class Liquor : CondimentDecorator
    {
        private readonly uint _quantity;
        private readonly LiquorType _type;

        public Liquor( IBeverage beverage, LiquorType liquorType )
            : base( beverage )
        {
            _type = liquorType;
        }

        protected override double GetCondimentCost()
        {
            return 50;
        }

        protected override string GetCondimentDescription()
        {
            return $"{_type.ToString()} liquor";
        }
    }
}
