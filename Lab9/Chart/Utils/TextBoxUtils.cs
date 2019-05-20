using System.Drawing;
using System.Windows.Forms;

namespace Chart.Utils
{
    public static class TextBoxUtils
    {
        public static void ValidateDoubleInput( TextBox input )
        {
            const string defaultLabelValue = "0";

            if ( string.IsNullOrEmpty( input.Text ) )
            {
                input.Text = defaultLabelValue;
            }

            double? doubleValue = input.Text.AsDouble();
            if ( doubleValue != null )
            {
                input.BackColor = Color.White;
            }
            else
            {
                input.BackColor = Color.Red;
            }
        }
    }
}
