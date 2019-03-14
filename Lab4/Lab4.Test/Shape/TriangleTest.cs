using System.Collections.Generic;
using System.Drawing;
using Lab4.Enum;
using Lab4.Shape;
using Lab4.Test.CanvasMock;
using Xunit;

namespace Lab4.Test.Shape
{
    public class TriangleTest
    {
        [Fact]
        public void Draw()
        {
            // Arrange
            var canvasMock = new CanvasMock.Canvas();

            var vertex1 = new Point( 0, 0 );
            var vertex2 = new Point( 1, 0 );
            var vertex3 = new Point( 1, 1 );

            var triangle = new Triangle( vertex1, vertex2, vertex3, ColorType.Yellow );

            var expectedDrawedLines = new HashSet<Line>
            {
                new Line{ From = vertex1, To = vertex2 },
                new Line{ From = vertex2, To = vertex3 },
                new Line{ From = vertex3, To = vertex1 }
            };
            var expectedColor = ColorType.Yellow;

            // Act
            triangle.Draw( canvasMock );

            // Assert
            Assert.Equal( expectedColor, canvasMock.Color );
            Assert.Equal( expectedDrawedLines, canvasMock.LastDrawedLines );
        }
    }
}
