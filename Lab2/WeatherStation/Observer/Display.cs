using System;
using WeatherStation.Observable;

namespace WeatherStation.Observer
{
    public class Display : IObserver<WeatherInfo>
    {
        public void Update( WeatherInfo data )
        {
            Console.WriteLine( $"Current temperature {data.Temperature}" );
            Console.WriteLine( $"Current humidity {data.Humidity}" );
            Console.WriteLine( $"Current pressure {data.Pressure}" );
            Console.WriteLine( $"Current wind direction {data.WindInfo.WindDirection}" );
            Console.WriteLine( $"Current wind speed {data.WindInfo.WindSpeed}" );
            Console.WriteLine( "-----------------------" );
        }
    }
}
