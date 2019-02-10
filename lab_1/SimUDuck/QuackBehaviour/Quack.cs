using System;

namespace SimUDuck.QuackBehaviour
{
    internal class Quack : IQuackBehaviour
    {
        public void DoQuack()
        {
            Console.WriteLine( "Quack" );
        }
    }
}
