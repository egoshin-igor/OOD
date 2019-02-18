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
            Console.WriteLine( "-----------------------" );
        }
    }
}
