using Command.Document;
using Command.Document.Command;
using Command.Document.Item;
using Command.Image;
using Moq;
using Xunit;

using DocumentClass = Command.Document.Document;
namespace Command.Test.Document.Command
{
    public class SetTitleCommandTest
    {
        readonly IDocument _document;

        public SetTitleCommandTest()
        {
            _document = new DocumentClass( new Mock<DocumentHistory>().Object );
        }

        [Fact]
        public void Execute_DeleteItemInvoked()
        {
            // Arrange
            _document.Title = "1";
            var newTitle = "2";

            ICommand command = new SetTitleCommand( newTitle, _document );

            // Act
            command.Execute();

            // Assert
            Assert.Equal( newTitle, _document.Title );
        }

        [Fact]
        public void Unexecute_InsertItemInvoked()
        {
            // Arrange
            string oldTitle = "1";
            _document.Title = oldTitle;
            var newTitle = "2";

            ICommand command = new SetTitleCommand( newTitle, _document );
            command.Execute();

            // Act
            command.Unexecute();

            // Assert
            Assert.Equal( oldTitle, _document.Title );
        }
    }
}
