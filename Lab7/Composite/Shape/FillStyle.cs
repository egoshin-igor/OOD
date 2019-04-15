using System;
using System.Drawing;

namespace Composite.Shape
{
    public class FillStyle : IEquatable<FillStyle>
    {
        public bool IsEnabled { get; private set; }
        public Color Color { get; set; }

        public FillStyle( Color color )
        {
            Color = color;
            IsEnabled = true;
        }

        public void Enable()
        {
            IsEnabled = true;
        }

        public FillStyle Copy()
        {
            var copy = new FillStyle( Color )
            {
                IsEnabled = this.IsEnabled
            };

            return copy;
        }

        public bool Equals( FillStyle other )
        {
            if ( other == null )
            {
                return false;
            }

            if ( this == other )
            {
                return true;
            }

            return Color == other.Color && IsEnabled == other.IsEnabled;
        }
    }
}
