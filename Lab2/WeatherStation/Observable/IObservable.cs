﻿using WeatherStation.Observer;

namespace WeatherStation.Observable
{
    public interface IObservable<T>
    {
        void RegisterObserver( IObserver<T> observer, int priority = 0 );
        void NotifyObservers();
        void RemoveObserver( IObserver<T> observer );
    }
}
