using System;
using SimUDuckFunctionally.Behaviours;

namespace SimUDuckFunctionally.Ducks
{
    internal class RubberDuck : Duck
    {
        public RubberDuck()
               : base( FlyBehaviour.FlyNoWay, QuackBehaviour.Squeak, DanceBehaviour.DanceNoWay )
        {
        }

        public override void Display()
        {
            Console.WriteLine( "RubberDuck displaing" );
        }
    }
}
