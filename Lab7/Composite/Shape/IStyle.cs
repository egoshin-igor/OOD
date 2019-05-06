using System.Drawing;

namespace Composite.Shape
{
    public interface IStyle
    {
        bool IsEnabled { get; }
        Color Color { get; set; }
        void Enable( bool enable );
    }
}
