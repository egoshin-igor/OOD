using System;
using Chart.Models.Types;

namespace Chart.Models.Harmonics
{
    // Функция выглядит так: y = Amplitude * HarmonicType * ( Frequency * t + Phase )
    public class Harmonic
    {
        private const double Pi = Math.PI;

        public double Amplitude { get; set; }
        public double Frequency { get; set; }
        public double Phase { get; set; }
        public HarmonicType Type { get; set; }

        public Harmonic( double amplitude = 0, double frequency = 0, double phase = 0, HarmonicType harmonicType = HarmonicType.Sin )
        {
            Amplitude = amplitude;
            Frequency = frequency;
            Phase = phase;
            Type = harmonicType;
        }

        public double GetValueByTime( double time )
        {
            double angle = ( Frequency * time + Phase );
            double typeValue = Type == HarmonicType.Cos ? Math.Cos( angle ) : Math.Sin( angle );

            return Amplitude * typeValue;
        }
    }
}
