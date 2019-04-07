using Command.Document;
using Command.Document.Command;
using Command.Document.Item;
using Command.Image;
using Moq;
using Xunit;

namespace Command.Test.Document.Command
{
    public class ResizeImageCommandTest
    {
        readonly Mock<IDocument> _documentMock;

        public ResizeImageCommandTest()
        {
            _documentMock = new Mock<IDocument>();
        }

        [Fact]
        public void Execute_GetItemAndResizeImage()
        {
            // Arrange
            var imageDocumentItem = new DocumentItem( new Image.Image( "", "", 1, 1 ) );

            _documentMock.Setup( d => d.GetItem( It.IsAny<int>() ) ).Returns( imageDocumentItem );
            ICommand command = new ResizeImageCommand( 1, 2, 2, _documentMock.Object );

            // Act
            command.Execute();

            // Assert
            Assert.Equal( 2, imageDocumentItem.Image.Width );
            Assert.Equal( 2, imageDocumentItem.Image.Height );
        }

        [Fact]
        public void Unexecute_ReturnOriginTextValue()
        {
            // Arrange
            var imageDocumentItem = new DocumentItem( new Image.Image( "", "", 1, 1 ) );

            _documentMock.Setup( d => d.GetItem( It.IsAny<int>() ) ).Returns( imageDocumentItem );
            ICommand command = new ResizeImageCommand( 1, 2, 2, _documentMock.Object );
            command.Execute();

            // Act
            command.Unexecute();

            // Assert
            Assert.Equal( 1, imageDocumentItem.Image.Width );
            Assert.Equal( 1, imageDocumentItem.Image.Height );
        }
    }
}
