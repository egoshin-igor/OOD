using System;
using System.Collections.Generic;
using WeatherStation.Observable;


namespace WeatherStation.Observer
{
    public class StatsDisplay : IObserver<WeatherInfo>
    {
        private readonly List<MeasurementStatisticPrinter> _printers = new List<MeasurementStatisticPrinter>
        {
            new MeasurementStatisticPrinter("Temperature", wi => wi.Temperature),
            new MeasurementStatisticPrinter("Humidity", wi => wi.Temperature),
            new MeasurementStatisticPrinter("Pressure", wi => wi.Pressure),
            new MeasurementStatisticPrinter("Wind speed", wi => wi.WindInfo?.WindSpeed ?? 0 ),
            new WindDirectionStatisticPrinter("Wind direction", wi => wi.WindInfo?.WindDirection ?? 0 )
        };

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
        }

        private void PrintWeatherStatistic()
        {
            foreach ( MeasurementStatisticPrinter printer in _printers )
            {
                printer.PrintStatistic();
            }
            Console.WriteLine( "-----------------------" );
        }

        private class MeasurementStatisticPrinter
        {
            readonly Func<WeatherInfo, double> _extractor;
            protected IMeasurementStatisticInfo _info = new BaseMeasurementStatisticInfo();
            readonly string _name;

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

        private class WindDirectionStatisticPrinter : MeasurementStatisticPrinter
        {
            public WindDirectionStatisticPrinter( string name, Func<WeatherInfo, double> extractor )
                : base( name, extractor )
            {
                _info = new WindDirectionStatisticInfo();
            }
        }
    }
}
