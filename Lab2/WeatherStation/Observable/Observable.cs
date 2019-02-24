using System.Collections.Generic;
using System.Linq;
using WeatherStation.Observer;

namespace WeatherStation.Observable
{
    public abstract class Observable<T> : IObservable<T>
    {
        private readonly SortedSet<PriorityObserver> _observers = new SortedSet<PriorityObserver>( new PriorityObserverComparer() );

        public void RegisterObserver( IObserver<T> observer, int priority = 0 )
        {
            RemoveObserver( observer );

            _observers.Add( new PriorityObserver( observer, priority ) );
        }

        public void NotifyObservers()
        {
            var copiedObservers = new List<PriorityObserver>( _observers );
            T data = GetChangedData();

            foreach ( PriorityObserver observer in copiedObservers )
            {
                observer.Observer.Update( data );
            }
        }

        public void RemoveObserver( IObserver<T> observer )
        {
            _observers.RemoveWhere( o => o.Observer == observer );
        }

        protected abstract T GetChangedData();

        private class PriorityObserver
        {
            public IObserver<T> Observer { get; protected set; }
            public int Priority { get; protected set; }

            public PriorityObserver( IObserver<T> observer, int priority )
            {
                Observer = observer;
                Priority = priority;
            }
        }

        private class PriorityObserverComparer : IComparer<PriorityObserver>
        {
            public int Compare( PriorityObserver first, PriorityObserver second )
            {
                int priorityDifference = second.Priority - first.Priority;

                if ( ReferenceEquals( first.Observer, second.Observer ) )
                {
                    return 0;
                }
                else if ( priorityDifference == 0 )
                {
                    return 1;
                }

                return priorityDifference;
            }
        }
    }
}
