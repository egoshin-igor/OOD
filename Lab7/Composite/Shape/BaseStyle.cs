using System;
using System.Drawing;

namespace Composite.Shape
{
    public class BaseStyle : IEquatable<BaseStyle>
    {
        private Color _color;

        public event Action OnColorChange;
        public event Action OnEnablingStateChange;

        public bool IsEnabled { get; protected set; }
        public Color Color
        {
            get => _color;
            set { _color = value; OnColorChange?.Invoke(); }
        }

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
            OnEnablingStateChange?.Invoke();
        }

        public BaseStyle Copy()
        {
            var copy = new BaseStyle
            {
                Color = this.Color,
                IsEnabled = this.IsEnabled
            };

            return copy;
        }

        public override bool Equals( object obj )
        {
            var style = obj as BaseStyle;

            return base.Equals( style );
        }

        public bool Equals( BaseStyle other )
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

        public override int GetHashCode()
        {
            return HashCode.Combine( _color, IsEnabled );
        }
    }
}
