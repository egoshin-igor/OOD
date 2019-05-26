using System;
using Chart.ViewModels;

namespace Chart.View.MainFormView
{
    public class HarmonicsListPartView
    {
        private HarmonicsListViews _views;
        private IListBoxViewModel _listBoxViewModel;
        private AddNewHarmonicForm _addNewHarmonicForm;

        public event Action SelectedHarmonicChanged;

        public HarmonicsListPartView( HarmonicsListViews views, IListBoxViewModel listBoxViewModel )
        {
            _views = views;
            _listBoxViewModel = listBoxViewModel;
            InitializeHarmonicsList();
            _views.DeleteSelectedButton.Click += new EventHandler( DeleteSelectedButton_Click );
            _views.AddNewButton.Click += new EventHandler( AddNewButton_Click );
            _views.HarmonicsListBox.SelectedIndexChanged += new EventHandler( HarmonicsList_SelectedIndexChanged );
        }

        private void InitializeHarmonicsList()
        {
            _views.HarmonicsListBox.DataSource = _listBoxViewModel.Harmonics;
            _views.HarmonicsListBox.DisplayMember = "StringRepresentation";
        }

        private void DeleteSelectedButton_Click( object sender, EventArgs e )
        {
            if ( !_listBoxViewModel.IsCanDeleteHarmonic )
            {
                return;
            }
            if ( _views.HarmonicsListBox.SelectedIndex >= 0 )
            {
                _listBoxViewModel.Harmonics.RemoveAt( _views.HarmonicsListBox.SelectedIndex );
            }
            UpdateSelectedHarmonic();
        }

        private void AddNewButton_Click( object sender, EventArgs e )
        {
            _addNewHarmonicForm = new AddNewHarmonicForm();
            _addNewHarmonicForm.OnOkClick += () =>
            {
                HarmonicViewModel newHarmonic = _addNewHarmonicForm.NewHarmonic;
                _listBoxViewModel.Harmonics.Add( newHarmonic );
                _listBoxViewModel.SelectedHarmonic = newHarmonic;
                _views.HarmonicsListBox.SelectedIndex = _listBoxViewModel.Harmonics.Count - 1;
                SelectedHarmonicChanged?.Invoke();
            };
            _addNewHarmonicForm.Show();
        }

        private void HarmonicsList_SelectedIndexChanged( object sender, EventArgs e )
        {
            UpdateSelectedHarmonic();
        }

        private void UpdateSelectedHarmonic()
        {
            if ( _views.HarmonicsListBox.SelectedItem == null )
                return;
            if ( ReferenceEquals( _listBoxViewModel.SelectedHarmonic, _views.HarmonicsListBox.SelectedItem ) )
                return;

            _listBoxViewModel.SelectedHarmonic = _views.HarmonicsListBox.SelectedItem as HarmonicViewModel;
            SelectedHarmonicChanged?.Invoke();
        }
    }
}
