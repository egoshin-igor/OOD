using Xunit;
using Xunit.Abstractions;
using GumballMachineWithState = GumballMachine.GumbalMachineWithState.GumballMachine;
using NaiveGumbalMachineWithState = GumballMachine.NaiveGumbalMachine.GumbalMachine;

namespace GumballMachine.Tests.GumbalMachineWithState
{
    public abstract class GumbalMachineTest
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private IGumbalMachine _gumballMachine;

        public GumbalMachineTest( IGumbalMachine gumbalMachine, ITestOutputHelper testOutputHelper )
        {
            _gumballMachine = gumbalMachine;
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void IsDefaultGumbalMachineStateOnBegining()
        {
            Assert.Equal( 0u, _gumballMachine.BallsCount );
            Assert.Equal( 0u, _gumballMachine.QuartersCount );
        }

        [Fact]
        public void AddBalls_MachineWithoutGumbles_MachineWithAddedGumbles()
        {
            // Arrange
            _testOutputHelper.WriteLine( _gumballMachine.ToString() + "\n-----------" );

            // Act
            _gumballMachine.AddBalls( 5 );

            // Assert
            Assert.Equal( 5u, _gumballMachine.BallsCount );
            _testOutputHelper.WriteLine( _gumballMachine.ToString() + "\n-----------" );
        }

        [Fact]
        public void InsertQuarter_MachineWithGumbals_QuartersCountIncreased()
        {
            // Arrange
            _gumballMachine.AddBalls( 5 );
            _testOutputHelper.WriteLine( _gumballMachine.ToString() + "\n-----------" );

            // Act
            _gumballMachine.InsertQuarter();

            // Assert
            Assert.Equal( 1u, _gumballMachine.QuartersCount );
            _testOutputHelper.WriteLine( _gumballMachine.ToString() + "\n-----------" );
        }

        [Fact]
        public void InsertQuarter_MachineWithoutGumbals_QuartersCountNotChanged()
        {
            // Arrange
            _testOutputHelper.WriteLine( _gumballMachine.ToString() + "\n-----------" );

            // Act
            _gumballMachine.InsertQuarter();

            // Assert
            Assert.Equal( 0u, _gumballMachine.QuartersCount );
            _testOutputHelper.WriteLine( _gumballMachine.ToString() + "\n-----------" );
        }

        [Fact]
        public void InsertQuarter_InsertMoreThanMax_QuartersCountEqualsMax()
        {
            // Arrange
            _testOutputHelper.WriteLine( _gumballMachine.ToString() + "\n-----------" );
            _gumballMachine.AddBalls( _gumballMachine.MaxQuartersCount + 1 );

            // Act
            for ( int i = 0; i <= _gumballMachine.MaxQuartersCount; i++ )
            {
                _gumballMachine.InsertQuarter();
            }

            // Assert
            Assert.Equal( _gumballMachine.MaxQuartersCount, _gumballMachine.QuartersCount );
            _testOutputHelper.WriteLine( _gumballMachine.ToString() + "\n-----------" );
        }

        [Fact]
        public void TurnCrank_MachineWithoutQuarterAndBalls_NothingHapenned()
        {
            // Arrange
            _testOutputHelper.WriteLine( _gumballMachine.ToString() + "\n-----------" );

            // Act
            _gumballMachine.TurnCrank();

            // Assert
            Assert.Equal( 0u, _gumballMachine.QuartersCount );
            Assert.Equal( 0u, _gumballMachine.BallsCount );
            _testOutputHelper.WriteLine( _gumballMachine.ToString() + "\n-----------" );
        }

        [Fact]
        public void TurnCrank_MachineWithQuarter_DecreaseGumblesAndQuarterCount()
        {
            // Arrange
            _gumballMachine.AddBalls( 1 );
            _gumballMachine.InsertQuarter();
            _testOutputHelper.WriteLine( _gumballMachine.ToString() + "\n-----------" );

            // Act
            _gumballMachine.TurnCrank();

            // Assert
            Assert.Equal( 0u, _gumballMachine.QuartersCount );
            Assert.Equal( 0u, _gumballMachine.BallsCount );
            _testOutputHelper.WriteLine( _gumballMachine.ToString() + "\n-----------" );
        }

        [Fact]
        public void TurnCrank_MachineWithQuarters_DecreaseQuartersCountWhileGumblesExist()
        {
            // Arrange
            _gumballMachine.AddBalls( 2 );
            _gumballMachine.InsertQuarter();
            _gumballMachine.InsertQuarter();
            _gumballMachine.InsertQuarter();
            _testOutputHelper.WriteLine( _gumballMachine.ToString() + "\n-----------" );

            // Act
            _gumballMachine.TurnCrank();
            _gumballMachine.TurnCrank();
            _gumballMachine.TurnCrank();

            // Assert
            Assert.Equal( 1u, _gumballMachine.QuartersCount );
            Assert.Equal( 0u, _gumballMachine.BallsCount );
            _testOutputHelper.WriteLine( _gumballMachine.ToString() + "\n-----------" );
        }

        [Fact]
        public void EjectQuarter_MachineWithoutQuarter_NothingHapenned()
        {
            // Arrange
            _testOutputHelper.WriteLine( _gumballMachine.ToString() + "\n-----------" );

            // Act
            _gumballMachine.EjectQuarter();

            // Assert
            Assert.Equal( 0u, _gumballMachine.QuartersCount );
            Assert.Equal( 0u, _gumballMachine.BallsCount );
            _testOutputHelper.WriteLine( _gumballMachine.ToString() + "\n-----------" );
        }

        [Fact]
        public void EjectQuarter_MachineWithQuarter_DecreaseQuartersCount()
        {
            // Arrange
            _gumballMachine.AddBalls( 2 );
            _gumballMachine.InsertQuarter();
            _testOutputHelper.WriteLine( _gumballMachine.ToString() + "\n-----------" );

            // Act
            _gumballMachine.EjectQuarter();

            // Assert
            Assert.Equal( 0u, _gumballMachine.QuartersCount );
            _testOutputHelper.WriteLine( _gumballMachine.ToString() + "\n-----------" );
        }

        [Fact]
        public void EjectQuarter_MachineWithoutGumbles_ReturnAllQuarters()
        {
            // Arrange
            _gumballMachine.AddBalls( 1 );
            _gumballMachine.InsertQuarter();
            _gumballMachine.InsertQuarter();
            _gumballMachine.InsertQuarter();
            _gumballMachine.TurnCrank();
            _testOutputHelper.WriteLine( _gumballMachine.ToString() + "\n-----------" );

            // Act
            Assert.Equal( 2u, _gumballMachine.QuartersCount );
            _gumballMachine.EjectQuarter();

            // Assert
            Assert.Equal( 0u, _gumballMachine.QuartersCount );
            Assert.Equal( 0u, _gumballMachine.BallsCount );
            _testOutputHelper.WriteLine( _gumballMachine.ToString() + "\n-----------" );
        }
    }

    public class GumbalMachineWithStateTest : GumbalMachineTest
    {
        public GumbalMachineWithStateTest( ITestOutputHelper testOutputHelper )
            : base( new GumballMachineWithState( ballsCount: 0 ), testOutputHelper )
        {
        }
    }

    public class NaiveGumbalMachineTest : GumbalMachineTest
    {
        public NaiveGumbalMachineTest( ITestOutputHelper testOutputHelper )
           : base( new NaiveGumbalMachineWithState( ballsCount: 0 ), testOutputHelper )
        {
        }
    }
}
