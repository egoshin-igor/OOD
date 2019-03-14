namespace Lab4.Shape.Factory
{
    interface IShapeFactory
    {
        BaseShape CreateShape( string shapeDescription );
    }
}
