using System;

namespace WeatherStation.Observer
{
    public class BaseMeasurementStatisticInfo : IMeasurementStatisticInfo
    {
        protected double _maxMeasurement = double.NegativeInfinity;
        protected double _minMeasurement = double.PositiveInfinity;
        protected double _measurementsSum = 0;
        protected uint _updatesCount = 0;

        public virtual double? MaxMeasurement
        {
            get => double.IsNegativeInfinity( _maxMeasurement ) ? null : ( double? )_maxMeasurement;
        }

        public virtual double? MinMeasurement
        {
            get => double.IsPositiveInfinity( _minMeasurement ) ? null : ( double? )_minMeasurement;
        }

        public virtual double? AverageMeasurement
        {
            get
            {
                if ( _updatesCount == 0 )
                {
                    return null;
                }

                return _measurementsSum / _updatesCount;
            }
            protected set { }
        }

        public virtual void UpdateStatistic( double measurement )
        {
            UpdateMinMeasurement( measurement );
            UpdateMaxMeasurement( measurement );
            UpdateAverageMeasurement( measurement );
        }

        protected virtual void UpdateMinMeasurement( double measurement )
        {
            if ( _minMeasurement > measurement )
            {
                _minMeasurement = measurement;
            }
        }

        protected virtual void UpdateMaxMeasurement( double measurement )
        {
            if ( _maxMeasurement < measurement )
            {
                _maxMeasurement = measurement;
            }
        }

        protected virtual void UpdateAverageMeasurement( double measurement )
        {
            _measurementsSum += measurement;
            ++_updatesCount;
        }
    }
}
