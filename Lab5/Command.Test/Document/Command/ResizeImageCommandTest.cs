using Command.Document;
using Command.Document.Command;
using Command.Document.Item;
using Command.Image;
using Moq;
using Xunit;
using ImageClass = Command.Image.Image;

namespace Command.Test.Document.Command
{
    public class ResizeImageCommandTest
    {
        readonly Mock<IDocument> _documentMock;
        private readonly Mock<DocumentHistory> _documentHistoryMock;

        public ResizeImageCommandTest()
        {
            _documentHistoryMock = new Mock<DocumentHistory>();
            _documentHistoryMock.Setup( h => h.AddToHistory( It.IsAny<ICommand>() ) );
            _documentMock = new Mock<IDocument>();
            _documentMock.SetupGet( d => d.DocumentHistory ).Returns( _documentHistoryMock.Object );
        }

        [Fact]
        public void Execute_ResizeCorrect()
        {
            // Arrange
            var imageDocumentItem = new DocumentItem( new ImageClass( "", "", 1, 1 ) );

            _documentMock.Setup( d => d.GetItem( It.IsAny<int>() ) ).Returns( imageDocumentItem );
            ICommand command = new ResizeImageCommand( 1, 2, 2, _documentMock.Object );

            // Act
            command.Execute();

            // Assert
            Assert.Equal( 2, imageDocumentItem.Image.Width );
            Assert.Equal( 2, imageDocumentItem.Image.Height );
        }

        [Fact]
        public void Unexecute_ReturnOriginSizes()
        {
            // Arrange
            var imageDocumentItem = new DocumentItem( new ImageClass( "", "", 1, 1 ) );

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
