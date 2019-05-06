using GumballMachine.GumbalMachineWithState.States;
using Moq;
using Xunit;
using GumballMachineWithStateContext = GumballMachine.GumbalMachineWithState.GumbalMachineContext;

namespace GumballMachine.Tests.GumbalMachineWithState
{
    public class NoQuarterStateTest
    {
        private readonly Mock<GumballMachineWithStateContext> _gumballMachineWithStateMock;
        private readonly NoQuarterState _noQuarterState;

        public NoQuarterStateTest()
        {
            _gumballMachineWithStateMock = new Mock<GumballMachineWithStateContext>();
            _noQuarterState = new NoQuarterState( _gumballMachineWithStateMock.Object );
        }

        [Fact]
        public void InsertQuarter_MachineWithoutQuarter_MachineQuartersCountIncreased()
        {
            //Arrange
            _gumballMachineWithStateMock.SetupProperty( c => c.QuartersCount, 0u );
            _gumballMachineWithStateMock.Setup( c => c.SetHasQuarterState() ).Verifiable();

            //Act
            _noQuarterState.InsertQuarter();

            //Assert
            Assert.Equal( 1u, _gumballMachineWithStateMock.Object.QuartersCount );
            _gumballMachineWithStateMock.Verify( c => c.SetHasQuarterState() );
        }

        [Fact]
        public void AddBalls_MachineWithoutBalls_MachineWithAddedBalls()
        {
            //Arrange
            _gumballMachineWithStateMock.SetupProperty( c => c.BallsCount, 0u );

            //Act
            _noQuarterState.AddBalls( 3 );

            //Assert
            Assert.Equal( 3u, _gumballMachineWithStateMock.Object.BallsCount );
        }
    }
}
