using System.Drawing;
using Composite.Canvas;
using Composite.Shape;
using Rectangle = Composite.Shape.Rectangle;

namespace Composite
{
    public class Slide
    {
        const int FirstShapeIndex = 1;

        private readonly GroupShape _data = new GroupShape();

        public Color BackgroundColor
        {
            get => _data.GetShapeAtIndex( 0 ).FillStyle.Color;
            set => _data.GetShapeAtIndex( 0 ).FillStyle = new FillStyle( value );
        }

        public Slide( float width, float height )
        {
            var frame = new Rect( left: 0, top: 0, width, height );
            var lineStyle = new LineStyle( Color.Empty, thickness: 0 );
            var fillStyle = new FillStyle( Color.Empty );
            var rectangle = new Rectangle( frame, lineStyle, fillStyle );

            _data.InsertShape( rectangle, index: 0 );
        }

        public void Draw( ICanvas canvas )
        {
            _data.Draw( canvas );
        }

        public IShape GetShapeAtIndex( int index )
        {
            return _data.GetShapeAtIndex( FirstShapeIndex + index );
        }

        public void InsertShape( IShape shape, int index )
        {
            _data.InsertShape( shape, FirstShapeIndex + index );
        }

        public void RemoveShapeAtIndex( int index )
        {
            _data.RemoveShapeAtIndex( FirstShapeIndex + index );
        }
    }
}
