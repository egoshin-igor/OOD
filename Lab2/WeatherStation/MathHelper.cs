using System;
using System.Numerics;

namespace WeatherStation
{
    public static class MathHelper
    {
        public static double ToRadians( this double value )
        {
            return ( Math.PI / 180 ) * value;
        }

        public static Vector2 DegreeToVector( double degree )
        {
            double sin = Math.Sin( degree.ToRadians() );
            double cos = Math.Cos( degree.ToRadians() );

            return new Vector2( ( float )sin, ( float )cos );
        }
    }
}
