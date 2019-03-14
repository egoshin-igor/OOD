using Lab4.Canvas;
using Lab4.Designer;
using Lab4.Painter;
using Lab4.Shape.Factory;

namespace Lab4
{
    class Program
    {
        static void Main( string[] args )
        {
            IShapeFactory shapeFactory = new ShapeFactory();
            IDesigner designer = new Designer.Designer( shapeFactory );
            ICanvas canvas = new Canvas.Canvas();
            IPainter painter = new Painter.Painter();

            Client client = new Client( designer, painter, canvas );
            client.Run();
        }
    }
}
