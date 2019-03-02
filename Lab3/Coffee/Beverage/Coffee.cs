namespace Coffee.Beverage
{
    class Coffee : BaseBeverage
    {
        public Coffee( string description = "Coffee" )
            : base( description )
        {
        }

        public override double GetCost()
        {
            return 60;
        }
    }
}
