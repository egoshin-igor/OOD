using System.Drawing;
using Composite.Canvas;
using Composite.Shape;
using Rectangle = Composite.Shape.Rectangle;

namespace Composite
{
    public class Composite
    {
        public static void Main( string[] args )
        {
            var slide = new Slide( width: 100, height: 100 );
            var canvas = new TextCanvas();

            slide.BackgroundColor = Color.Beige;
            slide.InsertShape( GetRectangle(), 0 );
            slide.InsertShape( GetEllipse(), 1 );
            slide.InsertShape( GetTriangle(), 2 );

            slide.Draw( canvas );
        }

        public static Rectangle GetRectangle()
        {
            var frame = new Rect( left: 30, top: -30, width: 20, height: 30 );
            var lineStyle = new LineStyle( Color.Black, thickness: 1 );
            var fillStyle = new FillStyle( Color.Empty );

            return new Rectangle( frame, lineStyle, fillStyle );
        }

        public static Ellipse GetEllipse()
        {
            var frame = new Rect( left: 0, top: -100, width: 44, height: 42 );
            var lineStyle = new LineStyle( Color.Black, thickness: 2 );
            var fillStyle = new FillStyle( Color.Azure );

            return new Ellipse( frame, lineStyle, fillStyle );
        }

        public static Triangle GetTriangle()
        {
            var frame = new Rect( left: 61, top: -44, width: 11, height: 22 );
            var lineStyle = new LineStyle( Color.Black, thickness: 3 );
            var fillStyle = new FillStyle( Color.Empty );

            return new Triangle( frame, lineStyle, fillStyle );
        }
    }
}
