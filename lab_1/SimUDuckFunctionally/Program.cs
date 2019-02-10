using System;
using SimUDuckFunctionally.Ducks;

namespace SimUDuckFunctionally
{
    class Program
    {
        static void Main( string[] args )
        {
            SimulateDuck( new MallardDuck() );
            SimulateDuck( new RedHeadDuck() );
            SimulateDuck( new RubberDuck() );
            SimulateDuck( new DecoyDuck() );

            Duck duck = new MallardDuck();
            duck.Fly();
            duck.SetFlight( () => { Console.WriteLine( "I fly on rocket!!!" ); } );
            duck.Fly();
        }

        private static void SimulateDuck( Duck duck )
        {
            if ( duck == null )
                return;

            Console.WriteLine( duck.GetType().Name );
            duck.Dance();
            duck.Display();
            duck.Fly();
            duck.Quack();
            duck.Swim();
            Console.WriteLine();
        }
    }
}
