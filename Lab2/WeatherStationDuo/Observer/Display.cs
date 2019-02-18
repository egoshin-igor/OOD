using System;
using WeatherStationDuo.Observable;

namespace WeatherStationDuo.Observer
{
    public class Display : IObserver<WeatherInfo>
    {
        public void Update( Observable.IObservable<WeatherInfo> subject, WeatherInfo data )
        {
            var wd = subject as WeatherData;
            if ( wd != null )
            {
                if ( wd.Location == WeatherStationLocation.In )
                {
                    Console.WriteLine( $"Location: in building" );
                }
                else if ( wd.Location == WeatherStationLocation.Out )
                {
                    Console.WriteLine( $"Location: out building" );
                }
            }

            Console.WriteLine( $"Current temperature {data.Temperature}" );
            Console.WriteLine( $"Current humidity {data.Humidity}" );
            Console.WriteLine( $"Current pressure {data.Pressure}" );
            Console.WriteLine( "-----------------------" );
        }
    }
}
