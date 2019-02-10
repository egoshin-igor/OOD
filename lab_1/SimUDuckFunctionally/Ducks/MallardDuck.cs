using System;
using SimUDuckFunctionally.Behaviours;

namespace SimUDuckFunctionally.Ducks
{
    internal class MallardDuck : Duck
    {
        public MallardDuck()
            : base( FlyBehaviour.FlyWithWings, QuackBehaviour.Quack, DanceBehaviour.Waltz )
        {
        }

        public override void Display()
        {
            Console.WriteLine( "MallardDuck displaing" );
        }
    }
}
