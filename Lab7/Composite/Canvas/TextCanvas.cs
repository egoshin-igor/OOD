using System;
using System.Drawing;
using System.Numerics;

namespace Composite.Canvas
{
    class TextCanvas : ICanvas
    {
        float _lineThickness = 1;
        Color _fillColor = Color.Empty;
        Color _lineColor = Color.Black;

        public float LineThickness
        {
            get => _lineThickness;
            set
            {
                _lineThickness = value;
                Console.WriteLine( $"Line thickness: {value}" );
            }
        }
        public Color FillColor
        {
            get => _fillColor;
            set
            {
                _fillColor = value;
                Console.WriteLine( $"Fill color: {_fillColor.ToString()}" );
            }
        }
        public Color LineColor
        {
            get => _lineColor;
            set
            {
                _lineColor = value;
                Console.WriteLine( $"Line color: {_lineColor.ToString()}" );
            }
        }

        public void DrawEllipse( float left, float top, float width, float height )
        {
            Console.WriteLine( $"Draw ellipse. left:{left}, top: {top}, width:{width}, height:{height}" );
        }

        public void DrawLine( Vector2 from, Vector2 to )
        {
            Console.WriteLine( $"Draw line. from point:{from.X}, {from.Y}; to point: {to.X}, {to.Y}" );
        }

        public void DrawPolygon( Vector2[] points )
        {
            const int minPointsCount = 3;

            if ( points.Length < minPointsCount )
            {
                throw new ApplicationException( $"Polygon drawing requires {minPointsCount} points" );
            }

            Console.WriteLine( "Draw polygon. Points: " );
            foreach ( Vector2 point in points )
            {
                Console.WriteLine( $"({point.X}, {point.Y})" );
            }
        }
    }
}
