using System;
using System.Drawing;

namespace Composite.Shape
{
    public class BaseStyle : IStyle
    {
        public bool IsEnabled { get; protected set; }
        public Color Color { get; set; }

        protected BaseStyle()
        {
        }

        public BaseStyle( Color color )
        {
            Color = color;
            IsEnabled = true;
        }

        public void Enable( bool enable )
        {
            IsEnabled = enable;
        }
    }
}
