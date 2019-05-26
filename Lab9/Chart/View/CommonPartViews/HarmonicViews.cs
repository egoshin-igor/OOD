using System.Windows.Forms;

namespace Chart.View.CommonPartViews
{
    public class HarmonicViews
    {
        public TextBox FrequencyInput { get; }
        public TextBox AmplitudeInput { get; }
        public TextBox PhaseInput { get; }
        public RadioButton SinRadioButton { get; }
        public RadioButton CosRadioButton { get; }

        public HarmonicViews(
            TextBox frequencyInput,
            TextBox amplitudeInput,
            TextBox phaseInput,
            RadioButton sinRadioButton,
            RadioButton cosRadioButton
            )
        {
            FrequencyInput = frequencyInput;
            AmplitudeInput = amplitudeInput;
            PhaseInput = phaseInput;
            SinRadioButton = sinRadioButton;
            CosRadioButton = cosRadioButton;
        }
    }
}
