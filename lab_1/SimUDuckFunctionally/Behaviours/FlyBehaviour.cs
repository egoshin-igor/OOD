using System;

namespace SimUDuckFunctionally.Behaviours
{
    internal static class FlyBehaviour
    {
        public static Action FlyWithWings()
        {
            int flightsAmount = 1;
            void fly()
            {
                Console.WriteLine( $"I fly with wings. Flight number:{flightsAmount}" );
                ++flightsAmount;
            }
            return fly;
        }

        public static void FlyNoWay()
        {
            Console.WriteLine( $"I cant fly" );
        }
    }
}
