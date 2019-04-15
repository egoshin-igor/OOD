using Command.Image;
using Xunit;

namespace Command.Test.Image
{
    public class ImageTest
    {
        [Fact]
        public void Resize_ResizeWidthAndHeight_CorrectSizes()
        {
            // Arrange
            IImage image = new Command.Image.Image( "", "", width: 1, height: 1 );
            int newHeight = 2;
            int newWidth = 2;

            // Act
            image.Resize( newWidth, newHeight );

            // Assert
            Assert.Equal( newWidth, image.Width );
            Assert.Equal( newHeight, image.Height );
        }

        [Fact]
        public void Resize_SizeMoreThanMax_SetMaxSizes()
        {
            // Arrange
            IImage image = new Command.Image.Image( "", "", width: 1, height: 1 );
            int newHeight = 11111111;
            int newWidth = 11111111;
            int maxWidth = 10000;
            int maxHeight = 10000;

            // Act
            image.Resize( newWidth, newHeight );

            // Assert
            Assert.Equal( maxWidth, image.Width );
            Assert.Equal( maxHeight, image.Height );
        }
    }
}
