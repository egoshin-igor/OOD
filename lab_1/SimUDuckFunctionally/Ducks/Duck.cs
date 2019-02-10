using System;

namespace SimUDuckFunctionally.Ducks
{
    internal class Duck
    {
        private Action _fly;
        private Action _quack;
        private Action _dance;

        public Duck( Action fly, Action quack, Action dance )
        {
            _fly = fly;
            _quack = quack;
            _dance = dance;
        }

        public void Fly()
        {
            _fly();
        }

        public void Quack()
        {
            _quack();
        }

        public void Dance()
        {
            _dance();
        }

        public void Swim()
        {
            Console.WriteLine( "Swim" );
        }

        public void SetFlight( Action fly )
        {
            _fly = fly;
        }

        public virtual void Display()
        {
            Console.WriteLine( "Dispaly duck" );
        }
    }
}
