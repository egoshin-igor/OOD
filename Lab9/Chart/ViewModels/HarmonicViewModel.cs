using System.ComponentModel;
using System.Runtime.CompilerServices;
using Chart.Models.Harmonics;
using Chart.Models.Types;
using Chart.Utils;

namespace Chart.ViewModels
{
    public class HarmonicViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Harmonic Harmonic { get; }

        public string StringRepresentation => $"{Amplitude}*{Type.ToString()}({Frequency}*t + {Phase})";

        public string Amplitude
        {
            get
            {
                return Harmonic.Amplitude.ToString();
            }
            set
            {
                Harmonic.Amplitude = value.AsDouble() ?? 0;
                OnPropertyChanged( "StringRepresentation" );
                OnPropertyChanged();
            }
        }

        public string Frequency
        {
            get
            {
                return Harmonic.Frequency.ToString();
            }
            set
            {
                Harmonic.Frequency = value.AsDouble() ?? 0;
                OnPropertyChanged( "StringRepresentation" );
                OnPropertyChanged();
            }
        }
        public string Phase
        {
            get
            {
                return Harmonic.Phase.ToString();
            }
            set
            {
                Harmonic.Phase = value.AsDouble() ?? 0;
                OnPropertyChanged( "StringRepresentation" );
                OnPropertyChanged();
            }
        }

        public HarmonicType Type
        {
            get
            {
                return Harmonic.Type;
            }
            set
            {
                Harmonic.Type = value;
                OnPropertyChanged( "StringRepresentation" );
                OnPropertyChanged();
            }
        }

        public HarmonicViewModel( Harmonic harmonic )
        {
            Harmonic = harmonic;
        }

        public double GetValueByTime( double time )
        {
            return Harmonic.GetValueByTime( time );
        }

        private void OnPropertyChanged( [CallerMemberName] string property = "" )
        {
            PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( property ) );
        }
    }
}