namespace GumballMachine.GumbalMachineWithState
{
    public interface IGumbalMachineContext : IGumbalMachine
    {
        new uint BallsCount { get; set; }
        new uint QuartersCount { get; set; }
        void ReleaseBall();
        void SetSoldOutState();
        void SetNoQuarterState();
        void SetSoldState();
        void SetHasQuarterState();
    }
}
