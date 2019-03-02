using System;
using System.Collections.Generic;
using System.Text;
using Coffee.Beverage;

namespace Coffee.Condiment
{
    class Cream : CondimentDecorator
    {
        public Cream( IBeverage beverage )
            : base( beverage )
        {
        }

        protected override double GetCondimentCost()
        {
            return 25;
        }

        protected override string GetCondimentDescription()
        {
            return "Cream";
        }
    }
}
