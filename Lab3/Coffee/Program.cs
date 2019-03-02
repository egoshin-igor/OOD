using System;
using Coffee.Beverage;
using Coffee.Beverage.Enum;
using Coffee.Condiment.Enum;

namespace Coffee
{
    class Program
    {
        static void Main( string[] args )
        {
            IBeverage coffee = new Capuccino( ServingQuantityType.Double )
                .AddChocolateCrumbs( mass: 3 )
                .AddCinnamon()
                .AddCream()
                .AddLiquor( LiquorType.Nutty );

            IBeverage tea = new Tea( TeaType.Yellow )
                .AddLemon( quantity: 2 )
                .AddSyrup( SyrupType.Maple )
                .AddCoconutFlakes( mass: 10 )
                .AddChocolateSlices( 1 );

            PrintBeverageInfo( coffee );
            PrintBeverageInfo( tea );
        }

        private static void PrintBeverageInfo( IBeverage beverage )
        {
            Console.WriteLine( $"Beverage description: {beverage.GetDescription()}. Price: {beverage.GetCost()}" );
        }
    }
}
