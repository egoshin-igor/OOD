namespace WeatherStationDuo.Observer
{
    public interface IMeasurementStatisticInfo
    {
        double? MaxMeasurement { get; }
        double? MinMeasurement { get; }
        double? AverageMeasurement { get; }
        void UpdateStatistic( double measurement );
    }
}
