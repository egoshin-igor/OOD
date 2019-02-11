using System;
using SimUDuckFunctionally.Behaviours;

namespace SimUDuckFunctionally.Ducks
{
    internal class ModelDuck : Duck
    {
        public ModelDuck()
               : base( FlyBehaviour.FlyNoWay, QuackBehaviour.Quack, DanceBehaviour.DanceNoWay )
        {
        }

        public override void Display()
        {
            Console.WriteLine( "ModelDuck displaing" );
        }
    }
}
