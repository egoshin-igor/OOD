using System;
using System.Collections.Generic;
using System.Text;
using Lab4.Enum;
using Lab4.Shape;
using Lab4.Shape.Factory;
using Xunit;

namespace Lab4.Test
{
    public class ShapeFactoryTest
    {
        readonly ShapeFactory _shapeFactory = new ShapeFactory();

        [Fact]
        public void CreateShape_TriangleDescription_ReturnCorrectTriangle()
        {
            // Arrange
            string shapeDescription = "Triangle red 0 0 1 0 1 1";

            // Act
            BaseShape result = _shapeFactory.CreateShape( shapeDescription );
            Triangle triangle = result as Triangle;

            // Assert
            Assert.NotNull( triangle );
            Assert.Equal( ColorType.Red, triangle.Color );
            Assert.Equal( new Point( 0, 0 ), triangle.Vertex1 );
            Assert.Equal( new Point( 1, 0 ), triangle.Vertex2 );
            Assert.Equal( new Point( 1, 1 ), triangle.Vertex3 );
        }

        [Fact]
        public void CreateShape_RegularPolygonDescription_ReturnCorrectRegularPolygon()
        {
            // Arrange
            string shapeDescription = "RegularPolygon yellow 3 2 0 0";

            // Act
            BaseShape result = _shapeFactory.CreateShape( shapeDescription );
            RegularPolygon regularPolygon = result as RegularPolygon;

            // Assert
            Assert.NotNull( regularPolygon );
            Assert.Equal( ColorType.Yellow, regularPolygon.Color );
            Assert.Equal( new Point( 0, 0 ), regularPolygon.Center );
            Assert.Equal( 2, regularPolygon.Radius );
            Assert.Equal( 3, regularPolygon.VertexCount );
        }

        [Fact]
        public void CreateShape_RectangleDescription_ReturnCorrectRectangle()
        {
            // Arrange
            string shapeDescription = "Rectangle yellow 0 2 2 0";

            // Act
            BaseShape result = _shapeFactory.CreateShape( shapeDescription );
            Rectangle rectangle = result as Rectangle;

            // Assert
            Assert.NotNull( rectangle );
            Assert.Equal( ColorType.Yellow, rectangle.Color );
            Assert.Equal( new Point( 0, 2 ), rectangle.LeftTop );
            Assert.Equal( new Point( 2, 0 ), rectangle.RightBottom );
        }

        [Fact]
        public void CreateShape_EllipseDescription_ReturnCorrectEllipse()
        {
            // Arrange
            string shapeDescription = "Ellipse yellow 0 2 3 2";

            // Act
            BaseShape result = _shapeFactory.CreateShape( shapeDescription );
            Ellipse ellipse = result as Ellipse;

            // Assert
            Assert.NotNull( ellipse );
            Assert.Equal( ColorType.Yellow, ellipse.Color );
            Assert.Equal( new Point( 0, 2 ), ellipse.Center );
            Assert.Equal( 3, ellipse.HorizontalRadius );
            Assert.Equal( 2, ellipse.VerticalRadius );
        }
    }
}
