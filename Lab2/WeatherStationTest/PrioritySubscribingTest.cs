using System;
using System.Threading;
using Moq;
using WeatherStation.Observable;
using WeatherStation.Observer;
using Xunit;

using ICustomObserver = WeatherStation.Observer.IObserver<WeatherStation.Observable.WeatherInfo>;

namespace WeatherStationTest
{
    public class PrioritySubscribingTest
    {
        [Theory]
        [InlineData( 1, 1, true )]
        [InlineData( 1, 2, false )]
        [InlineData( 2, 1, true )]
        public void UpdateWeatherInfo_UpdateByPriority(
            int firstObserverPriority,
            int secondObserverPriority,
            bool isFirstObserverHasHigherPriority )
        {
            // arrange
            var wd = new WeatherData();
            var firstObserver = new Mock<ICustomObserver>();
            var secondObserver = new Mock<ICustomObserver>();

            DateTime? UpdatedTimeByFirstObserver = null;
            DateTime? UpdatedTimeBySecondObserver = null;
            firstObserver.Setup( o => o.Update( It.IsAny<WeatherInfo>() ) ).Callback( () => UpdatedTimeByFirstObserver = DateTime.Now );
            secondObserver.Setup( o => o.Update( It.IsAny<WeatherInfo>() ) ).Callback( () => UpdatedTimeBySecondObserver = DateTime.Now );

            wd.RegisterObserver( firstObserver.Object, firstObserverPriority );
            wd.RegisterObserver( secondObserver.Object, secondObserverPriority );

            // act
            wd.UpdateWeatherInfo( 1, 1, 1, 1, 1 );

            // assert
            Assert.Equal( isFirstObserverHasHigherPriority, UpdatedTimeByFirstObserver < UpdatedTimeBySecondObserver );
        }
    }
}
