using Composite.Canvas;
using Composite.Shape;

namespace Composite
{
    public class Slide
    {
        private readonly GroupShape _data = new GroupShape();

        public void Draw( ICanvas canvas )
        {
            _data.Draw( canvas );
        }

        public IShape GetShapeAtIndex( int index )
        {
            return _data.GetShapeAtIndex( index );
        }

        public void InsertShape( IShape shape, int index )
        {
            _data.InsertShape( shape, index );
        }

        public void RemoveShapeAtIndex( int index )
        {
            _data.RemoveShapeAtIndex( index );
        }
    }
}
