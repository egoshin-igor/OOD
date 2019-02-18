using System;
using WeatherStationDuo.Observable;

namespace WeatherStationDuo.Observer
{
    public class StatsDisplay : IObserver<WeatherInfo>
    {
        private MeasurementStatisticInfoDuo _temperatureStatisticIn = new MeasurementStatisticInfoDuo( "Temperature" );
        private MeasurementStatisticInfoDuo _humidityStatisticIn = new MeasurementStatisticInfoDuo( "Humidity" );
        private MeasurementStatisticInfoDuo _pressureStatisticIn = new MeasurementStatisticInfoDuo( "Pressure" );

        public void Update( Observable.IObservable<WeatherInfo> subject, WeatherInfo data )
        {
            var wd = subject as WeatherData;
            if ( wd == null )
            {
                throw new ApplicationException( "Stats display can work only with weather station" );
            }

            _temperatureStatisticIn.UpdateStatistic( wd.Location, data.Temperature );
            _humidityStatisticIn.UpdateStatistic( wd.Location, data.Humidity );
            _pressureStatisticIn.UpdateStatistic( wd.Location, data.Pressure );
            Console.WriteLine( "-----------------------" );
        }

        private class MeasurementStatisticInfoDuo
        {
            private MeasurementStatisticInfo _inBuilding;
            private MeasurementStatisticInfo _outBuilding;

            public MeasurementStatisticInfoDuo( string name )
            {
                _inBuilding = new MeasurementStatisticInfo( name );
                _outBuilding = new MeasurementStatisticInfo( name );
            }

            public void UpdateStatistic( WeatherStationLocation location, double measurement )
            {

                if ( location == WeatherStationLocation.In )
                {
                    Console.WriteLine( "Location: in building" );
                    _inBuilding.UpdateStatistic( measurement );
                }
                else
                {
                    Console.WriteLine( "Location: out building" );
                    _outBuilding.UpdateStatistic( measurement );
                }
            }
        }

        private class MeasurementStatisticInfo
        {
            private string _name;
            private double _maxMeasurement = double.NegativeInfinity;
            private double _minMeasurement = double.PositiveInfinity;
            private double _measurementsSum = 0;
            private uint _updatesCount = 0;

            public MeasurementStatisticInfo( string name )
            {
                _name = name;
            }

            public void UpdateStatistic( double measurement )
            {
                if ( _minMeasurement > measurement )
                {
                    _minMeasurement = measurement;
                }
                if ( _maxMeasurement < measurement )
                {
                    _maxMeasurement = measurement;
                }

                _measurementsSum += measurement;
                ++_updatesCount;

                Console.WriteLine( $"Max {_name} {_maxMeasurement}" );
                Console.WriteLine( $"Min {_name} {_minMeasurement}" );
                Console.WriteLine( $"Average {_name} {( GetAverageMeasurement() )}" );
                Console.WriteLine();
            }

            private double GetAverageMeasurement()
            {
                return _measurementsSum / _updatesCount;
            }
        }
    }
}
