using System.Collections.Generic;
using System.Windows.Forms;
using Chart.Models;
using Chart.Utils;
using Chart.View.CommonPartViews;
using Chart.ViewModels;

namespace Chart.View.MainFormView
{
    public partial class MainForm : Form
    {
        private readonly MainFormViewModel _mainFormViewModel;
        private HarmonicsListPartView _harmonicsListPartView;
        private HarmonicPartView _selectedHarmonicPartView;

        public MainForm( MainFormViewModel mainFormViewModel )
        {
            _mainFormViewModel = mainFormViewModel;
            InitializeComponent();
            InitializeTabs();
            InitializeHarmonicsListBoxPartView();
            InitializeSelectedHarmonicPartView();
            DeleteSelectedButton.DataBindings.Add( "Enabled", _mainFormViewModel, "IsCanDeleteHarmonic", true, DataSourceUpdateMode.OnPropertyChanged );
        }

        private void InitializeHarmonicsListBoxPartView()
        {
            var harmonicsListViews = new HarmonicsListViews( HarmonicsList, DeleteSelectedButton, AddNewButton );
            _harmonicsListPartView = new HarmonicsListPartView( harmonicsListViews, _mainFormViewModel );

            _harmonicsListPartView.SelectedHarmonicChanged += () =>
            {
                if ( _mainFormViewModel.SelectedHarmonic != null )
                {
                    _selectedHarmonicPartView.UpdateDataBindings();
                }
            };
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

            _selectedHarmonicPartView = new HarmonicPartView( selectedHarmonicViews, _mainFormViewModel );
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
    }
}
