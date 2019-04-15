using Command.Document.Item;
using Command.Image;
using Command.Paragraph;
using Xunit;
using ImageClass = Command.Image.Image;

namespace Command.Test.Document.Item
{
    public class DocumentItemTest
    {
        [Fact]
        public void GetDescription_ParagraphDescription_GetParagraphDescription()
        {
            // Arrange
            IParagraph paragraph = new Paragraph.Paragraph( "text" );
            var documentItem = new DocumentItem( paragraph );

            // Act
            string description = documentItem.GetDescription();

            // Assert
            Assert.Equal( expected: "Paragraph: text", description );
        }

        [Fact]
        public void GetDescription_ImageDescription_GetImageDescription()
        {
            // Arrange
            IImage image = new ImageClass( "path", ".html", 1, 1 );
            var documentItem = new DocumentItem( image );

            // Act
            string description = documentItem.GetDescription();

            // Assert
            Assert.Equal( expected: "Image: 1 1 path", description );
        }
    }
}
