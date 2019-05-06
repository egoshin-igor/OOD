using GumballMachine.GumbalMachineWithState.States;
using Moq;
using Xunit;
using GumballMachineWithStateContext = GumballMachine.GumbalMachineWithState.GumbalMachineContext;

namespace GumballMachine.Tests.GumbalMachineWithState
{
    public class HasQuarterStateTest
    {
        private readonly Mock<GumballMachineWithStateContext> _gumballMachineWithStateMock;
        private readonly HasQuarterState _hasQuarterState;

        public HasQuarterStateTest()
        {
            _gumballMachineWithStateMock = new Mock<GumballMachineWithStateContext>();
            _hasQuarterState = new HasQuarterState( _gumballMachineWithStateMock.Object );
        }

        [Fact]
        public void EjectQuarter_OneQuarterInMachine_MachineWithoutQuarter()
        {
            //Arrange
            _gumballMachineWithStateMock.SetupProperty( c => c.QuartersCount, 1u );
            _gumballMachineWithStateMock.Setup( c => c.SetNoQuarterState() ).Verifiable();

            //Act
            _hasQuarterState.EjectQuarter();

            //Assert
            Assert.Equal( 0u, _gumballMachineWithStateMock.Object.QuartersCount );
            _gumballMachineWithStateMock.Verify( c => c.SetNoQuarterState() );
        }

        [Fact]
        public void TurnCrank_OneQuarterInMachine_MachineWithoutQuarter()
        {
            //Arrange
            _gumballMachineWithStateMock.SetupProperty( c => c.QuartersCount, 1u );
            _gumballMachineWithStateMock.Setup( c => c.SetSoldState() ).Verifiable();

            //Act
            _hasQuarterState.TurnCrank();

            //Assert
            Assert.Equal( 0u, _gumballMachineWithStateMock.Object.QuartersCount );
            _gumballMachineWithStateMock.Verify( c => c.SetSoldState() );
        }

        [Fact]
        public void AddBalls_MachineWithoutBalls_MachineWithAddedBalls()
        {
            //Arrange
            _gumballMachineWithStateMock.SetupProperty( c => c.BallsCount, 0u );

            //Act
            _hasQuarterState.AddBalls( 3 );

            //Assert
            Assert.Equal( 3u, _gumballMachineWithStateMock.Object.BallsCount );
        }
    }
}
