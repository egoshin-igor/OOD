using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Chart.Models;

namespace Chart.ViewModels
{
    public class MainFormViewModel : INotifyPropertyChanged, IListBoxViewModel, IHarmonicPartViewViewModel
    {
        private readonly HarmonicsSumViewModel _harmonicsSumViewModel = new HarmonicsSumViewModel();

        public event PropertyChangedEventHandler PropertyChanged;
        public event Action IsCanEditHarmonicChanged;
        public event Action OnHarmonicSumChange
        {
            add => _harmonicsSumViewModel.OnHarmonicSumChange += value;
            remove => _harmonicsSumViewModel.OnHarmonicSumChange -= value;
        }

        public HarmonicViewModel SelectedHarmonic { get; set; }

        public BindingList<HarmonicViewModel> Harmonics => _harmonicsSumViewModel.HarmonicViewModels;
        public List<Point> Points => _harmonicsSumViewModel.GetPoints( start: 0, count: 468, step: 0.1 );
        public bool IsCanDeleteHarmonic => Harmonics.Count > 0;
        public bool IsCanEditHarmonic => Harmonics.Count > 0;

        public MainFormViewModel()
        {
            OnHarmonicSumChange += () =>
            {
                OnPropertyChanged( "IsCanEditHarmonic" );
                OnPropertyChanged( "IsCanDeleteHarmonic" );
                IsCanEditHarmonicChanged?.Invoke();
            };
        }

        private void OnPropertyChanged( [CallerMemberName] string property = "" )
        {
            PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( property ) );
        }
    }
}
