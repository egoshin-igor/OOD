using System;

namespace Chart.ViewModels
{
    public class AlwaysEditableHarmonicPartViewViewModel : IHarmonicPartViewViewModel
    {
        public HarmonicViewModel SelectedHarmonic { get; set; }
        public bool IsCanEditHarmonic => true;
        public event Action IsCanEditHarmonicChanged;
    }
}
