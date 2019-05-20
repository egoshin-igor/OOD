using System;
using System.Collections.Generic;
using System.ComponentModel;
using Chart.Models;

namespace Chart.ViewModels
{
    public class MainFormViewModel
    {
        private readonly HarmonicsSumViewModel _harmonicsSumViewModel = new HarmonicsSumViewModel( 300, 0.1 );

        public BindingList<HarmonicViewModel> Harmonics => _harmonicsSumViewModel.HarmonicViewModels;
        public HarmonicViewModel SelectedHarmonic { get; set; }
        public List<Point> Points => _harmonicsSumViewModel.Points;

        public event Action OnHarmonicSumChange
        {
            add => _harmonicsSumViewModel.OnHarmonicSumChange += value;
            remove => _harmonicsSumViewModel.OnHarmonicSumChange -= value;
        }
    }
}
