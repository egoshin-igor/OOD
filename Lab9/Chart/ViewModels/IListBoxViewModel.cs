using System.ComponentModel;

namespace Chart.ViewModels
{
    public interface IListBoxViewModel
    {
        HarmonicViewModel SelectedHarmonic { get; set; }
        BindingList<HarmonicViewModel> Harmonics { get; }
        bool IsCanDeleteHarmonic { get; }
    }
}
