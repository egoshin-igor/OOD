using System;
using System.Collections.Generic;
using System.ComponentModel;
using Chart.Models;
using Chart.Models.Harmonics;

namespace Chart.ViewModels
{
    class HarmonicsSumViewModel
    {
        private HarmonicsSum _harmonicsSum = new HarmonicsSum();
        private readonly int _pointsCount;
        private readonly double _stepBetweenPoints;

        public event Action OnHarmonicSumChange;

        public BindingList<HarmonicViewModel> HarmonicViewModels { get; } = new BindingList<HarmonicViewModel>();
        public List<Point> Points => _harmonicsSum.GetPoints( _pointsCount, _stepBetweenPoints );

        public HarmonicsSumViewModel( int pointsCount, double stepBetweenPoints )
        {
            HarmonicViewModels.ListChanged += OnHarmonicViewModelsChanging;
            _pointsCount = pointsCount;
            _stepBetweenPoints = stepBetweenPoints;
        }

        private void OnHarmonicViewModelsChanging( object sender, ListChangedEventArgs e )
        {
            switch ( e.ListChangedType )
            {
                case ListChangedType.ItemAdded:
                    var addedHarmonicViewModel = HarmonicViewModels[ e.NewIndex ];
                    _harmonicsSum.Harmonics.Add( addedHarmonicViewModel.Harmonic );
                    break;
                case ListChangedType.ItemDeleted:
                    _harmonicsSum.Harmonics.RemoveAt( e.NewIndex );
                    break;
            }
            OnHarmonicSumChange?.Invoke();
        }
    }
}
