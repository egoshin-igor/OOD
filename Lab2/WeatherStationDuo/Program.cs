using WeatherStationDuo.Observable;
using WeatherStationDuo.Observer;

namespace WeatherStationDuo
{
    class Program
    {
        static void Main( string[] args )
        {
            var wdIn = new WeatherData();
            var wdOut = new WeatherDataPro();

            var display = new Display( wdIn, wdOut );
            var statsDisplay = new StatsDisplay( wdIn, wdOut );

            wdIn.UpdateWeatherInfo( 3, 0.7, 760 );
            wdIn.UpdateWeatherInfo( 4, 0.8, 761 );
            wdOut.UpdateWeatherInfo( 4, 0.8, 761, 90, 11 );
            wdOut.UpdateWeatherInfo( 4, 0.8, 761, 270, 10 );

            wdIn.RemoveObserver( statsDisplay );
            wdOut.RemoveObserver( statsDisplay );
            wdIn.UpdateWeatherInfo( 10, 0.8, 761 );
        }
    }
}
