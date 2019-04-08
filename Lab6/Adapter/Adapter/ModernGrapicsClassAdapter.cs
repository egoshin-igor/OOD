using System;
using System.IO;
using Adapter.GraphicsLib;
using Adapter.ModernGrapicsLib;

namespace Adapter.Adapter
{
    public class ModernGrapicsClassAdapter : ModernGraphicsRenderer, ICanvas
    {
        private Point _startPosition = new Point( 0, 0 );

        public ModernGrapicsClassAdapter( TextWriter output )
            : base( output )
        {
        }

        public void LineTo( int x, int y )
        {
            BeginDraw();

            Point newPosition = new Point( x, y );
            DrawLine( _startPosition, newPosition );
            _startPosition = newPosition;

            EndDraw();
        }

        public void MoveTo( int x, int y )
        {
            _startPosition = new Point( x, y );
        }
    }
}
