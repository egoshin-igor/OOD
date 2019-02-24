namespace WeatherStationDuo.Observable
{
    public class WeatherDataPro : Observable<WeatherInfo>
    {
        public WeatherInfo WeatherInfo { get; protected set; }

        public void MeasurementsChanged()
        {
            NotifyObservers();
        }

        public void UpdateWeatherInfo( double temperature, double humidity, double pressure, double windDirection, double windSpeed )
        {
            WeatherInfo = new WeatherInfo( temperature, humidity, pressure, new WindInfo( windDirection, windSpeed ) );

            MeasurementsChanged();
        }

        protected override WeatherInfo GetChangedData()
        {
            return WeatherInfo;
        }
    }
}
