using System;

namespace WeatherStationDuo.Observable
{
    public class WindInfo : IEquatable<WindInfo>
    {
        public double WindDirection { get; protected set; }
        public double WindSpeed { get; protected set; }

        public WindInfo( double windDirection, double windSpeed )
        {
            WindDirection = windDirection;
            WindSpeed = windSpeed;
        }

        public override bool Equals( object obj )
        {
            if ( obj is WindInfo )
            {
                return Equals( obj );
            }

            return false;
        }

        public bool Equals( WindInfo other )
        {
            return other != null &&
                WindDirection == other.WindDirection &&
                WindSpeed == other.WindSpeed;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine( WindDirection, WindSpeed );
        }

        public static bool operator ==( WindInfo first, WindInfo second )
        {
            if ( first is null )
            {
                return false;
            }

            return first.Equals( second );
        }

        public static bool operator !=( WindInfo first, WindInfo second )
        {
            if ( first is null )
            {
                return false;
            }

            return !( first == second );
        }
    }
}
