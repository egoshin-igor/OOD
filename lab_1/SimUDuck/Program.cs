using SimUDuck.FlyBehaviour;
using System;

namespace SimUDuck
{
    class Program
    {
        static void Main( string[] args )
        {
            Duck duck = new MallardDuck();
            duck.Dance();
            duck = new RedHeadDuck();
            duck.Dance();
            duck = new RubberDuck();
            duck.Dance();
            duck = new DecoyDuck();
            duck.Dance();

            duck = new MallardDuck();
            duck.Fly();
            duck.Fly();
            duck.SetFlightBehaviour( new FlyWithWings() );
            duck.Fly();
        }
    }
}
