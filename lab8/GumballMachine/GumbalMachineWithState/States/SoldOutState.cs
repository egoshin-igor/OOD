using System;

namespace GumballMachine.GumbalMachineWithState.States
{
    public class SoldOutState : IState
    {
        private readonly IGumbalMachineContext _gumbalMachineContext;

        public SoldOutState( IGumbalMachineContext gumbalMachineContext )
        {
            _gumbalMachineContext = gumbalMachineContext;
        }

        public void Dispense()
        {
            Console.WriteLine( "No gumball dispensed" );
        }

        public void EjectQuarter()
        {
            if ( _gumbalMachineContext.QuartersCount != 0 )
            {
                Console.WriteLine( "Ejecting quarters" );
                _gumbalMachineContext.QuartersCount = 0;
            }
            else
            {
                Console.WriteLine( "Machine not has quarters" );
            }
        }

        public void InsertQuarter()
        {
            Console.WriteLine( "You can't insert a quarter, the machine is sold out" );
        }

        public void TurnCrank()
        {
            Console.WriteLine( "You turned but there's no gumballs" );
        }

        public void AddBalls( uint ballsCount )
        {
            Console.WriteLine( $"We are have added {ballsCount} gumball{( ballsCount != 1 ? "s" : "" )}" );
            _gumbalMachineContext.BallsCount += ballsCount;
            _gumbalMachineContext.SetNoQuarterState();
        }

        public override string ToString()
        {
            return "sold out";
        }
    }
}
