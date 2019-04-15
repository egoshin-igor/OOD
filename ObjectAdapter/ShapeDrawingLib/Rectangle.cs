using ObjectAdapter.GraphicsLib;

namespace ObjectAdapter.ShapeDrawingLib
{
    public class Rectangle : ICanvasDrawable
    {
        private Point _leftTop;
        private int _width;
        private int _height;

        public Rectangle( Point leftTop, int width, int height )
        {
            _leftTop = leftTop;
            _width = width;
            _height = height;
        }

        public void Draw( ICanvas canvas )
        {
            canvas.MoveTo( _leftTop.X, _leftTop.Y );

            canvas.LineTo( _leftTop.X + _width, _leftTop.Y );
            canvas.LineTo( _leftTop.X + _width, _leftTop.Y + _height );
            canvas.LineTo( _leftTop.X, _leftTop.Y + _height );
            canvas.LineTo( _leftTop.X, _leftTop.Y );
        }
    }
}
