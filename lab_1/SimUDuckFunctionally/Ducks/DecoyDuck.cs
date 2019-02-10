using System;
using SimUDuckFunctionally.Behaviours;

namespace SimUDuckFunctionally.Ducks
{
    internal class DecoyDuck : Duck
    {
        public DecoyDuck()
               : base( FlyBehaviour.FlyNoWay, QuackBehaviour.MuteQuack, DanceBehaviour.DanceNoWay )
        {
        }

        public override void Display()
        {
            Console.WriteLine( "DecoyDuck displaing" );
        }
    }
}
