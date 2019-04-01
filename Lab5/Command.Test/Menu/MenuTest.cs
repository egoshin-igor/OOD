using Command.Document;
using Command.Image;
using Command.Menu;
using Moq;
using Xunit;
using MenuClass = Command.Menu.Menu;

namespace Command.Test.Menu
{
    public class MenuTest
    {
        private Mock<IDocument> _documentMock = new Mock<IDocument>();
        private MenuClass _menu;

        public MenuTest()
        {
            _menu = new MenuClass( _documentMock.Object );
        }

        [Fact]
        public void Execute_CommandCantBeParsed_ThrowMenuException()
        {
            // Arrange
            string command = "InsertImageimg.png";

            // Act
            // Assert
            Assert.Throws<MenuException>( () => _menu.Execute( command ) );
        }

        [Fact]
        public void Execute_ShortcutNotFound_ThrowMenuException()
        {
            // Arrange
            string command = "InsertImage img.png";

            // Act
            // Assert
            Assert.Throws<MenuException>( () => _menu.Execute( command ) );
        }

        [Fact]
        public void Execute_CorrectExecute()
        {
            // Arrange
            string command = "InsertImage img.png";
            bool isInsertImageCalled = false;
            _documentMock
                .Setup( d => d.InsertImage( It.IsAny<IImage>(), It.IsAny<int?>() ) )
                .Callback( () => isInsertImageCalled = true );

            _menu.AddItem(
                "InsertImage",
                description: "",
                ( shortcut, document ) => document
                    .InsertImage( new Image.Image( path: "", weidht: 1, height: 1 ) )
            );

            // Act
            _menu.Execute( command );
            // Assert
            Assert.True( isInsertImageCalled );
        }
    }
}
