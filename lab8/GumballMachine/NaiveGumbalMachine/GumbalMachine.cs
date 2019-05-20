using System;
using GumballMachine.NaiveGumbalMachine.Enums;

namespace GumballMachine.NaiveGumbalMachine
{
    public class GumbalMachine : IGumbalMachine
    {
        private GumbalMachineState _currentState;

        public uint BallsCount { get; private set; }
        public uint QuartersCount { get; private set; } = 0;
        public uint MaxQuartersCount => 5;

        public GumbalMachine( uint ballsCount )
        {
            BallsCount = ballsCount;
            _currentState = BallsCount > 0 ? GumbalMachineState.NoQuarter : GumbalMachineState.SoldOut;
        }

        public void AddBalls( uint ballsCount )
        {
            switch ( _currentState )
            {
                case GumbalMachineState.SoldOut:
                    Console.WriteLine( $"We are have added {ballsCount} gumball{( ballsCount != 1 ? "s" : "" )}" );
                    BallsCount += ballsCount;
                    _currentState = GumbalMachineState.NoQuarter;
                    break;
                case GumbalMachineState.NoQuarter:
                case GumbalMachineState.HasQuarter:
                    Console.WriteLine( $"We are have added {ballsCount} gumball{( ballsCount != 1 ? "s" : "" )}" );
                    BallsCount += ballsCount;
                    break;
                case GumbalMachineState.Sold:
                    Console.WriteLine( "Please wait, we're giving you a gumball now" );
                    break;
            }
        }

        public void EjectQuarter()
        {
            switch ( _currentState )
            {
                case GumbalMachineState.SoldOut:
                    if ( QuartersCount != 0 )
                    {
                        Console.WriteLine( "Ejecting quarters" );
                        QuartersCount = 0;
                    }
                    else
                    {
                        Console.WriteLine( "Machine not has quarters" );
                    }
                    break;
                case GumbalMachineState.NoQuarter:
                    Console.WriteLine( "You haven't inserted a quarter" );
                    break;
                case GumbalMachineState.HasQuarter:
                    Console.WriteLine( "Quarters returned" );
                    QuartersCount = 0;
                    _currentState = GumbalMachineState.NoQuarter;
                    break;
                case GumbalMachineState.Sold:
                    Console.WriteLine( "Sorry you already turned the crank" );
                    break;
            }
        }

        public void InsertQuarter()
        {
            switch ( _currentState )
            {
                case GumbalMachineState.SoldOut:
                    Console.WriteLine( "You can't insert a quarter, the machine is sold out" );
                    break;
                case GumbalMachineState.NoQuarter:
                    Console.WriteLine( "You inserted a quarter" );
                    ++QuartersCount;
                    _currentState = GumbalMachineState.HasQuarter;
                    break;
                case GumbalMachineState.HasQuarter:
                    if ( QuartersCount < MaxQuartersCount )
                    {
                        Console.WriteLine( "Inserting quarter" );
                        ++QuartersCount;
                    }
                    else
                    {
                        Console.WriteLine( "Max quarters count in machine" );
                    }
                    break;
                case GumbalMachineState.Sold:
                    Console.WriteLine( "Please wait, we're already giving you a gumball" );
                    break;
            }
        }

        public void TurnCrank()
        {
            switch ( _currentState )
            {
                case GumbalMachineState.SoldOut:
                    Console.WriteLine( "You turned but there's no gumballs" );
                    break;
                case GumbalMachineState.NoQuarter:
                    Console.WriteLine( "You turned but there's no quarter" );
                    break;
                case GumbalMachineState.HasQuarter:
                    Console.WriteLine( "You turned..." );
                    --QuartersCount;
                    _currentState = GumbalMachineState.Sold;
                    Dispense();
                    break;
                case GumbalMachineState.Sold:
                    Console.WriteLine( "Turning twice doesn't get you another gumball" );
                    break;
            }
        }

        private void Dispense()
        {
            switch ( _currentState )
            {
                case GumbalMachineState.SoldOut:
                case GumbalMachineState.HasQuarter:
                    Console.WriteLine( "No gumball dispensed" );
                    break;
                case GumbalMachineState.NoQuarter:
                    Console.WriteLine( "You need to pay first" );
                    break;
                case GumbalMachineState.Sold:
                    Console.WriteLine( "A gumball comes rolling out the slot" );
                    --BallsCount;
                    if ( BallsCount == 0 )
                    {
                        Console.WriteLine( "Oops, out of gumbals" );
                        _currentState = GumbalMachineState.SoldOut;
                    }
                    else if ( QuartersCount == 0 )
                    {
                        _currentState = GumbalMachineState.NoQuarter;
                    }
                    else
                    {
                        _currentState = GumbalMachineState.HasQuarter;
                    }
                    break;
            }
        }

        public override string ToString()
        {
            return $"Mighty Gumball, Inc.\n" +
                $"Inventory: {BallsCount} gumball{( BallsCount != 1 ? "s" : "" )}, {QuartersCount} quarter{( QuartersCount != 1 ? "s" : "" )}\n" +
                $"Machine is {GetStateInfo()}";
        }

        private string GetStateInfo()
        {
            switch ( _currentState )
            {
                case GumbalMachineState.SoldOut:
                    return "sold out";
                case GumbalMachineState.NoQuarter:
                    return "waiting for quarter";
                case GumbalMachineState.HasQuarter:
                    return "waiting for turn of crank";
                case GumbalMachineState.Sold:
                    return "delivering a gumball";
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
