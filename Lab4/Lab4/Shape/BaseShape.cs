using Lab4.Canvas;
using Lab4.Enum;

namespace Lab4.Shape
{
    abstract class BaseShape
    {
        public ColorType Color { get; protected set; }
        public abstract void Draw( ICanvas canvas );
    }
}
