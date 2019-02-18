using System;

namespace WeatherStation.Observable
{
    public class WeatherInfo : IEquatable<WeatherInfo>
    {
        public double Temperature { get; protected set; }
        public double Humidity { get; protected set; }
        public double Pressure { get; protected set; }

        public WeatherInfo( double temperature, double humidity, double pressure )
        {
            Temperature = temperature;
            Humidity = humidity;
            Pressure = pressure;
        }

        public override bool Equals( object obj )
        {
            var info = obj as WeatherInfo;
            if ( info == null )
            {
                return false;
            }

            return Equals( obj );
        }

        public bool Equals( WeatherInfo other )
        {
            return other != null &&
                Temperature == other.Temperature &&
                Humidity == other.Humidity &&
                Pressure == other.Pressure;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine( Temperature, Humidity, Pressure );
        }

        public static bool operator ==( WeatherInfo first, WeatherInfo second )
        {
            if ( first == null )
            {
                return false;
            }

            return first.Equals( second );
        }
        public static bool operator !=( WeatherInfo first, WeatherInfo second )
        {
            return !( first == second );
        }
    }
}
