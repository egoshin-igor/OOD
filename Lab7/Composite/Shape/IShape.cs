using Composite.Canvas;

namespace Composite.Shape
{
    public interface IShape
    {
        Rect? GetFrame();
        void SetFrame( Rect rect );
        ILineStyle LineStyle { get; }
        IStyle FillStyle { get; }
        void Draw( ICanvas canvas );
    }
}
