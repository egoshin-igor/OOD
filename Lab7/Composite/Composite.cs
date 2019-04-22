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
            var slide = new Slide();
            var canvas = new GrapicalCanvas( width: 1000, height: 1000 );
            InsertTractor( slide );
            InsertField( slide );
            InsertSun( slide );

            slide.Draw( canvas );
            canvas.Save( "../../../image.png" );
        }

        public static void InsertTractor( Slide slide )
        {
            var frame = new Rect( left: 50, top: 900, width: 350, height: 130 );
            var lineStyle = new LineStyle( Color.Black, thickness: 3 );
            var fillStyle = new BaseStyle( Color.Blue );

            slide.InsertShape( new Rectangle( frame, lineStyle, fillStyle ), 0 );

            fillStyle = new BaseStyle( Color.Black );
            frame = new Rect( left: 55, top: 940, width: 70, height: 70 );
            slide.InsertShape( new Ellipse( frame, lineStyle, fillStyle ), 0 );
            frame = new Rect( left: 325, top: 940, width: 70, height: 70 );
            slide.InsertShape( new Ellipse( frame, lineStyle, fillStyle ), 0 );

            frame = new Rect( left: 55, top: 770, width: 20, height: 70 );
            slide.InsertShape( new Rectangle( frame, lineStyle, fillStyle ), 0 );

            fillStyle = new BaseStyle( Color.Empty );
            lineStyle = new LineStyle( Color.Black, thickness: 6 );
            frame = new Rect( left: 268.5f, top: 770, width: 130, height: 100 );
            slide.InsertShape( new Rectangle( frame, lineStyle, fillStyle ), 0 );
        }

        public static void InsertField( Slide slide )
        {
            var frame = new Rect( left: 0, top: 1000, width: 1000, height: 250 );
            var lineStyle = new LineStyle( Color.Green, thickness: 0 );
            var fillStyle = new BaseStyle( Color.Green );

            slide.InsertShape( new Rectangle( frame, lineStyle, fillStyle ), 0 );
        }

        public static void InsertSun( Slide slide )
        {
            var frame = new Rect( left: 900, top: 100, width: 100, height: 100 );
            var lineStyle = new LineStyle( Color.Yellow, thickness: 0 );
            var fillStyle = new BaseStyle( Color.Yellow );

            slide.InsertShape( new Ellipse( frame, lineStyle, fillStyle ), 0 );
        }
    }
}
