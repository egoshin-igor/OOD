namespace Coffee.Beverage
{
    abstract class BaseBeverage : IBeverage
    {
        private readonly string _description;

        public BaseBeverage( string description )
        {
            _description = description;
        }

        public abstract double GetCost();

        public string GetDescription()
        {
            return _description;
        }
    }
}
