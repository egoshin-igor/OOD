using System;
using System.Windows.Forms;
using Chart.Models.Types;
using Chart.Utils;
using Chart.ViewModels;

namespace Chart.View.CommonPartViews
{
    public class HarmonicPartView
    {
        private HarmonicViews _views;
        private IHarmonicPartViewViewModel _viewModel;

        public HarmonicViewModel Harmonic => _viewModel.SelectedHarmonic;

        public HarmonicPartView( HarmonicViews views, IHarmonicPartViewViewModel viewModel )
        {
            _views = views;
            _viewModel = viewModel;
            InitializeSelectedHarmonicBindings();
            EnableSelectedHarmonicBoxReadOnlyMode( !_viewModel.IsCanEditHarmonic );
            SetDefaultValueToSelectedHarmonicBox();
            BindEventHandlers();
        }

        private void InitializeSelectedHarmonicBindings()
        {
            _viewModel.IsCanEditHarmonicChanged += () =>
            {
                EnableSelectedHarmonicBoxReadOnlyMode( !_viewModel.IsCanEditHarmonic );
                if ( !_viewModel.IsCanEditHarmonic )
                {
                    SetDefaultValueToSelectedHarmonicBox();
                }
            };
        }

        private void BindEventHandlers()
        {
            _views.PhaseInput.TextChanged += new EventHandler( PhaseInput_TextChanged );
            _views.FrequencyInput.TextChanged += new EventHandler( FrequencyInput_TextChanged );
            _views.CosRadioButton.CheckedChanged += new EventHandler( CosRadioButton_CheckedChanged );
            _views.SinRadioButton.CheckedChanged += new EventHandler( SinRadioButton_CheckedChanged );
            _views.AmplitudeInput.TextChanged += new EventHandler( AmplitudeInput_TextChanged );
        }

        public void UpdateDataBindings()
        {
            var onPropertyChangedUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            _views.AmplitudeInput.DataBindings.Clear();
            _views.AmplitudeInput.DataBindings.Add( "Text", _viewModel.SelectedHarmonic, "Amplitude", true, onPropertyChangedUpdateMode );
            _views.FrequencyInput.DataBindings.Clear();
            _views.FrequencyInput.DataBindings.Add( "Text", _viewModel.SelectedHarmonic, "Frequency", true, onPropertyChangedUpdateMode );
            _views.PhaseInput.DataBindings.Clear();
            _views.PhaseInput.DataBindings.Add( "Text", _viewModel.SelectedHarmonic, "Phase", true, onPropertyChangedUpdateMode );

            if ( _viewModel.SelectedHarmonic.Type == HarmonicType.Cos )
            {
                _views.CosRadioButton.Checked = true;
            }
            else
            {
                _views.SinRadioButton.Checked = true;
            }
        }

        private void SinRadioButton_CheckedChanged( object sender, EventArgs e )
        {
            if ( _viewModel.SelectedHarmonic == null )
            {
                return;
            }
            if ( _views.SinRadioButton.Focused )
            {
                _viewModel.SelectedHarmonic.Type = HarmonicType.Sin;
            }
        }

        private void CosRadioButton_CheckedChanged( object sender, EventArgs e )
        {
            if ( _viewModel.SelectedHarmonic == null )
            {
                return;
            }
            if ( _views.CosRadioButton.Focused )
            {
                _viewModel.SelectedHarmonic.Type = HarmonicType.Cos;
            }
        }

        private void AmplitudeInput_TextChanged( object sender, EventArgs e )
        {
            TextBoxUtils.ValidateDoubleInput( _views.AmplitudeInput );
        }

        private void FrequencyInput_TextChanged( object sender, EventArgs e )
        {
            TextBoxUtils.ValidateDoubleInput( _views.FrequencyInput );
        }

        private void PhaseInput_TextChanged( object sender, EventArgs e )
        {
            TextBoxUtils.ValidateDoubleInput( _views.PhaseInput );
        }

        private void EnableSelectedHarmonicBoxReadOnlyMode( bool enableReadonlyMode )
        {
            _views.AmplitudeInput.Enabled = !enableReadonlyMode;
            _views.SinRadioButton.Enabled = !enableReadonlyMode;
            _views.CosRadioButton.Enabled = !enableReadonlyMode;
            _views.FrequencyInput.Enabled = !enableReadonlyMode;
            _views.PhaseInput.Enabled = !enableReadonlyMode;
        }

        private void SetDefaultValueToSelectedHarmonicBox()
        {
            _views.AmplitudeInput.Text = "0";
            _views.SinRadioButton.Checked = false;
            _views.CosRadioButton.Checked = false;
            _views.PhaseInput.Text = "0";
            _views.FrequencyInput.Text = "0";
        }
    }
}
