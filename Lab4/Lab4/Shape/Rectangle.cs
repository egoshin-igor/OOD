using Lab4.Canvas;
using Lab4.Enum;

namespace Lab4.Shape
{
    class Rectangle : BaseShape
    {
        public Point LeftTop { get; private set; }
        public Point RightBottom { get; private set; }

        public Rectangle( Point leftTop, Point rightBottom, ColorType color )
        {
            LeftTop = leftTop;
            RightBottom = rightBottom;
            Color = color;
        }

        public override void Draw( ICanvas canvas )
        {
            var rightTop = new Point( RightBottom.X, LeftTop.Y );
            var leftBottom = new Point( LeftTop.X, RightBottom.Y );

            canvas.Color = Color;
            canvas.DrawLine( LeftTop, rightTop );
            canvas.DrawLine( rightTop, RightBottom );
            canvas.DrawLine( RightBottom, leftBottom );
            canvas.DrawLine( leftBottom, LeftTop );
        }
    }
}
