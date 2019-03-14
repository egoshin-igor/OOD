using System;
using Lab4.Enum;

namespace Lab4.Canvas
{
    class Canvas : ICanvas
    {
        private const int Precision = 2;

        public ColorType Color { private get; set; }

        public void DrawEllipse( Point center, double horizontalRadius, double verticalRadius )
        {
            Console.Write( $"Color: {Color.ToString()}. " );
            Console.WriteLine( $"Ellipse. center: {Math.Round( center.X, Precision )}, {Math.Round( center.Y, Precision )}. " +
                $"Radius: H: {Math.Round( horizontalRadius, Precision )}, V: {Math.Round( verticalRadius, Precision )}" );
        }

        public void DrawLine( Point from, Point to )
        {
            Console.Write( $"Color: {Color.ToString()}. " );
            Console.WriteLine( $"Line. From point: {Math.Round( from.X, Precision )}, {Math.Round( from.Y, Precision )} " +
                $"To point: {Math.Round( to.X, Precision )}, {Math.Round( to.Y, Precision )}" );
        }
    }
}
