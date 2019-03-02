using Coffee.Beverage.Enum;

namespace Coffee.Beverage
{
    class Capuccino : Coffee
    {
        private readonly ServingQuantityType _servingType;

        public Capuccino( ServingQuantityType servingType )
            : base( $"{servingType.ToString()} capuccino" )
        {
            _servingType = servingType;
        }

        public override double GetCost()
        {
            return _servingType == ServingQuantityType.Single ? 80 : 120;
        }
    }
}
