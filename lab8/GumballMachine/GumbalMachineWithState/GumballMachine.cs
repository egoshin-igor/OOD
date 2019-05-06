using GumballMachine.GumbalMachineWithState.States;

namespace GumballMachine.GumbalMachineWithState
{
    public class GumballMachine : IGumbalMachine
    {
        private readonly IGumbalMachineContext _context;

        public uint BallsCount => _context.BallsCount;

        public uint QuartersCount => _context.QuartersCount;

        public uint MaxQuartersCount => _context.MaxQuartersCount;

        public GumballMachine( uint ballsCount )
        {
            _context = new GumbalMachineContext( ballsCount );
        }

        public void InsertQuarter()
        {
            _context.InsertQuarter();
        }

        public void EjectQuarter()
        {
            _context.EjectQuarter();
        }

        public void TurnCrank()
        {
            _context.TurnCrank();
        }

        public override string ToString()
        {
            return $"Mighty Gumball, Inc.\n" +
                $"Inventory: {BallsCount} gumball{( BallsCount != 1 ? "s" : "" )},{QuartersCount} quarter{( QuartersCount != 1 ? "s" : "" )}\n" +
                $"Machine is {_context.ToString()}";
        }

        public void AddBalls( uint ballsCount )
        {
            _context.AddBalls( ballsCount );
        }
    }
}
