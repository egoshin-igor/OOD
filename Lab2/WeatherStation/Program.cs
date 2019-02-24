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
            wd.RegisterObserver( display, priority: 5 );
            var statsDisplay = new StatsDisplay();
            wd.RegisterObserver( statsDisplay, priority: 4 );

            wd.UpdateWeatherInfo( 3, 0.7, 760, 0, 22 );
            wd.UpdateWeatherInfo( 4, 0.8, 761, 90, 44 );

            wd.RemoveObserver( statsDisplay );
            wd.UpdateWeatherInfo( 10, 0.8, 761, 135, 66 );
            wd.UpdateWeatherInfo( -10, 0.8, 761, 180, 88 );
        }
    }
}
