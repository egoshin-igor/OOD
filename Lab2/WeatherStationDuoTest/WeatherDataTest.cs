using Moq;
using WeatherStationDuo.Observable;
using WeatherStationDuo.Observer;
using Xunit;

namespace WeatherStationDuoTest
{
    public class WeatherDataTest
    {
        [Fact]
        public void UpdateWeatherInfo_DisplayIsSubscriber_DisplayCalledTwoTimes()
        {
            // Arrange
            var displayCalledCount = 0;

            var wdIn = new WeatherData();
            var wdOut = new WeatherDataPro();

            var displayMock = new Mock<Display>( wdIn, wdOut );
            wdIn.RegisterObserver( displayMock.Object );
            wdOut.RegisterObserver( displayMock.Object );
            displayMock
                .Setup( d => d.Update( It.IsAny<IObservable<WeatherInfo>>(), It.IsAny<WeatherInfo>() ) )
                .Callback( () => ++displayCalledCount );

            // Act
            wdIn.UpdateWeatherInfo( 3, 0.7, 760 );
            wdOut.UpdateWeatherInfo( 4, 0.8, 761, 10, 10 );

            // Assert
            Assert.Equal( 2, displayCalledCount );
        }

        [Fact]
        public void UpdateWeatherInfo_StatsDisplayIsSubscriber_StatsDisplayCalledTwoTimes()
        {
            // Arrange
            var statsDisplayCalledCount = 0;

            var wdIn = new WeatherData();
            var wdOut = new WeatherDataPro();

            var statsDisplayMock = new Mock<StatsDisplay>( wdIn, wdOut );
            wdIn.RegisterObserver( statsDisplayMock.Object );
            wdOut.RegisterObserver( statsDisplayMock.Object );
            statsDisplayMock
                .Setup( d => d.Update( It.IsAny<IObservable<WeatherInfo>>(), It.IsAny<WeatherInfo>() ) )
                .Callback( () => ++statsDisplayCalledCount );

            // Act
            wdIn.UpdateWeatherInfo( 3, 0.7, 760 );
            wdOut.UpdateWeatherInfo( 4, 0.8, 761, 10, 10 );

            // Assert
            Assert.Equal( 2, statsDisplayCalledCount );
        }
    }
}
