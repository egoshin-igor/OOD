using System;

namespace Lab4
{
    class Point : IEquatable<Point>
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public Point( double x, double y )
        {
            X = x;
            Y = y;
        }

        public override bool Equals( object obj )
        {
            var other = obj as Point;
            if ( other is null )
            {
                return false;
            }

            return Equals( other );
        }

        public bool Equals( Point other )
        {
            const double e = 0.001;
            if ( other is null )
            {
                return false;
            }

            return Math.Abs( X - other.X ) <= e && Math.Abs( Y - other.Y ) <= e;
        }

        public override int GetHashCode()
        {
            return ( int )( X * 12344214214 + Y * 12344214 );
        }

        public static bool operator ==( Point first, Point second )
        {
            return first?.Equals( second ) ?? false;
        }

        public static bool operator !=( Point first, Point second )
        {
            if ( first is null )
            {
                return false;
            }

            return !( first == second );
        }
    }
}
