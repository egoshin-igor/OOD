using System.Numerics;
using Composite.Canvas;

namespace Composite.Shape
{
    public class Triangle : BaseShape
    {
        public Triangle( Rect frame, ILineStyle lineStyle = null, IStyle fillStyle = null )
            : base( frame, lineStyle, fillStyle )
        {
        }

        public override void Draw( ICanvas canvas )
        {
            SetStyles( canvas );
            Rect frame = GetFrame().Value;

            var vertex1 = new Vector2( frame.Left + frame.Width / 2, frame.Top );
            var vertex2 = new Vector2( frame.Left, frame.Top - frame.Height );
            var vertex3 = new Vector2( frame.Left + frame.Width, frame.Top - frame.Height );

            canvas.DrawPolygon( new[] { vertex1, vertex2, vertex3 } );
        }
    }
}
