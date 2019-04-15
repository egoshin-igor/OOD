using System;

namespace Composite.Shape
{
    public class Rect : IEquatable<Rect>
    {
        public float Left { get; }
        public float Top { get; }
        public float Width { get; }
        public float Height { get; }

        public Rect( float left, float top, float width, float height )
        {
            Left = left;
            Top = top;
            Width = width;
            Height = height;
        }

        public override bool Equals( object obj )
        {
            var rect = obj as Rect;

            return base.Equals( rect );
        }

        public bool Equals( Rect other )
        {
            if ( other == null )
            {
                return false;
            }

            if ( this == other )
            {
                return true;
            }

            return Left == other.Left &&
                Top == other.Top &&
                Width == other.Width &&
                Height == other.Height;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine( Left, Top, Width, Height );
        }
    }
}
