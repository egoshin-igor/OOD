using System.Collections.Generic;
using Coffee.Beverage.Enum;

namespace Coffee.Beverage
{
    class Milkshake : BaseBeverage
    {
        private static readonly Dictionary<ServingAmountType, double> _priceByServingTypes = new Dictionary<ServingAmountType, double>
        {
            [ ServingAmountType.Small ] = 50,
            [ ServingAmountType.Middle ] = 60,
            [ ServingAmountType.Big ] = 80,
        };

        private readonly ServingAmountType _servingType;

        public Milkshake( ServingAmountType servingType )
            : base( $"{servingType.ToString()} milkshake" )
        {
            _servingType = servingType;
        }

        public override double GetCost()
        {
            return _priceByServingTypes[ _servingType ];
        }
    }
}
