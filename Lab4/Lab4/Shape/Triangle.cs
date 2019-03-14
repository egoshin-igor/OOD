using Lab4.Canvas;
using Lab4.Enum;

namespace Lab4.Shape
{
    class Triangle : BaseShape
    {
        public Point Vertex1 { get; private set; }
        public Point Vertex2 { get; private set; }
        public Point Vertex3 { get; private set; }

        public Triangle( Point vertex1, Point vertex2, Point vertex3, ColorType color )
        {
            Vertex1 = vertex1;
            Vertex2 = vertex2;
            Vertex3 = vertex3;
            Color = color;
        }

        public override void Draw( ICanvas canvas )
        {
            canvas.Color = Color;
            canvas.DrawLine( Vertex1, Vertex2 );
            canvas.DrawLine( Vertex2, Vertex3 );
            canvas.DrawLine( Vertex3, Vertex1 );
        }
    }
}
