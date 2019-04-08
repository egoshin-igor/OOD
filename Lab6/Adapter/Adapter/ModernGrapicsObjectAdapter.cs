using Adapter.GraphicsLib;
using Adapter.ModernGrapicsLib;

namespace Adapter.Adapter
{
    public class ModernGrapicsObjectAdapter : ICanvas
    {
        private readonly ModernGraphicsRenderer _modernGraphicsRenderer;
        private Point _startPosition = new Point( 0, 0 );

        public ModernGrapicsObjectAdapter( ModernGraphicsRenderer modernGraphicsRenderer )
        {
            _modernGraphicsRenderer = modernGraphicsRenderer;
        }

        public void LineTo( int x, int y )
        {
            _modernGraphicsRenderer.BeginDraw();

            Point newPosition = new Point( x, y );
            _modernGraphicsRenderer.DrawLine( _startPosition, newPosition );
            _startPosition = newPosition;

            _modernGraphicsRenderer.EndDraw();
        }

        public void MoveTo( int x, int y )
        {
            _startPosition = new Point( x, y );
        }
    }
}
