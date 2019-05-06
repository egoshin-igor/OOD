using System.Numerics;
using Composite.Canvas;

namespace Composite.Shape
{
    public class Rectangle : BaseShape
    {
        public Rectangle( Rect frame, ILineStyle lineStyle = null, IStyle fillStyle = null )
            : base( frame, lineStyle, fillStyle )
        {
        }

        public override void Draw( ICanvas canvas )
        {
            SetStyles( canvas );
            Rect frame = GetFrame().Value;

            Vector2 vertex1 = new Vector2( frame.Left, frame.Top );
            Vector2 vertex2 = new Vector2( frame.Left + frame.Width, frame.Top );
            Vector2 vertex3 = new Vector2( frame.Left + frame.Width, frame.Top - frame.Height );
            Vector2 vertex4 = new Vector2( frame.Left, frame.Top - frame.Height );

            canvas.DrawPolygon( new[] { vertex1, vertex2, vertex3, vertex4 } );
        }
    }
}
