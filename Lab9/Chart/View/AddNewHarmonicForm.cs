using System;
using System.Windows.Forms;
using Chart.Models.Harmonics;
using Chart.View.CommonPartViews;
using Chart.ViewModels;

namespace Chart.View
{
    public partial class AddNewHarmonicForm : Form
    {
        public event Action OnOkClick;

        private HarmonicPartView _harmonicPartView;

        public HarmonicViewModel NewHarmonic => _harmonicPartView.Harmonic;

        public AddNewHarmonicForm()
        {
            InitializeComponent();
            InitializeSelectedHarmonicPartView();
            HarmonicStringRepresentation.DataBindings
                .Add( "Text", NewHarmonic, "StringRepresentation", true, DataSourceUpdateMode.OnPropertyChanged );
        }

        private void InitializeSelectedHarmonicPartView()
        {
            var selectedHarmonicViews = new HarmonicViews(
                FrequencyInput,
                AmplitudeInput,
                PhaseInput,
                SinRadioButton,
                CosRadioButton
            );

            HarmonicViewModel newHarmonic = new HarmonicViewModel( new Harmonic() );
            var harmonicPartViewViewModel = new AlwaysEditableHarmonicPartViewViewModel { SelectedHarmonic = newHarmonic };
            _harmonicPartView = new HarmonicPartView( selectedHarmonicViews, harmonicPartViewViewModel );
            _harmonicPartView.UpdateDataBindings();
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
    }
}
