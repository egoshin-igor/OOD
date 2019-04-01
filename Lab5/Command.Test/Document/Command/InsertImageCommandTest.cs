using Command.Document;
using Command.Document.Command;
using Command.Document.Item;
using Command.Image;
using Moq;
using Xunit;

namespace Command.Test.Document.Command
{
    public class InsertImageCommandTest
    {
        readonly Mock<IDocument> _documentMock;

        public InsertImageCommandTest()
        {
            _documentMock = new Mock<IDocument>();
        }

        [Fact]
        public void Execute_InsertImageInvoked()
        {
            // Arrange
            var imageDocumentItem = new DocumentItem( new Image.Image( "", 1, 1 ) );

            bool isInsertImageInvoked = false;
            _documentMock
                .Setup( d => d.InsertImage( It.IsAny<IImage>(), It.IsAny<int>() ) )
                .Callback( () => isInsertImageInvoked = true );

            _documentMock.Setup( d => d.GetItem( It.IsAny<int>() ) ).Returns( imageDocumentItem );
            ICommand command = new InsertImageCommand( imageDocumentItem.Image, _documentMock.Object, 1 );

            // Act
            command.Execute();

            // Assert
            Assert.True( isInsertImageInvoked );
        }

        [Fact]
        public void Unexecute_DeleteItemInvoked()
        {
            // Arrange
            var imageDocumentItem = new DocumentItem( new Image.Image( "", 1, 1 ) );

            bool isDeleteItemInvoked = false;
            _documentMock.Setup( d => d.DeleteItem( It.IsAny<int>() ) ).Callback( () => isDeleteItemInvoked = true );
            ICommand command = new InsertImageCommand( imageDocumentItem.Image, _documentMock.Object, 1 );

            // Act
            command.Unexecute();

            // Assert
            Assert.True( isDeleteItemInvoked );
        }
    }
}
