namespace WeatherStationDuo.Observable
{
    public class WeatherData : Observable<WeatherInfo>
    {
        public WeatherInfo WeatherInfo { get; protected set; }

        public void MeasurementsChanged()
        {
            NotifyObservers();
        }

        public void UpdateWeatherInfo( double temperature, double humidity, double pressure )
        {
            WeatherInfo = new WeatherInfo( temperature, humidity, pressure );

            MeasurementsChanged();
        }

        protected override WeatherInfo GetChangedData()
        {
            return WeatherInfo;
        }
    }
}
