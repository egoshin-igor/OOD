using System;
using WeatherStationDuo.Observable;
using WeatherStationDuo.Observer;

namespace WeatherStationDuo
{
    class Program
    {
        static void Main( string[] args )
        {
            var wdIn = new WeatherData( WeatherStationLocation.In );
            var wdOut = new WeatherData( WeatherStationLocation.Out );

            var display = new Display();
            wdIn.RegisterObserver( display, priority: 3 );

            var statsDisplay = new StatsDisplay();
            wdIn.RegisterObserver( statsDisplay, priority: 4 );
            wdOut.RegisterObserver( statsDisplay, priority: 4 );

            wdIn.UpdateWeatherInfo( new WeatherInfo( 3, 0.7, 760 ) );
            wdOut.UpdateWeatherInfo( new WeatherInfo( 4, 0.8, 761 ) );

            wdIn.RemoveObserver( statsDisplay );
            wdIn.UpdateWeatherInfo( new WeatherInfo( 10, 0.8, 761 ) );
            wdOut.UpdateWeatherInfo( new WeatherInfo( -10, 0.8, 761 ) );
        }
    }
}
