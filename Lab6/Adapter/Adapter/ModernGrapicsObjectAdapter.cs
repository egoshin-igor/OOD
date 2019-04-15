using System;
using System.Globalization;
using Adapter.GraphicsLib;
using Adapter.ModernGrapicsLib;
using Adapter.Util;

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
            Point newPosition = new Point( x, y );
            _modernGraphicsRenderer.DrawLine( _startPosition, newPosition, _rgbaColor );
            _startPosition = newPosition;
        }

        public void MoveTo( int x, int y )
        {
            _startPosition = new Point( x, y );
        }

        public void SetColor( uint rgbColor )
        {
            _rgbaColor = RGBAConverter.Convert( rgbColor );
        }

        public void BeginDraw()
        {
            _modernGraphicsRenderer.BeginDraw();
        }

        public void EndDraw()
        {
            _modernGraphicsRenderer.EndDraw();
        }

        private float ToRGBAColorPart( string hexColorPart )
        {
            var colorPart = int.Parse( hexColorPart, NumberStyles.AllowHexSpecifier );
            var result = ( ( double )colorPart ) / 255;

            return ( float )Math.Round( result, 2 );
        }
    }
}
