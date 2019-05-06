using Composite.Canvas;

namespace Composite.Shape
{
    public class Ellipse : BaseShape
    {
        public Ellipse( Rect frame, ILineStyle lineStyle = null, IStyle fillStyle = null )
            : base( frame, lineStyle, fillStyle )
        {
        }

        public override void Draw( ICanvas canvas )
        {
            SetStyles( canvas );
            Rect frame = GetFrame().Value;

            canvas.DrawEllipse( frame.Left, frame.Top, frame.Width, frame.Height );
        }
    }
}
