using Composite.Canvas;

namespace Composite.Shape
{
    public interface IShape
    {
        Rect Frame { get; set; }
        LineStyle LineStyle { get; set; } // TODO: У стилей не должно быть сеттеров
        FillStyle FillStyle { get; set; }
        void Draw( ICanvas canvas );
    }
}
