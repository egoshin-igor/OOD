using System.Drawing;
using Composite.Canvas;

namespace Composite.Shape
{
    public abstract class BaseShape : IShape
    {
        public Rect Frame { get; set; }
        public LineStyle LineStyle { get; set; }
        public FillStyle FillStyle { get; set; }

        protected BaseShape( Rect frame, LineStyle lineStyle, FillStyle fillStyle )
        {
            Frame = frame;
            LineStyle = lineStyle;
            FillStyle = fillStyle;
        }

        public abstract void Draw( ICanvas canvas );

        protected void SetStyles( ICanvas canvas )
        {
            canvas.LineColor = LineStyle != null && LineStyle.IsEnabled ? LineStyle.Color : Color.Empty;
            if ( LineStyle != null )
            {
                canvas.LineThickness = LineStyle.Thickness;
            }

            canvas.FillColor = FillStyle != null && FillStyle.IsEnabled ? FillStyle.Color : Color.Empty;
        }
    }
}
