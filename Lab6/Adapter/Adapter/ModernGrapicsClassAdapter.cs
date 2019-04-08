using System;
using System.Globalization;
using System.IO;
using Adapter.GraphicsLib;
using Adapter.ModernGrapicsLib;

namespace Adapter.Adapter
{
    public class ModernGrapicsClassAdapter : ModernGraphicsRenderer, ICanvas
    {
        private Point _startPosition = new Point( 0, 0 );
        private RGBAColor _rgbaColor = new RGBAColor( 0, 0, 0, 0 );

        public ModernGrapicsClassAdapter( TextWriter output )
            : base( output )
        {
        }

        public void LineTo( int x, int y )
        {
            BeginDraw();

            Point newPosition = new Point( x, y );
            DrawLine( _startPosition, newPosition, _rgbaColor );
            _startPosition = newPosition;

            EndDraw();
        }

        public void MoveTo( int x, int y )
        {
            _startPosition = new Point( x, y );
        }

        public void SetColor( uint rgbColor )
        {
            string hex = rgbColor.ToString( "x6" );
            float r = ToRGBAColorPart( hex.Substring( 0, 2 ) );
            float g = ToRGBAColorPart( hex.Substring( 2, 2 ) );
            float b = ToRGBAColorPart( hex.Substring( 4, 2 ) );
            float a = 1;

            _rgbaColor = new RGBAColor( r, g, b, a );
        }

        private float ToRGBAColorPart( string colorPartString )
        {
            var colorPart = int.Parse( colorPartString, NumberStyles.AllowHexSpecifier );
            var result = ( ( double )colorPart ) / 255;

            return ( float )Math.Round( result, 2 );
        }
    }
}
