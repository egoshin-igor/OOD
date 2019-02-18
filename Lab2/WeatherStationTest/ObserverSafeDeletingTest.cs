using WeatherStation.Observable;
using WeatherStation.Observer;
using Xunit;

namespace WeatherStationTest
{
    public class ObserverSafeDeletingTest
    {
        [Fact]
        public void UpdateWeatherInfo_ObserverUnsubscribeFromSubjectDuringIt_CorrectUpdate()
        {
            // arrange
            var wd = new WeatherData();
            var display = new Display();
            var testObserver = new TestObserver( wd );
            wd.RegisterObserver( display );
            wd.RegisterObserver( testObserver );
            var isWeatherInfoCorrectlyUpdated = true;

            // act
            try
            {
                wd.UpdateWeatherInfo( new WeatherInfo( 1, 1, 1 ) );
            }
            catch
            {
                isWeatherInfoCorrectlyUpdated = false;
            }

            // assert
            Assert.True( isWeatherInfoCorrectlyUpdated );
        }



        private class TestObserver : IObserver<WeatherInfo>
        {
            IObservable<WeatherInfo> _subject;

            public TestObserver( IObservable<WeatherInfo> subject )
            {
                _subject = subject;
            }

            public void Update( WeatherInfo data )
            {
                _subject.RemoveObserver( this );
            }
        }
    }
}
