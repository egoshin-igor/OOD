using System.Collections.Generic;
using Lab4.Enum;
using Lab4.Shape;
using Lab4.Test.CanvasMock;
using Xunit;

namespace Lab4.Test.Shape
{
    public class RegularPolygonTest
    {
        [Fact]
        public void Draw()
        {
            // Arrange
            var canvasMock = new CanvasMock.Canvas();

            var center = new Point( 0, 0 );
            var vertexCount = 3;
            var radius = 2;


            var regularPolygon = new RegularPolygon( vertexCount, radius, center, ColorType.Blue );

            var expectedDrawedLines = new HashSet<Line>
            {
                new Line{ From = new Point(2, 0), To = new Point(-1, 1.732) },
                new Line{ From = new Point(-1, 1.732), To = new Point(-1, -1.732) },
                new Line{ From = new Point(-1, -1.732), To = new Point(2, 0) }
            };
            var expectedColor = ColorType.Blue;

            // Act
            regularPolygon.Draw( canvasMock );

            // Assert
            Assert.Equal( expectedColor, canvasMock.Color );
            Assert.Equal( expectedDrawedLines, canvasMock.LastDrawedLines );
        }
    }
}
