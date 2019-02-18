namespace WeatherStationDuo.Observable
{
    public class WeatherData : Observable<WeatherInfo>
    {
        public WeatherInfo WeatherInfo { get; protected set; }
        public WeatherStationLocation Location { get; protected set; }

        public WeatherData( WeatherStationLocation location )
        {
            Location = location;
        }

        public void MeasurementsChanged()
        {
            NotifyObservers();
        }

        public void UpdateWeatherInfo( WeatherInfo weatherInfo )
        {
            WeatherInfo = weatherInfo;

            MeasurementsChanged();
        }

        protected override WeatherInfo GetChangedData()
        {
            return WeatherInfo;
        }
    }
}
