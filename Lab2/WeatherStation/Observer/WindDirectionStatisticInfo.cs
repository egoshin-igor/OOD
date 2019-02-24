using System;
using System.Numerics;

namespace WeatherStation.Observer
{
    public class WindDirectionStatisticInfo : BaseMeasurementStatisticInfo
    {
        public override double? AverageMeasurement { get; protected set; } = null;

        protected override void UpdateAverageMeasurement( double measurement )
        {
            Vector2 vectorFromDegree = MathHelper.DegreeToVector( measurement );
            Vector2 resultVector;
            if ( AverageMeasurement != null )
            {
                resultVector = Vector2.Add( MathHelper.DegreeToVector( AverageMeasurement.Value ), vectorFromDegree );
            }
            else
            {
                resultVector = vectorFromDegree;
            }

            AverageMeasurement = GetWindDirectionInDegree( resultVector );
        }

        private double GetWindDirectionInDegree( Vector2 vector )
        {
            const double maxPossibleMeasurement = 360;
            const double piInDegree = 180;

            var startVector = new Vector2( 0, 1 );

            float zCoord = startVector.X * vector.Y - vector.X * startVector.Y;
            float scalar = Vector2.Dot( startVector, vector );
            float length = startVector.Length() * vector.Length();

            double radian = Math.Acos( scalar / length );
            double degree = ( piInDegree / Math.PI ) * radian;


            bool isNegativeZCoord = zCoord < 0;
            double result = isNegativeZCoord ? degree : maxPossibleMeasurement - degree;
            return result >= maxPossibleMeasurement ? 0 : result;
        }
    }
}
