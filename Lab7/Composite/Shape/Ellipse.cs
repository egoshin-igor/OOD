using Composite.Canvas;

namespace Composite.Shape
{
    public class Ellipse : BaseShape
    {
        public Ellipse( Rect frame, LineStyle lineStyle, FillStyle fillStyle )
            : base( frame, lineStyle, fillStyle )
        {
        }

        public override void Draw( ICanvas canvas )
        {
            SetStyles( canvas );

            canvas.DrawEllipse( Frame.Left, Frame.Top, Frame.Width, Frame.Height );
        }
    }
}
