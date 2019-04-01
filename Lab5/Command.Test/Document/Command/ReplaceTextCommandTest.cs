using Command.Document;
using Command.Document.Command;
using Command.Document.Item;
using Command.Image;
using Command.Paragraph;
using Moq;
using Xunit;

namespace Command.Test.Document.Command
{
    public class ReplaceTextCommandTest
    {
        readonly Mock<IDocument> _documentMock;

        public ReplaceTextCommandTest()
        {
            _documentMock = new Mock<IDocument>();
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
