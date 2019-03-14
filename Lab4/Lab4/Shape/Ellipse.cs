using Lab4.Canvas;
using Lab4.Enum;

namespace Lab4.Shape
{
    class Ellipse : BaseShape
    {
        public Point Center { get; private set; }
        public double HorizontalRadius { get; private set; }
        public double VerticalRadius { get; private set; }

        public Ellipse( Point center, double horizontalRadius, double verticalRadius, ColorType color )
        {
            Center = center;
            HorizontalRadius = horizontalRadius;
            VerticalRadius = verticalRadius;
            Color = color;
        }

        public override void Draw( ICanvas canvas )
        {
            canvas.Color = Color;
            canvas.DrawEllipse( Center, HorizontalRadius, VerticalRadius );
        }
    }
}
