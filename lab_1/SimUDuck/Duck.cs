using SimUDuck.DanceBehaviour;
using SimUDuck.FlyBehaviour;
using SimUDuck.QuackBehaviour;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimUDuck
{
    internal class Duck
    {
        private IFlyBehaviour _flyBehaviour;
        private IQuackBehaviour _quackBehaviour;
        private IDanceBehaviour _danceBehaviour;

        public Duck( IFlyBehaviour flyBehaviour, IQuackBehaviour quackBehaviour, IDanceBehaviour danceBehaviour )
        {
            _flyBehaviour = flyBehaviour;
            _quackBehaviour = quackBehaviour;
            _danceBehaviour = danceBehaviour;
        }

        public void Fly()
        {
            _flyBehaviour.Fly();
        }

        public void Quack()
        {
            _quackBehaviour.DoQuack();
        }

        public void Dance()
        {
            _danceBehaviour.Dance();
        }

        public void Swim()
        {
            Console.WriteLine( "Swim" );
        }

        public void SetFlightBehaviour( IFlyBehaviour flyBehaviour )
        {
            _flyBehaviour = flyBehaviour;
        }

        public virtual void Display()
        {
            Console.WriteLine( "Dispaly" );
        }
    }
}
