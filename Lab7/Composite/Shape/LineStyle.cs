using System.Drawing;

namespace Composite.Shape
{
    public class LineStyle : BaseStyle, ILineStyle
    {
        public float Thickness { get; set; }

        private LineStyle()
        {
        }

        public LineStyle( Color color, float thickness )
            : base( color )
        {
            Thickness = thickness;
        }
    }
}
