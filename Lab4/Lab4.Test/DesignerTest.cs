using System.Collections.Generic;
using Lab4.Shape;
using Lab4.Shape.Factory;
using Xunit;

namespace Lab4.Test
{
    public class DesignerTest
    {
        [Fact]
        public void CreateDraft()
        {
            // Arrange
            IShapeFactory shapeFactory = new ShapeFactory();
            var designer = new Designer.Designer( shapeFactory );

            var shapeDecriptions = new List<string>
            {
                "Triangle red 0 0 1 0 1 1",
                "RegularPolygon yellow 3 2 0 0"
            };

            // Act
            PictureDraft draft = designer.CreateDraft( shapeDecriptions );
            List<BaseShape> shapes = draft?.Shapes;

            // Assert
            Assert.NotNull( shapes );
            Assert.Equal( 2, draft.Shapes.Count );
            Assert.Contains( shapes, s => s.GetType() == typeof( Triangle ) );
            Assert.Contains( shapes, s => s.GetType() == typeof( RegularPolygon ) );
        }
    }
}
