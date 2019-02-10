using SimUDuck.DanceBehaviour;
using SimUDuck.FlyBehaviour;
using SimUDuck.QuackBehaviour;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimUDuck
{
    internal class MallardDuck : Duck
    {
        public MallardDuck()
            : base( new FlyWithWings(), new Quack(), new Waltz() )
        {
        }

        public override void Display()
        {
            Console.WriteLine( "MallardDuck displaing" );
        }
    }
}
