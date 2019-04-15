using System;
using System.Globalization;
using Adapter.ModernGrapicsLib;

namespace Adapter.Util
{
    public static class RGBAConverter
    {
        public static RGBAColor Convert( uint rgbColor )
        {
            string stringRgbColor = rgbColor.ToString( "x6" );
            float r = ToRGBAComponent( stringRgbColor.Substring( 0, 2 ) );
            float g = ToRGBAComponent( stringRgbColor.Substring( 2, 2 ) );
            float b = ToRGBAComponent( stringRgbColor.Substring( 4, 2 ) );
            float a = 1;

            return new RGBAColor( r, g, b, a );
        }

        private static float ToRGBAComponent( string rgbColorComponent )
        {
            var colorPart = int.Parse( rgbColorComponent, NumberStyles.AllowHexSpecifier );
            var result = ( ( double )colorPart ) / 255;

            return ( float )Math.Round( result, 2 );
        }
    }
}
