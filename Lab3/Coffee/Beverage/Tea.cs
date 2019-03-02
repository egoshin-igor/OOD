using Coffee.Beverage.Enum;

namespace Coffee.Beverage
{
    class Tea : BaseBeverage
    {
        public Tea( TeaType teaType )
            : base( $"{teaType.ToString()} tea" )
        {
        }

        public override double GetCost()
        {
            return 30;
        }
    }
}
