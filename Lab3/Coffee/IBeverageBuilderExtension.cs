using Coffee.Beverage;
using Coffee.Condiment;
using Coffee.Condiment.Enum;

namespace Coffee
{
    static class IBeverageBuilderExtension
    {
        /// <summary>
        /// Цена - 2 умноженное на mass
        /// </summary>
        public static IBeverage AddChocolateCrumbs( this IBeverage beverage, uint mass )
        {
            return new ChocolateCrumbs( beverage, mass );
        }

        /// <summary>
        /// Цена - 10 умноженное на quantity(максимум 5)
        /// </summary>
        public static IBeverage AddChocolateSlices( this IBeverage beverage, uint quantity )
        {
            return new ChocolateSlices( beverage, quantity );
        }

        /// <summary>
        /// Цена - 20
        /// </summary>
        public static IBeverage AddCinnamon( this IBeverage beverage )
        {
            return new Cinnamon( beverage );
        }

        /// <summary>
        /// Цена = mass
        /// </summary>
        public static IBeverage AddCoconutFlakes( this IBeverage beverage, uint mass )
        {
            return new CoconutFlakes( beverage, mass );
        }

        /// <summary>
        /// Цена - 25
        /// </summary>
        public static IBeverage AddCream( this IBeverage beverage )
        {
            return new Cream( beverage );
        }

        /// <summary>
        /// Цена - iceCubeType * quantity. IceCubeType.Dry = 10, IceCubeType.Water = 5
        /// </summary>
        public static IBeverage AddIceCubes( this IBeverage beverage, uint quantity, IceCubeType iceCubeType = IceCubeType.Water )
        {
            return new IceCubes( beverage, quantity, iceCubeType );
        }

        /// <summary>
        /// Цена - 10 * quantity
        /// </summary>
        public static IBeverage AddLemon( this IBeverage beverage, uint quantity = 1 )
        {
            return new Lemon( beverage, quantity );
        }

        /// <summary>
        /// Цена - 50
        /// </summary>
        public static IBeverage AddLiquor( this IBeverage beverage, LiquorType liquorType )
        {
            return new Liquor( beverage, liquorType );
        }

        /// <summary>
        /// Цена - 15
        /// </summary>
        public static IBeverage AddSyrup( this IBeverage beverage, SyrupType syrupType )
        {
            return new Syrup( beverage, syrupType );
        }
    }
}
