using GumballMachine.GumbalMachineWithState.States;
using Moq;
using Xunit;
using GumballMachineWithStateContext = GumballMachine.GumbalMachineWithState.GumbalMachineContext;

namespace GumballMachine.Tests.GumbalMachineWithState
{
    public class SoldOutStateTest
    {
        private readonly Mock<GumballMachineWithStateContext> _gumballMachineWithStateMock;
        private readonly SoldOutState _soldOutState;

        public SoldOutStateTest()
        {
            _gumballMachineWithStateMock = new Mock<GumballMachineWithStateContext>();
            _soldOutState = new SoldOutState( _gumballMachineWithStateMock.Object );
        }

        [Fact]
        public void AddBalls_MachineWithoutBalls_MachineWithAddedBalls()
        {
            //Arrange
            _gumballMachineWithStateMock.SetupProperty( c => c.BallsCount, 0u );
            _gumballMachineWithStateMock.Setup( c => c.SetNoQuarterState() ).Verifiable();

            //Act
            _soldOutState.AddBalls( 3 );

            //Assert
            Assert.Equal( 3u, _gumballMachineWithStateMock.Object.BallsCount );
            _gumballMachineWithStateMock.Verify( c => c.SetNoQuarterState() );
        }
    }
}
