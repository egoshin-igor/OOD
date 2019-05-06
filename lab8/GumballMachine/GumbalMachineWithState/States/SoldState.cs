using System;

namespace GumballMachine.GumbalMachineWithState.States
{
    public class SoldState : IState
    {
        private readonly IGumbalMachineContext _gumbalMachineContext;

        public SoldState( IGumbalMachineContext gumbalMachineContext )
        {
            _gumbalMachineContext = gumbalMachineContext;
        }

        public void Dispense()
        {
            _gumbalMachineContext.ReleaseBall();
            if ( _gumbalMachineContext.BallsCount == 0 )
            {
                Console.WriteLine( "Oops, out of gumbals" );
                _gumbalMachineContext.SetSoldOutState();
            }
            else if ( _gumbalMachineContext.QuartersCount == 0 )
            {
                _gumbalMachineContext.SetNoQuarterState();
            }
            else
            {
                _gumbalMachineContext.SetHasQuarterState();
            }
        }

        public void EjectQuarter()
        {
            Console.WriteLine( "Sorry you already turned the crank" );
        }

        public void InsertQuarter()
        {
            Console.WriteLine( "Please wait, we're already giving you a gumball" );
        }

        public void TurnCrank()
        {
            Console.WriteLine( "Turning twice doesn't get you another gumball" );
        }

        public void AddBalls( uint ballsCount )
        {
            Console.WriteLine( "Please wait, we're giving you a gumball now" );
        }

        public override string ToString()
        {
            return "delivering a gumball";
        }
    }
}
