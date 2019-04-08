using System;
using System.Globalization;
using Adapter.GraphicsLib;
using Adapter.ModernGrapicsLib;

namespace Adapter.Adapter
{
    public class ModernGrapicsObjectAdapter : ICanvas
    {
        private readonly ModernGraphicsRenderer _modernGraphicsRenderer;
        private Point _startPosition = new Point( 0, 0 );
        private RGBAColor _rgbaColor = new RGBAColor( 0, 0, 0, 0 );

        public ModernGrapicsObjectAdapter( ModernGraphicsRenderer modernGraphicsRenderer )
        {
            _modernGraphicsRenderer = modernGraphicsRenderer;
        }

        public void LineTo( int x, int y )
        {
            _modernGraphicsRenderer.BeginDraw();

            Point newPosition = new Point( x, y );
            _modernGraphicsRenderer.DrawLine( _startPosition, newPosition, _rgbaColor );
            _startPosition = newPosition;

            _modernGraphicsRenderer.EndDraw();
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
