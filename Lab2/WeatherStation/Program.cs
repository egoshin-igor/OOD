using WeatherStation.Observer;
using WeatherStation.Observable;

namespace WeatherStation
{
    class Program
    {
        static void Main( string[] args )
        {
            var wd = new WeatherData();

            var display = new Display();
            wd.RegisterObserver( display, priority: 3 );
            var statsDisplay = new StatsDisplay();
            wd.RegisterObserver( statsDisplay, priority: 4 );

            wd.UpdateWeatherInfo( new WeatherInfo( 3, 0.7, 760 ) );
            wd.UpdateWeatherInfo( new WeatherInfo( 4, 0.8, 761 ) );

            wd.RemoveObserver( statsDisplay );
            wd.UpdateWeatherInfo( new WeatherInfo( 10, 0.8, 761 ) );
            wd.UpdateWeatherInfo( new WeatherInfo( -10, 0.8, 761 ) );
        }
    }
}
