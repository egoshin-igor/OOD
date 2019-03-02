using System;
using System.Collections.Generic;
using WeatherStationDuo.Observable;

namespace WeatherStationDuo.Observer
{
    public class StatsDisplay : IObserver<WeatherInfo>
    {
        private readonly List<MeasurementStatisticPrinterDuo> _printers = new List<MeasurementStatisticPrinterDuo>
        {
            new MeasurementStatisticPrinterDuo("Temperature", wi => wi.Temperature),
            new MeasurementStatisticPrinterDuo("Humidity", wi => wi.Temperature),
            new MeasurementStatisticPrinterDuo("Pressure", wi => wi.Pressure)
        };

        private readonly MeasurementStatisticPrinterDuo _windSpeedPrinter;
        private readonly WindDirectionStatisticPrinterDuo _windDirectionPrinter;

        private Observable.IObservable<WeatherInfo> _subjectInBuilding;
        private Observable.IObservable<WeatherInfo> _subjectOutBuilding;

        public StatsDisplay( Observable<WeatherInfo> inSubject, Observable<WeatherInfo> outSubject )
        {
            _subjectInBuilding = inSubject;
            _subjectOutBuilding = outSubject;
            _subjectInBuilding.RegisterObserver( this );
            _subjectOutBuilding.RegisterObserver( this );

            _windDirectionPrinter = new WindDirectionStatisticPrinterDuo( "Wind direction" );
            _windSpeedPrinter = new MeasurementStatisticPrinterDuo( "Wind speed", wi => wi.WindInfo.WindSpeed );
        }

        public virtual void Update( Observable.IObservable<WeatherInfo> subject, WeatherInfo data )
        {
            WeatherStationLocation location;
            if ( subject == _subjectInBuilding )
            {
                location = WeatherStationLocation.In;
            }
            else if ( subject == _subjectOutBuilding )
            {
                location = WeatherStationLocation.Out;
            }
            else
            {
                throw new ApplicationException( "Weather station is undefined" );
            }

            foreach ( MeasurementStatisticPrinterDuo printer in _printers )
            {
                printer.UpdateStatistic( location, data );
            }

            if ( data.WindInfo != null )
            {
                _windSpeedPrinter.UpdateStatistic( location, data );
                _windDirectionPrinter.UpdateStatistic( location, data.WindInfo );
            }

            Console.WriteLine( "-----------------------" );
        }

        private class MeasurementStatisticPrinterDuo
        {
            private readonly Func<WeatherInfo, double> _extractor;
            private IMeasurementStatisticInfo _statisticInBuilding = new BaseMeasurementStatisticInfo();
            private IMeasurementStatisticInfo _statisticOutBuilding = new BaseMeasurementStatisticInfo();
            private readonly string _name;

            public MeasurementStatisticPrinterDuo( string name, Func<WeatherInfo, double> extractor )
            {
                _name = name;
                _extractor = extractor;
            }

            public void UpdateStatistic( WeatherStationLocation location, WeatherInfo data )
            {
                if ( location == WeatherStationLocation.In )
                {
                    _statisticInBuilding.UpdateStatistic( _extractor( data ) );
                    Console.WriteLine( $"Location: in building" );
                    PrintStatistic( _statisticInBuilding );
                }
                else
                {
                    _statisticOutBuilding.UpdateStatistic( _extractor( data ) );
                    Console.WriteLine( $"Location: out building" );
                    PrintStatistic( _statisticOutBuilding );
                }
            }

            private void PrintStatistic( IMeasurementStatisticInfo statisticInfo )
            {
                Console.WriteLine( $"Max {_name} {statisticInfo.MaxMeasurement}" );
                Console.WriteLine( $"Min {_name} {statisticInfo.MinMeasurement}" );
                Console.WriteLine( $"Average {_name} {( Math.Round( statisticInfo.AverageMeasurement.Value, 2 ) )}" );
                Console.WriteLine();
            }
        }

        private class WindDirectionStatisticPrinterDuo
        {
            private WindDirectionStatisticInfo _statisticInBuilding = new WindDirectionStatisticInfo();
            private WindDirectionStatisticInfo _statisticOutBuilding = new WindDirectionStatisticInfo();
            private readonly string _name;

            public WindDirectionStatisticPrinterDuo( string name )
            {
                _name = name;
            }

            public void UpdateStatistic( WeatherStationLocation location, WindInfo data )
            {
                if ( location == WeatherStationLocation.In )
                {
                    _statisticInBuilding.UpdateStatistic( data );
                    Console.WriteLine( $"Location: in building" );
                    PrintStatistic( _statisticInBuilding );
                }
                else
                {
                    _statisticOutBuilding.UpdateStatistic( data );
                    Console.WriteLine( $"Location: out building" );
                    PrintStatistic( _statisticOutBuilding );
                }
            }

            private void PrintStatistic( WindDirectionStatisticInfo statisticInfo )
            {
                Console.Write( $"Average {_name} " );
                if ( statisticInfo.AverageMeasurement != null )
                {
                    Console.WriteLine( Math.Round( statisticInfo.AverageMeasurement.Value, 2 ) );
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
