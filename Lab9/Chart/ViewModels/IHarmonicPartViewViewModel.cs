
using System;

namespace Chart.ViewModels
{
    public interface IHarmonicPartViewViewModel
    {
        event Action IsCanEditHarmonicChanged;
        HarmonicViewModel SelectedHarmonic { get; }
        bool IsCanEditHarmonic { get; }
    }
}
