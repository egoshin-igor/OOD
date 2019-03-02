using System;
using System.Collections.Generic;
using WeatherStation.Observable;


namespace WeatherStation.Observer
{
    public class StatsDisplay : IObserver<WeatherInfo>
    {
        private readonly List<MeasurementStatisticPrinter> _printers = new List<MeasurementStatisticPrinter>
        {
            new MeasurementStatisticPrinter( "Temperature", wi => wi.Temperature),
            new MeasurementStatisticPrinter( "Humidity", wi => wi.Humidity),
            new MeasurementStatisticPrinter( "Pressure", wi => wi.Pressure),
            new MeasurementStatisticPrinter( "Wind speed", wi => wi.WindInfo.WindSpeed )
        };

        private WindDirectionStatisticPrinter _windDirectionPrinter;

        public StatsDisplay()
        {
            _windDirectionPrinter = new WindDirectionStatisticPrinter( "Wind direction" );
        }

        public void Update( WeatherInfo data )
        {
            UpdateWeatherStatistic( data );
            PrintWeatherStatistic();
        }

        private void UpdateWeatherStatistic( WeatherInfo data )
        {
            foreach ( MeasurementStatisticPrinter printer in _printers )
            {
                printer.UpdateStatistic( data );
            }

            _windDirectionPrinter.UpdateStatistic( data.WindInfo );
        }

        private void PrintWeatherStatistic()
        {
            foreach ( MeasurementStatisticPrinter printer in _printers )
            {
                printer.PrintStatistic();
            }

            _windDirectionPrinter.PrintStatistic();
            Console.WriteLine( "-----------------------" );
        }

        private class MeasurementStatisticPrinter
        {
            private readonly Func<WeatherInfo, double> _extractor;
            private IMeasurementStatisticInfo _info = new BaseMeasurementStatisticInfo();
            private readonly string _name;

            public MeasurementStatisticPrinter( string name, Func<WeatherInfo, double> extractor )
            {
                _name = name;
                _extractor = extractor;
            }

            public void UpdateStatistic( WeatherInfo data )
            {
                _info.UpdateStatistic( _extractor( data ) );
            }

            public void PrintStatistic()
            {
                Console.WriteLine( $"Max {_name} {_info.MaxMeasurement}" );
                Console.WriteLine( $"Min {_name} {_info.MinMeasurement}" );
                Console.WriteLine( $"Average {_name} {( Math.Round( _info.AverageMeasurement.Value, 2 ) )}" );
                Console.WriteLine();
            }
        }

        private class WindDirectionStatisticPrinter
        {
            private WindDirectionStatisticInfo _info = new WindDirectionStatisticInfo();
            private readonly string _name;

            public WindDirectionStatisticPrinter( string name )
            {
                _name = name;
            }

            public void UpdateStatistic( WindInfo data )
            {
                _info.UpdateStatistic( data );
            }

            public void PrintStatistic()
            {
                Console.Write( $"Average {_name} " );
                if ( _info.AverageMeasurement != null )
                {
                    Console.WriteLine( Math.Round( _info.AverageMeasurement.Value, 2 ) );
                }
                else
                {
                    Console.WriteLine( "is undefined" );
                }

                Console.WriteLine();
            }
        }
    }
}
