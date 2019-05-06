using GumballMachine.GumbalMachineWithState.States;
using Moq;
using Xunit;
using GumballMachineWithStateContext = GumballMachine.GumbalMachineWithState.GumbalMachineContext;

namespace GumballMachine.Tests.GumbalMachineWithState
{
    public class SoldStateTest
    {
        private readonly Mock<GumballMachineWithStateContext> _gumballMachineWithStateMock;
        private readonly SoldState _soldState;

        public SoldStateTest()
        {
            _gumballMachineWithStateMock = new Mock<GumballMachineWithStateContext>();
            _soldState = new SoldState( _gumballMachineWithStateMock.Object );
        }

        [Fact]
        public void Dispense_MachineWithoutBall_MachineInSoldOutState()
        {
            //Arrange
            _gumballMachineWithStateMock.SetupProperty( c => c.BallsCount, 0u );
            _gumballMachineWithStateMock.Setup( c => c.ReleaseBall() ).Verifiable();
            _gumballMachineWithStateMock.Setup( c => c.SetSoldOutState() ).Verifiable();

            //Act
            _soldState.Dispense();

            //Assert
            _gumballMachineWithStateMock.Verify( c => c.ReleaseBall() );
            _gumballMachineWithStateMock.Verify( c => c.SetSoldOutState() );
        }

        [Fact]
        public void Dispense_MachineWithBall_MachineInNoQuarterState()
        {
            //Arrange
            _gumballMachineWithStateMock.SetupProperty( c => c.BallsCount, 1u );
            _gumballMachineWithStateMock.Setup( c => c.SetNoQuarterState() ).Verifiable();

            //Act
            _soldState.Dispense();

            //Assert
            _gumballMachineWithStateMock.Verify( c => c.SetNoQuarterState() );
        }
    }
}
