using SimUDuck.DanceBehaviour;
using SimUDuck.FlyBehaviour;
using SimUDuck.QuackBehaviour;
using System;

namespace SimUDuck
{
    internal class RubberDuck : Duck
    {
        public RubberDuck()
            : base( new FlyNoWay(), new Squeak(), new DanceNoWay() )
        {
        }

        public override void Display()
        {
            Console.WriteLine( "RubberDuck displaing" );
        }
    }
}
