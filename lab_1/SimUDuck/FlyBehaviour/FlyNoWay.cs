using System;

namespace SimUDuck.FlyBehaviour
{
    internal class FlyNoWay : IFlyBehaviour
    {
        public void Fly()
        {
            Console.WriteLine( "I cant fly" );
        }
    }
}
