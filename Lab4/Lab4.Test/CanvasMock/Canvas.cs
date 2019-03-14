using System.Collections.Generic;
using Lab4.Canvas;
using Lab4.Enum;

namespace Lab4.Test.CanvasMock
{
    class Canvas : ICanvas
    {
        public Ellipse LastDrawedEllipse { get; private set; }
        public HashSet<Line> LastDrawedLines { get; private set; } = new HashSet<Line>();
        public ColorType Color { get; set; }

        public void DrawEllipse( Point center, double horizontalRadius, double verticalRadius )
        {
            LastDrawedEllipse = new Ellipse
            {
                Center = center,
                HorizontalRadius = horizontalRadius,
                VerticalRadius = verticalRadius
            };
        }

        public void DrawLine( Point from, Point to )
        {
            LastDrawedLines.Add( new Line { From = from, To = to } );
        }
    }
}
