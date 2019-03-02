using Coffee.Beverage.Enum;

namespace Coffee.Beverage
{
    class Latte : Coffee
    {
        private readonly ServingQuantityType _servingType;

        public Latte( ServingQuantityType servingType )
            : base( $"{servingType.ToString()} latte" )
        {
            _servingType = servingType;
        }

        public override double GetCost()
        {
            return _servingType == ServingQuantityType.Single ? 90 : 130;
        }
    }
}
