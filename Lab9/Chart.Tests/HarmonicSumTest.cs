using Chart.Models.Harmonics;
using Chart.Models.Types;
using Chart.Tests.Utils;
using Xunit;

namespace Chart.Tests
{
    public class HarmonicSumTest
    {
        [Theory]
        [InlineData( 13.44 )]
        [InlineData( 31.1 )]
        [InlineData( 0 )]
        [InlineData( 1 )]
        public void GetValueByTime_EmptyHarmonics_ReturnZeroByAnyTime( double t )
        {
            // Assert
            var harmonicSum = new HarmonicsSum();

            // Act
            double result = harmonicSum.GetValueByTime( t );

            // Arrange
            Assert.True( DoubleUtils.EqualsDoubles( 0, result ) );
        }

        [Theory]
        [InlineData( 1, 2.11 )]
        [InlineData( 0.3, 0.53 )]
        [InlineData( 3, 2.63 )]
        [InlineData( 2.2, 1.66 )]
        public void GetValueByTime_DifferentHarmonics_ReturnedValueEqualsExpected( double t, double expected )
        {
            // Assert
            var harmonicSum = new HarmonicsSum();
            harmonicSum.Harmonics.Add( new Harmonic( 2.27, 0.22, 0.2, HarmonicType.Sin ) );
            harmonicSum.Harmonics.Add( new Harmonic( 1, 0, 1.14, HarmonicType.Sin ) );
            harmonicSum.Harmonics.Add( new Harmonic( 1, 3, 2, HarmonicType.Cos ) );

            // Act
            double result = harmonicSum.GetValueByTime( t );

            // Arrange
            Assert.True( DoubleUtils.EqualsDoubles( expected, result ) );
        }
    }
}
