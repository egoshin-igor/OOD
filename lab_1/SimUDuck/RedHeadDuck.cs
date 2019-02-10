using SimUDuck.DanceBehaviour;
using SimUDuck.FlyBehaviour;
using SimUDuck.QuackBehaviour;
using System;

namespace SimUDuck
{
    internal class RedHeadDuck : Duck
    {
        public RedHeadDuck()
            : base( new FlyWithWings(), new Quack(), new Manuette() )
        {
        }

        public override void Display()
        {
            Console.WriteLine( "RedHeadDuck displaing" );
        }
    }
}
