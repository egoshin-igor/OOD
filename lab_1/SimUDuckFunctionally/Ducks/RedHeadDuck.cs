using System;
using SimUDuckFunctionally.Behaviours;

namespace SimUDuckFunctionally.Ducks
{
    internal class RedHeadDuck : Duck
    {
        public RedHeadDuck()
            : base( FlyBehaviour.FlyWithWings, QuackBehaviour.Quack, DanceBehaviour.Manuette )
        {
        }

        public override void Display()
        {
            Console.WriteLine( "RedHeadDuck displaing" );
        }
    }
}
