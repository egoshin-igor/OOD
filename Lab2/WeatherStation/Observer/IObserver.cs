using System;

namespace WeatherStation.Observer
{
    public interface IObserver<T>
    {
        void Update( T data );
    }
}
