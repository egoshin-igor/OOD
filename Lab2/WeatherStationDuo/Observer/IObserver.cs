using WeatherStationDuo.Observable;

namespace WeatherStationDuo.Observer
{
    public interface IObserver<T>
    {
        void Update( IObservable<T> subject, T data );
    }
}
