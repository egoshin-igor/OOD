namespace GumballMachine.GumbalMachineWithState.States
{
    public interface IState
    {
        void InsertQuarter();
        void EjectQuarter();
        void TurnCrank();
        void Dispense();
        void AddBalls( uint ballsCount );
    }
}
