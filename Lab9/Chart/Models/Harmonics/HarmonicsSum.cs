using System.Collections.Generic;

namespace Chart.Models.Harmonics
{
    public class HarmonicsSum
    {
        public List<Harmonic> Harmonics { get; } = new List<Harmonic>();

        public double GetValueByTime( double time )
        {
            var result = 0d;
            foreach ( Harmonic harmonic in Harmonics )
            {
                result += harmonic.GetValueByTime( time );
            }

            return result;
        }

        public List<Point> GetPoints( int count, double step )
        {
            var result = new List<Point>();

            for ( int i = 0; i < count; i++ )
            {
                double t = step * i;
                double y = GetValueByTime( t );

                result.Add( new Point( t, y ) );
            }

            return result;
        }
    }
}
