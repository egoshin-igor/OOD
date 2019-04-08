using Command.Document;
using Command.Document.Command;
using Command.Document.Item;
using Moq;
using Xunit;

namespace Command.Test.Document.Command
{
    public class ReplaceTextCommandTest
    {
        private readonly Mock<IDocument> _documentMock;
        private readonly Mock<DocumentHistory> _documentHistoryMock;

        public ReplaceTextCommandTest()
        {
            _documentHistoryMock = new Mock<DocumentHistory>();
            _documentHistoryMock.Setup( h => h.AddToHistory( It.IsAny<ICommand>() ) );
            _documentMock = new Mock<IDocument>();
            _documentMock.SetupGet( d => d.DocumentHistory ).Returns( _documentHistoryMock.Object );
        }

        [Fact]
        public void Execute_GetItemAndReplaceText()
        {
            // Arrange
            var paragrpahDocumentItem = new DocumentItem( new Paragraph.Paragraph( "" ) );

            _documentMock.Setup( d => d.GetItem( It.IsAny<int>() ) ).Returns( paragrpahDocumentItem );
            ICommand command = new ReplaceTextCommand( 1, "Hey", _documentMock.Object );

            // Act
            command.Execute();

            // Assert
            Assert.Equal( "Hey", paragrpahDocumentItem.Paragraph.Text );
        }

        [Fact]
        public void Unexecute_ReturnOriginTextValue()
        {
            // Arrange
            var paragrpahDocumentItem = new DocumentItem( new Paragraph.Paragraph( "" ) );

            _documentMock.Setup( d => d.GetItem( It.IsAny<int>() ) ).Returns( paragrpahDocumentItem );
            ICommand command = new ReplaceTextCommand( 1, "Hey", _documentMock.Object );
            command.Execute();

            // Act
            command.Unexecute();

            // Assert
            Assert.Equal( "", paragrpahDocumentItem.Paragraph.Text );
        }
    }
}
