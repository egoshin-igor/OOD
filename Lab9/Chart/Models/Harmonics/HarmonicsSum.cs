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
    }
}
