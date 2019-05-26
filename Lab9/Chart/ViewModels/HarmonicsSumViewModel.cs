using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Chart.Models;
using Chart.Models.Harmonics;

namespace Chart.ViewModels
{
    class HarmonicsSumViewModel
    {
        private HarmonicsSum _harmonicsSum = new HarmonicsSum();

        public event Action OnHarmonicSumChange;

        public BindingList<HarmonicViewModel> HarmonicViewModels { get; }

        public HarmonicsSumViewModel()
        {
            HarmonicViewModels = new BindingList<HarmonicViewModel>();
            HarmonicViewModels.ListChanged += OnHarmonicViewModelsChanging;
        }

        public List<Point> GetPoints( double start, int count, double step )
        {
            var result = new List<Point>();

            for ( int i = 0; i < count; i++ )
            {
                double t = start + step * i;
                double y = _harmonicsSum.GetValueByTime( t );

                result.Add( new Point( t, y ) );
            }

            return result;
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
                case ListChangedType.ItemChanged:
                    var changedHarmonicViewModel = HarmonicViewModels[ e.NewIndex ];
                    _harmonicsSum.Harmonics[ e.NewIndex ] = changedHarmonicViewModel.Harmonic;
                    break;
                case ListChangedType.Reset:
                    _harmonicsSum.Harmonics.Clear();
                    _harmonicsSum.Harmonics.AddRange( HarmonicViewModels.Select( v => v.Harmonic ) );
                    break;
                default:
                    break;
            }
            OnHarmonicSumChange?.Invoke();
        }
    }
}
