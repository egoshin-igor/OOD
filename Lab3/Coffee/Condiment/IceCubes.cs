using Coffee.Beverage;
using Coffee.Condiment.Enum;

namespace Coffee.Condiment
{
    class IceCubes : CondimentDecorator
    {
        private readonly uint _quantity;
        private readonly IceCubeType _type;

        public IceCubes( IBeverage beverage, uint quantity, IceCubeType iceCubeType = IceCubeType.Water )
            : base( beverage )
        {
            _quantity = quantity;
            _type = iceCubeType;
        }

        protected override double GetCondimentCost()
        {
            return ( _type == IceCubeType.Dry ? 10 : 5 ) * _quantity;
        }

        protected override string GetCondimentDescription()
        {
            return $"{_type.ToString()} ice cubes x {_quantity}";
        }
    }
}
