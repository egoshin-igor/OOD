using System.Drawing;
using Composite.Canvas;

namespace Composite.Shape
{
    public abstract class BaseShape : IShape
    {
        public Rect Frame { get; set; }
        public LineStyle LineStyle { get; }
        public BaseStyle FillStyle { get; }

        protected BaseShape( Rect frame, LineStyle lineStyle = null, BaseStyle fillStyle = null )
        {
            Frame = frame;
            LineStyle = lineStyle?.Copy() ?? new LineStyle( Color.Empty, thickness: 0 );
            FillStyle = fillStyle?.Copy() ?? new BaseStyle( Color.Empty );
        }

        public abstract void Draw( ICanvas canvas );

        protected void SetStyles( ICanvas canvas )
        {
            canvas.LineColor = LineStyle.IsEnabled ? LineStyle.Color : Color.Empty;
            canvas.LineThickness = LineStyle.Thickness;
            canvas.FillColor = FillStyle.IsEnabled ? FillStyle.Color : Color.Empty;
        }
    }
}
