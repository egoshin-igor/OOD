using System;

namespace SimUDuck.DanceBehaviour
{
    class DanceNoWay : IDanceBehaviour
    {
        public void Dance()
        {
            Console.WriteLine( "I cant dance" );
        }
    }
}
