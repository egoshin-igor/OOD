using System.Globalization;

namespace Chart.Utils
{
    public static class StringParserExtensions
    {
        public static double? AsDouble( this string str )
        {
            double result;
            if ( double.TryParse( str, NumberStyles.Float, new CultureInfo( "ru-Ru" ), out result ) ||
                 double.TryParse( str, NumberStyles.Float, CultureInfo.InvariantCulture, out result ) )
            {
                return result;
            }

            return null;
        }
    }
}
