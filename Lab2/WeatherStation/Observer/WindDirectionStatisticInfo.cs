using System;
using System.Numerics;
using WeatherStation.Observable;

namespace WeatherStation.Observer
{
    public class WindDirectionStatisticInfo
    {
        Vector2 _lastWindVector;

        public double? AverageMeasurement
        {
            get
            {
                const double undefinedBound = 0.001;

                if ( Math.Abs( _lastWindVector.X ) < undefinedBound && Math.Abs( _lastWindVector.Y ) < undefinedBound )
                {
                    return null;
                }

                return GetWindDirectionInDegree( _lastWindVector );
            }
        }

        public virtual void UpdateStatistic( WindInfo windInfo )
        {
            Vector2 windVector = GetVectorByWind( windInfo.WindDirection, windInfo.WindSpeed );

            Vector2 resultVector;
            if ( AverageMeasurement != null )
            {
                resultVector = Vector2.Add( _lastWindVector, windVector );
            }
            else
            {
                resultVector = windVector;
            }

            _lastWindVector = resultVector;
        }

        private double GetWindDirectionInDegree( Vector2 vector )
        {
            const double maxPossibleMeasurement = 360;
            const double piInDegree = 180;

            double radian = Math.Atan2( vector.Y, vector.X );
            double degree = ( piInDegree / Math.PI ) * radian;
            if ( radian < 0 )
            {
                degree += 360;
            }

            return degree.Equals( maxPossibleMeasurement ) ? 0 : degree;
        }

        public static Vector2 GetVectorByWind( double degree, double speed )
        {
            double radian = degree * ( Math.PI / 180 );
            double sin = Math.Sin( radian );
            double cos = Math.Cos( radian );

            return new Vector2( ( float )( cos * speed ), ( float )( sin * speed ) );
        }
    }
}
