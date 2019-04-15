using System;
using System.Drawing;

namespace Composite.Shape
{
    public class LineStyle : IEquatable<LineStyle>
    {
        public bool IsEnabled { get; private set; }
        public Color Color { get; set; }
        public float Thickness { get; set; }

        public LineStyle( Color color, float thickness )
        {
            Color = color;
            Thickness = thickness;
            IsEnabled = true;
        }

        public void Enable()
        {
            IsEnabled = true;
        }

        public LineStyle Copy()
        {
            var copy = new LineStyle( Color, Thickness )
            {
                IsEnabled = this.IsEnabled
            };

            return copy;
        }

        public bool Equals( LineStyle other )
        {
            if ( other == null )
            {
                return false;
            }

            if ( this == other )
            {
                return true;
            }

            return Color == other.Color && IsEnabled == other.IsEnabled && Thickness == other.Thickness;
        }
    }
}
