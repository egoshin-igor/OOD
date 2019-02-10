using System;

namespace SimUDuck.QuackBehaviour
{
    internal class Squeak : IQuackBehaviour
    {
        public void DoQuack()
        {
            Console.WriteLine( "Squeak" );
        }
    }
}
