using System.Collections.Generic;
using System.Drawing;
using Lab4.Enum;
using Lab4.Shape;
using Lab4.Test.CanvasMock;
using Xunit;
using Rectangle = Lab4.Shape.Rectangle;

namespace Lab4.Test.Shape
{
    public class RectangleTest
    {
        [Fact]
        public void Draw()
        {
            // Arrange
            var canvasMock = new CanvasMock.Canvas();

            var leftTop = new Point( 0, 1 );
            var rightBottom = new Point( 1, 0 );
            var rightTop = new Point( rightBottom.X, leftTop.Y );
            var leftBottom = new Point( leftTop.X, rightBottom.Y );

            var rectangle = new Rectangle( leftTop, rightBottom, ColorType.Blue );

            var expectedDrawedLines = new HashSet<Line>
            {
                new Line{ From = leftTop, To = rightTop },
                new Line{ From = rightTop, To = rightBottom },
                new Line{ From = rightBottom, To = leftBottom },
                new Line{ From = leftBottom, To = leftTop }
            };
            var expectedColor = ColorType.Blue;

            // Act
            rectangle.Draw( canvasMock );

            // Assert
            Assert.Equal( expectedColor, canvasMock.Color );
            Assert.Equal( expectedDrawedLines, canvasMock.LastDrawedLines );
        }
    }
}
