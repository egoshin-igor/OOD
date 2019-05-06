using System;

namespace GumballMachine.GumbalMachineWithState.States
{
    public class HasQuarterState : IState
    {
        private readonly IGumbalMachineContext _gumbalMachineContext;

        public HasQuarterState( IGumbalMachineContext gumbalMachineContext )
        {
            _gumbalMachineContext = gumbalMachineContext;
        }

        public void Dispense()
        {
            Console.WriteLine( "No gumball dispensed" );
        }

        public void EjectQuarter()
        {
            Console.WriteLine( "Quarters returned" );
            _gumbalMachineContext.QuartersCount = 0;
            _gumbalMachineContext.SetNoQuarterState();
        }

        public void InsertQuarter()
        {
            if ( _gumbalMachineContext.QuartersCount < _gumbalMachineContext.MaxQuartersCount )
            {
                Console.WriteLine( "Inserting quarter" );
                ++_gumbalMachineContext.QuartersCount;
            }
            else
            {
                Console.WriteLine( "Max quarters count in machine" );
            }
        }

        public void TurnCrank()
        {
            Console.WriteLine( "You turned..." );
            --_gumbalMachineContext.QuartersCount;
            _gumbalMachineContext.SetSoldState();
        }

        public void AddBalls( uint ballsCount )
        {
            Console.WriteLine( $"We are have added {ballsCount} gumball{( ballsCount != 1 ? "s" : "" )}" );
            _gumbalMachineContext.BallsCount += ballsCount;
        }

        public override string ToString()
        {
            return "waiting for turn of crank";
        }
    }
}
