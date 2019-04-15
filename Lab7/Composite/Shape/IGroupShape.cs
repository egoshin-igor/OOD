namespace Composite.Shape
{
    public interface IGroupShape : IShape
    {
        int ShapesCount { get; }
        IShape GetShapeAtIndex( int index );
        void InsertShape( IShape shape, int index );
        void RemoveShapeAtIndex( int index );
    }
}
