using Adapter.GraphicsLib;

namespace Adapter.ShapeDrawingLib
{
    public class Rectangle : ICanvasDrawable
    {
        private Point _leftTop;
        private int _width;
        private int _height;
        private uint _rgbColor;

        public Rectangle( Point leftTop, int width, int height, uint rgbColor )
        {
            _leftTop = leftTop;
            _width = width;
            _height = height;
            _rgbColor = rgbColor;
        }

        public void Draw( ICanvas canvas )
        {
            canvas.SetColor( _rgbColor );
            canvas.MoveTo( _leftTop.X, _leftTop.Y );

            canvas.LineTo( _leftTop.X + _width, _leftTop.Y );
            canvas.LineTo( _leftTop.X + _width, _leftTop.Y + _height );
            canvas.LineTo( _leftTop.X, _leftTop.Y + _height );
            canvas.LineTo( _leftTop.X, _leftTop.Y );
        }
    }
}
