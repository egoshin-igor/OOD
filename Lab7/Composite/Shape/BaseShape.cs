using System.Drawing;
using Composite.Canvas;

namespace Composite.Shape
{
    public abstract class BaseShape : IShape
    {
        private Rect _frame;
        public ILineStyle LineStyle { get; }
        public IStyle FillStyle { get; }

        protected BaseShape( Rect frame, ILineStyle lineStyle = null, IStyle fillStyle = null )
        {
            _frame = frame;
            LineStyle = lineStyle ?? new LineStyle( Color.Empty, thickness: 0 );
            FillStyle = fillStyle ?? new BaseStyle( Color.Empty );
        }

        public abstract void Draw( ICanvas canvas );

        protected void SetStyles( ICanvas canvas )
        {
            canvas.LineColor = LineStyle.IsEnabled ? LineStyle.Color : Color.Empty;
            canvas.LineThickness = LineStyle.Thickness;
            canvas.FillColor = FillStyle.IsEnabled ? FillStyle.Color : Color.Empty;
        }

        public Rect? GetFrame() => _frame;
        public void SetFrame( Rect frame ) => _frame = frame;
    }
}
