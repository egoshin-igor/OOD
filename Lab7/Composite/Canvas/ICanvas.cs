using System.Drawing;
using System.Numerics;

namespace Composite.Canvas
{
    public interface ICanvas
    {
        float LineThickness { set; }
        Color FillColor { set; }
        Color LineColor { set; }
        void DrawLine( Vector2 from, Vector2 to );
        void DrawEllipse( float left, float top, float width, float height );
        void DrawPolygon( Vector2[] points );
    }
}
