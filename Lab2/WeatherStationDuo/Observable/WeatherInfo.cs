using System;

namespace WeatherStationDuo.Observable
{
    public class WeatherInfo : IEquatable<WeatherInfo>
    {
        public double Temperature { get; protected set; }
        public double Humidity { get; protected set; }
        public double Pressure { get; protected set; }
        public WindInfo WindInfo { get; protected set; }

        public WeatherInfo( double temperature, double humidity, double pressure, WindInfo windInfo = null )
        {
            Temperature = temperature;
            Humidity = humidity;
            Pressure = pressure;
            WindInfo = windInfo;
        }

        public override bool Equals( object obj )
        {
            if ( obj is WeatherInfo )
            {
                return Equals( obj );
            }

            return false;
        }

        public bool Equals( WeatherInfo other )
        {
            return other != null &&
                Temperature == other.Temperature &&
                Humidity == other.Humidity &&
                Pressure == other.Pressure &&
                WindInfo == other.WindInfo;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine( Temperature, Humidity, Pressure, WindInfo );
        }

        public static bool operator ==( WeatherInfo first, WeatherInfo second )
        {
            return first.Equals( second );
        }

        public static bool operator !=( WeatherInfo first, WeatherInfo second )
        {
            return !( first == second );
        }
    }
}
