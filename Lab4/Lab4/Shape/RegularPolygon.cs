using System;
using Lab4.Canvas;
using Lab4.Enum;

namespace Lab4.Shape
{
    class RegularPolygon : BaseShape
    {
        public int VertexCount { get; private set; }
        public double Radius { get; private set; }
        public Point Center { get; private set; }

        public RegularPolygon( int vertexCount, double radius, Point center, ColorType color )
        {
            const int minPossibleVertexes = 3;

            if ( vertexCount < minPossibleVertexes )
            {
                throw new ApplicationException( $"Vertex count must be more or equal {minPossibleVertexes} on RegualarPolygon" );
            }

            VertexCount = vertexCount;
            Radius = radius;
            Center = center;
            Color = color;
        }

        public override void Draw( ICanvas canvas )
        {
            canvas.Color = Color;
            for ( int i = 1; i <= VertexCount; i++ )
            {
                Point from = GetPointByVertexNumber( i - 1 );
                Point to = GetPointByVertexNumber( i );
                canvas.DrawLine( from, to );
            }
        }

        private Point GetPointByVertexNumber( int vertexNumber )
        {
            var angleOnRadian = 2 * Math.PI * vertexNumber / VertexCount;

            double xCoord = Math.Cos( angleOnRadian ) * Radius + Center.X;
            double yCoord = Math.Sin( angleOnRadian ) * Radius + Center.Y;

            return new Point( xCoord, yCoord );
        }
    }
}
