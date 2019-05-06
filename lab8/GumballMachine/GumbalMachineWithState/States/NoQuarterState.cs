using System;

namespace GumballMachine.GumbalMachineWithState.States
{
    public class NoQuarterState : IState
    {
        private readonly IGumbalMachineContext _gumbalMachineContext;

        public NoQuarterState( IGumbalMachineContext gumbalMachineContext )
        {
            _gumbalMachineContext = gumbalMachineContext;
        }

        public void Dispense()
        {
            Console.WriteLine( "You need to pay first" );
        }

        public void EjectQuarter()
        {
            Console.WriteLine( "You haven't inserted a quarter" );
        }

        public void InsertQuarter()
        {
            Console.WriteLine( "You inserted a quarter" );
            ++_gumbalMachineContext.QuartersCount;
            _gumbalMachineContext.SetHasQuarterState();
        }

        public void TurnCrank()
        {
            Console.WriteLine( "You turned but there's no quarter" );
        }

        public void AddBalls( uint ballsCount )
        {
            Console.WriteLine( $"We are have added {ballsCount} gumball{( ballsCount != 1 ? "s" : "" )}" );
            _gumbalMachineContext.BallsCount += ballsCount;
        }

        public override string ToString()
        {
            return "waiting for quarter";
        }
    }
}
