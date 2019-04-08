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
        private MenuClass _menu;

        public MenuTest()
        {
            _menu = new MenuClass();
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
            string command = "InsertImage end 2 2 img.png";
            bool isCommandExecuted = false;

            _menu.AddItem(
                "InsertImage",
                description: "",
                ( commandParams ) => isCommandExecuted = true
            );

            // Act
            _menu.Execute( command );

            // Assert
            Assert.True( isCommandExecuted );
        }
    }
}
