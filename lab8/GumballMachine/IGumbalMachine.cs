namespace GumballMachine
{
    public interface IGumbalMachine
    {
        uint BallsCount { get; }
        uint QuartersCount { get; }
        uint MaxQuartersCount { get; }
        void InsertQuarter();
        void EjectQuarter();
        void TurnCrank();
        void AddBalls( uint ballsCount );
    }
}
