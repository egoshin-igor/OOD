using Composite.Canvas;

namespace Composite.Shape
{
    public interface IShape
    {
        Rect Frame { get; set; }
        LineStyle LineStyle { get; }
        BaseStyle FillStyle { get; }
        void Draw( ICanvas canvas );
    }
}
