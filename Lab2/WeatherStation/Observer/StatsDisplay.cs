using System;
using WeatherStation.Observable;


namespace WeatherStation.Observer
{
    public class StatsDisplay : IObserver<WeatherInfo>
    {
        private MeasurementStatisticInfo _temperatureStatistic = new MeasurementStatisticInfo( "Temperature" );
        private MeasurementStatisticInfo _humidityStatistic = new MeasurementStatisticInfo( "Humidity" );
        private MeasurementStatisticInfo _pressureStatistic = new MeasurementStatisticInfo( "Pressure" );

        public void Update( WeatherInfo data )
        {
            _temperatureStatistic.UpdateStatistic( data.Temperature );
            _humidityStatistic.UpdateStatistic( data.Humidity );
            _pressureStatistic.UpdateStatistic( data.Pressure );
            Console.WriteLine( "-----------------------" );
        }

        private class MeasurementStatisticInfo
        {
            private readonly string _name;
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
