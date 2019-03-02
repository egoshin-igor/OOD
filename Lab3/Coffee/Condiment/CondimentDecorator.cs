using System;
using Coffee.Beverage;

namespace Coffee.Condiment
{
    abstract class CondimentDecorator : IBeverage
    {
        private readonly IBeverage _beverage;

        protected CondimentDecorator( IBeverage beverage )
        {
            _beverage = beverage;
        }

        public double GetCost()
        {
            return _beverage.GetCost() + GetCondimentCost();
        }

        public string GetDescription()
        {
            return _beverage.GetDescription() + ", " + GetCondimentDescription();
        }

        protected abstract string GetCondimentDescription();
        protected abstract double GetCondimentCost();
    }
}
