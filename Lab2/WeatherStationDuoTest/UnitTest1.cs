using System;
using WeatherStationDuo.Observable;
using Xunit;

namespace WeatherStationDuoTest
{
    public class WeatherDataTest
    {
        [Fact]
        public void MeasurementsChanged()
        {
            WeatherData wd = new WeatherData( WeatherStationLocation.In );

        }
    }
}
