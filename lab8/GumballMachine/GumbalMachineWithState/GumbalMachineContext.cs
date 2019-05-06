using System;
using GumballMachine.GumbalMachineWithState.States;

namespace GumballMachine.GumbalMachineWithState
{
    public class GumbalMachineContext : IGumbalMachineContext
    {
        public virtual uint BallsCount { get; set; }
        public virtual uint QuartersCount { get; set; } = 0;
        public uint MaxQuartersCount => 5;

        private readonly IState _soldState;
        private readonly IState _soldOutState;
        private readonly IState _noQuarterState;
        private readonly IState _hasQuarterState;

        private IState _currentState;

        protected GumbalMachineContext()
        {
        }

        public GumbalMachineContext( uint ballsCount )
        {
            _soldState = new SoldState( this );
            _soldOutState = new SoldOutState( this );
            _noQuarterState = new NoQuarterState( this );
            _hasQuarterState = new HasQuarterState( this );

            BallsCount = ballsCount;
            _currentState = BallsCount > 0 ? _noQuarterState : _soldOutState;
        }

        public void EjectQuarter()
        {
            _currentState.EjectQuarter();
        }

        public void InsertQuarter()
        {
            _currentState.InsertQuarter();
        }

        public virtual void ReleaseBall()
        {
            if ( BallsCount != 0 )
            {
                Console.WriteLine( "A gumball comes rolling out the slot..." );
                --BallsCount;
            }
        }

        public void TurnCrank()
        {
            _currentState.TurnCrank();
            _currentState.Dispense();
        }

        public virtual void SetHasQuarterState()
        {
            _currentState = _hasQuarterState;
        }

        public virtual void SetNoQuarterState()
        {
            _currentState = _noQuarterState;
        }

        public virtual void SetSoldOutState()
        {
            _currentState = _soldOutState;
        }

        public virtual void SetSoldState()
        {
            _currentState = _soldState;
        }

        public void AddBalls( uint ballsCount )
        {
            _currentState.AddBalls( ballsCount );
        }

        public override string ToString()
        {
            return _currentState.ToString();
        }
    }
}
