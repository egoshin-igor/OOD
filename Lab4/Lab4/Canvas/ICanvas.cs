using Lab4.Enum;

namespace Lab4.Canvas
{
    interface ICanvas
    {
        ColorType Color { set; }
        void DrawLine( Point from, Point to );
        void DrawEllipse( Point center, double horizontalRadius, double verticalRadius );
    }
}
