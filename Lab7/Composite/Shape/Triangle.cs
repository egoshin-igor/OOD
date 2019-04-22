using System.Numerics;
using Composite.Canvas;

namespace Composite.Shape
{
    public class Triangle : BaseShape
    {
        public Triangle( Rect frame, LineStyle lineStyle = null, BaseStyle fillStyle = null )
            : base( frame, lineStyle, fillStyle )
        {
        }

        public override void Draw( ICanvas canvas )
        {
            SetStyles( canvas );
            var vertex1 = new Vector2( Frame.Left + Frame.Width / 2, Frame.Top );
            var vertex2 = new Vector2( Frame.Left, Frame.Top - Frame.Height );
            var vertex3 = new Vector2( Frame.Left + Frame.Width, Frame.Top - Frame.Height );

            canvas.DrawPolygon( new[] { vertex1, vertex2, vertex3 } );
        }
    }
}
