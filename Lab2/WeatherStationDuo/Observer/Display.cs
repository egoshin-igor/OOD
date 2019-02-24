using System;
using WeatherStationDuo.Observable;

namespace WeatherStationDuo.Observer
{
    public class Display : IObserver<WeatherInfo>
    {
        private Observable.IObservable<WeatherInfo> _subjectInBuilding = null;
        private Observable.IObservable<WeatherInfo> _subjectOutBuilding = null;

        public Display( Observable<WeatherInfo> inSubject, Observable<WeatherInfo> outSubject )
        {
            _subjectInBuilding = inSubject;
            _subjectOutBuilding = outSubject;
            _subjectInBuilding.RegisterObserver( this );
            _subjectOutBuilding.RegisterObserver( this );
        }

        public virtual void Update( Observable.IObservable<WeatherInfo> subject, WeatherInfo data )
        {
            if ( subject == _subjectInBuilding )
            {
                Console.WriteLine( $"Location: in building" );
            }
            else if ( subject == _subjectOutBuilding )
            {
                Console.WriteLine( $"Location: out building" );
            }
            else
            {
                throw new ApplicationException( "Weather station is undefined" );
            }

            Console.WriteLine( $"Current temperature {data.Temperature}" );
            Console.WriteLine( $"Current humidity {data.Humidity}" );
            Console.WriteLine( $"Current pressure {data.Pressure}" );
            if ( data.WindInfo != null )
            {
                Console.WriteLine( $"Current wind direction {data.WindInfo.WindDirection}" );
                Console.WriteLine( $"Current wind speed {data.WindInfo.WindSpeed}" );
            }
            Console.WriteLine( "-----------------------" );
        }
    }
}
