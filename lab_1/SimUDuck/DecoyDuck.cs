using SimUDuck.DanceBehaviour;
using SimUDuck.FlyBehaviour;
using SimUDuck.QuackBehaviour;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimUDuck
{
    internal class DecoyDuck : Duck
    {
        public DecoyDuck()
            : base( new FlyNoWay(), new MuteQuack(), new DanceNoWay() )
        {
        }

        public override void Display()
        {
            Console.WriteLine( "DecoyDuck displaing" );
        }
    }
}
