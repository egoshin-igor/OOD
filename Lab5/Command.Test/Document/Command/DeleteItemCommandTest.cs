using Command.Document;
using Command.Document.Command;
using Command.Document.Item;
using Command.Image;
using Moq;
using Xunit;

namespace Command.Test.Document.Command
{
    public class DeleteItemCommandTest
    {
        readonly Mock<IDocument> _documentMock;

        public DeleteItemCommandTest()
        {
            _documentMock = new Mock<IDocument>();
        }

        [Fact]
        public void Execute_DeleteItemInvoked()
        {
            // Arrange
            bool isDeleteItemInvoked = false;
            _documentMock.Setup( d => d.DeleteItem( It.IsAny<int>() ) ).Callback( () => isDeleteItemInvoked = true );
            ICommand command = new DeleteItemCommand( 1, _documentMock.Object );

            // Act
            command.Execute();

            // Assert
            Assert.True( isDeleteItemInvoked );
        }

        [Fact]
        public void Unexecute_InsertItemInvoked()
        {
            // Arrange
            var imageDocumentItem = new DocumentItem( new Image.Image( "", 1, 1 ) );

            bool isInsertItemInvoked = false;
            _documentMock
                .Setup( d => d.InsertImage( It.IsAny<IImage>(), It.IsAny<int>() ) )
                .Callback( () => isInsertItemInvoked = true );
            _documentMock.Setup( d => d.GetItem( It.IsAny<int>() ) ).Returns( imageDocumentItem );
            ICommand command = new DeleteItemCommand( 1, _documentMock.Object );
            command.Execute();

            // Act
            command.Unexecute();

            // Assert
            Assert.True( isInsertItemInvoked );
        }
    }
}
