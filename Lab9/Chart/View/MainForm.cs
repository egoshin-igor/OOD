using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Chart.Models;
using Chart.Models.Types;
using Chart.Utils;
using Chart.ViewModels;

namespace Chart.View
{
    public partial class MainForm : Form
    {
        private readonly MainFormViewModel _mainFormViewModel;
        private AddNewHarmonicForm _addNewHarmonicForm;

        public MainForm( MainFormViewModel applicationViewModel )
        {
            _mainFormViewModel = applicationViewModel;
            InitializeComponent();
            InitializeHarmonicsList();
            InitializeTabs();
        }

        private void InitializeHarmonicsList()
        {
            HarmonicsList.DataSource = _mainFormViewModel.Harmonics;
            HarmonicsList.DisplayMember = "StringRepresentation";
        }

        private void InitializeSelectedHarmonicBox()
        {
            AmplitudeInput.DataBindings.Clear();
            AmplitudeInput.DataBindings.Add( "Text", _mainFormViewModel.SelectedHarmonic, "Amplitude", true, DataSourceUpdateMode.OnPropertyChanged );
            FrequencyInput.DataBindings.Clear();
            FrequencyInput.DataBindings.Add( "Text", _mainFormViewModel.SelectedHarmonic, "Frequency", true, DataSourceUpdateMode.OnPropertyChanged );
            PhaseInput.DataBindings.Clear();
            PhaseInput.DataBindings.Add( "Text", _mainFormViewModel.SelectedHarmonic, "Phase", true, DataSourceUpdateMode.OnPropertyChanged );

            if ( _mainFormViewModel.SelectedHarmonic.Type == HarmonicType.Cos )
            {
                CosRadioButton.Checked = true;
            }
            else
            {
                SinRadioButton.Checked = true;
            }
        }

        private void InitializeTabs()
        {
            Table.ColumnCount = 2;
            Table.Columns[ 0 ].Name = "X";
            Table.Columns[ 1 ].Name = "Y";
            Table.Dock = DockStyle.Fill;
            Table.Parent = TableTab;

            _mainFormViewModel.OnHarmonicSumChange += () =>
            {
                List<Point> points = _mainFormViewModel.Points;

                Chart.DrawChart( _mainFormViewModel.Points );

                Table.Rows.Clear();
                foreach ( Point point in points )
                {
                    Table.Rows.Add( new string[] { point.X.ToString(), point.Y.ToString() } );
                }
            };
        }

        private void HarmonicsList_SelectedIndexChanged( object sender, EventArgs e )
        {
            if ( HarmonicsList.SelectedItem == null )
                return;
            if ( ReferenceEquals( _mainFormViewModel.SelectedHarmonic, HarmonicsList.SelectedItem ) )
                return;

            _mainFormViewModel.SelectedHarmonic = ( HarmonicViewModel )HarmonicsList.SelectedItem;
            if ( _mainFormViewModel.SelectedHarmonic != null )
            {
                InitializeSelectedHarmonicBox();
            }
        }

        private void SinRadioButton_CheckedChanged( object sender, EventArgs e )
        {
            if ( SinRadioButton.Focused )
            {
                _mainFormViewModel.SelectedHarmonic.Type = HarmonicType.Sin;
            }
        }

        private void CosRadioButton_CheckedChanged( object sender, EventArgs e )
        {
            if ( CosRadioButton.Focused )
            {
                _mainFormViewModel.SelectedHarmonic.Type = HarmonicType.Cos;
            }
        }

        private void AddNewButton_Click( object sender, EventArgs e )
        {
            _addNewHarmonicForm = new AddNewHarmonicForm();
            _addNewHarmonicForm.OnOkClick += () =>
            {
                HarmonicViewModel newHarmonic = _addNewHarmonicForm.NewHarmonic;
                _mainFormViewModel.Harmonics.Add( newHarmonic );
                _mainFormViewModel.SelectedHarmonic = newHarmonic;
                HarmonicsList.SelectedIndex = _mainFormViewModel.Harmonics.Count - 1;
                InitializeSelectedHarmonicBox();
            };
            _addNewHarmonicForm.Show();
        }

        private void DeleteSelectedButton_Click( object sender, EventArgs e )
        {
            if ( HarmonicsList.SelectedIndex >= 0 )
            {
                _mainFormViewModel.Harmonics.RemoveAt( HarmonicsList.SelectedIndex );
            }
        }

        private void AmplitudeInput_TextChanged( object sender, EventArgs e )
        {
            TextBoxUtils.ValidateDoubleInput( AmplitudeInput );
        }

        private void FrequencyInput_TextChanged( object sender, EventArgs e )
        {
            TextBoxUtils.ValidateDoubleInput( FrequencyInput );
        }

        private void PhaseInput_TextChanged( object sender, EventArgs e )
        {
            TextBoxUtils.ValidateDoubleInput( PhaseInput );
        }
    }
}
