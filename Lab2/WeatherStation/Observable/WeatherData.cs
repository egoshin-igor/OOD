namespace WeatherStation.Observable
{
    public class WeatherData : Observable<WeatherInfo>
    {
        public WeatherInfo WeatherInfo { get; protected set; }

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
