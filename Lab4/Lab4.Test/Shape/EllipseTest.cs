using Lab4.Enum;
using Lab4.Shape;
using Xunit;

namespace Lab4.Test.Shape
{
    public class EllipseTest
    {
        [Fact]
        public void Draw()
        {
            // Arrange
            var canvasMock = new CanvasMock.Canvas();

            var center = new Point( 0, 0 );
            var horizontalRadius = 2d;
            var verticalRadius = 1d;

            var ellipse = new Ellipse( center, horizontalRadius, verticalRadius, ColorType.Black );

            var expectedDrawedEllipse = new CanvasMock.Ellipse
            {
                Center = center,
                HorizontalRadius = horizontalRadius,
                VerticalRadius = verticalRadius
            };
            var expectedColor = ColorType.Black;

            // Act
            ellipse.Draw( canvasMock );

            // Assert
            Assert.Equal( expectedColor, canvasMock.Color );
            Assert.Equal( expectedDrawedEllipse, canvasMock.LastDrawedEllipse );
        }
    }
}
