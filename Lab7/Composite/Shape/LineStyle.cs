using System;
using System.Drawing;

namespace Composite.Shape
{
    public class LineStyle : BaseStyle
    {
        private float _thickness;

        public event Action OnThicknessChange;

        public float Thickness
        {
            get => _thickness;
            set
            {
                _thickness = value;
                OnThicknessChange?.Invoke();
            }
        }

        private LineStyle()
        {
        }

        public LineStyle( Color color, float thickness )
            : base( color )
        {
            Thickness = thickness;
        }

        public new LineStyle Copy()
        {
            var copy = new LineStyle
            {
                Color = this.Color,
                IsEnabled = this.IsEnabled,
                Thickness = this.Thickness
            };

            return copy;
        }

        public override bool Equals( object obj )
        {
            var style = obj as LineStyle;

            return base.Equals( style );
        }

        public bool Equals( LineStyle other )
        {
            return base.Equals( other ) && Thickness == other.Thickness;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine( base.GetHashCode(), _thickness );
        }
    }
}
