using System;
using Chart.Models.Harmonics;
using Chart.Models.Types;
using Chart.Tests.Utils;
using Xunit;

namespace Chart.Tests
{
    public class HarmonicTest
    {
        [Theory]
        [InlineData( 1.4 )]
        [InlineData( 2.8 )]
        [InlineData( -1.4 )]
        [InlineData( 0 )]
        public void GetValueByTime_CreateDefaultHarmonic_GetZeroByAnyTime( double t )
        {
            // Arrange
            var harmonic = new Harmonic();

            // Act
            double result = harmonic.GetValueByTime( t );

            // Assert
            Assert.True( DoubleUtils.EqualsDoubles( 0, result ) );
        }

        [Theory]
        [InlineData( 1.4, HarmonicType.Cos, 1, 1.2, 1.2, -1.03 )]
        [InlineData( 3, HarmonicType.Sin, 1, 0, 3.14, 0 )]
        [InlineData( 1, HarmonicType.Sin, 2, 3, 2.14, 0.959 )]
        public void GetValueByTime_DifferentTestData_GetExpectedValue(
            double amplitude,
            HarmonicType harmonicType,
            double frequency,
            double t,
            double phase,
            double expected )
        {
            // Arrange
            var harmonic = new Harmonic( amplitude, frequency, phase, harmonicType );

            // Act
            double result = harmonic.GetValueByTime( t );

            // Assert
            Assert.True( DoubleUtils.EqualsDoubles( expected, result ) );
        }
    }
}
