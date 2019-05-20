using System;
using System.Windows.Forms;
using Chart.Models.Harmonics;
using Chart.Models.Types;
using Chart.Utils;
using Chart.ViewModels;

namespace Chart.View
{
    public partial class AddNewHarmonicForm : Form
    {
        public event Action OnOkClick;

        public HarmonicViewModel NewHarmonic { get; private set; }

        public AddNewHarmonicForm()
        {
            NewHarmonic = new HarmonicViewModel( new Harmonic() );
            InitializeComponent();
            InitializeSelectedHarmonicBox();
        }

        private void InitializeSelectedHarmonicBox()
        {
            AmplitudeInput.DataBindings.Add( "Text", NewHarmonic, "Amplitude", true, DataSourceUpdateMode.OnPropertyChanged );
            FrequencyInput.DataBindings.Add( "Text", NewHarmonic, "Frequency", true, DataSourceUpdateMode.OnPropertyChanged );
            PhaseInput.DataBindings.Add( "Text", NewHarmonic, "Phase", true, DataSourceUpdateMode.OnPropertyChanged );
            HarmonicStringRepresentation.DataBindings.Add( "Text", NewHarmonic, "StringRepresentation", true, DataSourceUpdateMode.OnPropertyChanged );

            if ( NewHarmonic.Type == HarmonicType.Cos )
            {
                CosRadioButton.Checked = true;
            }
            else
            {
                SinRadioButton.Checked = true;
            }
        }

        private void CancelButton_Click( object sender, EventArgs e )
        {
            Close();
        }

        private void OkButton_Click( object sender, EventArgs e )
        {
            OnOkClick?.Invoke();
            Close();
        }

        private void SinRadioButton_CheckedChanged( object sender, EventArgs e )
        {
            if ( SinRadioButton.Focused )
            {
                NewHarmonic.Type = HarmonicType.Sin;
            }
        }

        private void CosRadioButton_CheckedChanged( object sender, EventArgs e )
        {
            if ( CosRadioButton.Focused )
            {
                NewHarmonic.Type = HarmonicType.Cos;
            }
        }

        private void FrequencyInput_TextChanged( object sender, EventArgs e )
        {
            TextBoxUtils.ValidateDoubleInput( FrequencyInput );
        }

        private void AmplitudeInput_TextChanged( object sender, EventArgs e )
        {
            TextBoxUtils.ValidateDoubleInput( AmplitudeInput );
        }

        private void PhaseInput_TextChanged( object sender, EventArgs e )
        {
            TextBoxUtils.ValidateDoubleInput( PhaseInput );
        }
    }
}
