using System;

namespace SimUDuck.FlyBehaviour
{
    internal class FlyWithWings : IFlyBehaviour
    {
        private int _flightsAmount = 0;
        public void Fly()
        {
            _flightsAmount++;
            Console.WriteLine( $"I fly with wings. Flight number:{_flightsAmount}" );
        }
    }
}
