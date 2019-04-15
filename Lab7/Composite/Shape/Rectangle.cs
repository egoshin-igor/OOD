using System.Numerics;
using Composite.Canvas;

namespace Composite.Shape
{
    public class Rectangle : BaseShape
    {
        public Rectangle( Rect frame, LineStyle lineStyle, FillStyle fillStyle )
            : base( frame, lineStyle, fillStyle )
        {
        }

        public override void Draw( ICanvas canvas )
        {
            SetStyles( canvas );

            Vector2 vertex1 = new Vector2( Frame.Left, Frame.Top );
            Vector2 vertex2 = new Vector2( Frame.Left + Frame.Width, Frame.Top );
            Vector2 vertex3 = new Vector2( Frame.Left + Frame.Width, Frame.Top - Frame.Height );
            Vector2 vertex4 = new Vector2( Frame.Left, Frame.Top - Frame.Height );

            canvas.DrawPolygon( new[] { vertex1, vertex2, vertex3, vertex4 } );
        }
    }
}
