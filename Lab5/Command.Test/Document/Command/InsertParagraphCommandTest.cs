using Command.Document;
using Command.Document.Command;
using Command.Document.Item;
using Command.Image;
using Command.Paragraph;
using Moq;
using Xunit;

namespace Command.Test.Document.Command
{
    public class InsertParagraphCommandTest
    {
        readonly Mock<IDocument> _documentMock;

        public InsertParagraphCommandTest()
        {
            _documentMock = new Mock<IDocument>();
        }

        [Fact]
        public void Execute_InsertParagraphInvoked()
        {
            // Arrange
            var paragrpahDocumentItem = new DocumentItem( new Paragraph.Paragraph( "" ) );

            bool isInsertParagraphInvoked = false;
            _documentMock
                .Setup( d => d.InsertParagraph( It.IsAny<string>(), It.IsAny<int>() ) )
                .Callback( () => isInsertParagraphInvoked = true );

            _documentMock.Setup( d => d.GetItem( It.IsAny<int>() ) ).Returns( paragrpahDocumentItem );
            ICommand command = new InsertParagraphCommand( "", _documentMock.Object, 1 );

            // Act
            command.Execute();

            // Assert
            Assert.True( isInsertParagraphInvoked );
        }

        [Fact]
        public void Unexecute_DeleteItemInvoked()
        {
            // Arrange
            var paragrpahDocumentItem = new DocumentItem( new Paragraph.Paragraph( "" ) );

            bool isDeleteItemInvoked = false;
            _documentMock.Setup( d => d.DeleteItem( It.IsAny<int>() ) ).Callback( () => isDeleteItemInvoked = true );
            ICommand command = new InsertParagraphCommand( "", _documentMock.Object, 1 );

            // Act
            command.Unexecute();

            // Assert
            Assert.True( isDeleteItemInvoked );
        }
    }
}
