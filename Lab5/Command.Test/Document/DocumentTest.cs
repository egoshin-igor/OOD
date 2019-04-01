using Command.Document;
using Command.Image;
using Moq;
using Xunit;

using DocumentClass = Command.Document.Document;
namespace Command.Test.Document
{
    public class DocumentTest
    {
        private Mock<DocumentHistory> _documentHistoryMock = new Mock<DocumentHistory>();
        private IDocument _document;

        public DocumentTest()
        {
            _document = new DocumentClass( _documentHistoryMock.Object );
        }

        [Fact]
        public void InsertParagraph_PositionLessThanZero_ThrowDocumentException()
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<DocumentException>( () =>
                _document.InsertParagraph( new Paragraph.Paragraph( "Text" ), position: -1 )
            );
        }

        [Fact]
        public void InsertParagraph_PositionMoreThanDocumentItemsCount_ThrowDocumentException()
        {
            // Arrange
            // Act
            // Assert
            Assert.Equal( 0, _document.ItemsCount );
            Assert.Throws<DocumentException>( () =>
                _document.InsertParagraph( new Paragraph.Paragraph( "Text" ), position: 1 ) );
        }

        [Fact]
        public void InsertParagraphAndGetItem_CorrectInsertAndGet()
        {
            // Arrange
            string paragraphText = "Text";

            // Act
            _document.InsertParagraph( new Paragraph.Paragraph( "Text" ) );

            // Assert
            Assert.Equal( 1, _document.ItemsCount );
            Assert.Equal( paragraphText, _document.GetItem( 0 ).Paragraph.Text );
        }

        [Fact]
        public void InsertImage_CorrectInsertAndGet()
        {
            // Arrange
            string path = "path";

            // Act
            _document.InsertImage( new Image.Image( path, 22, 22 ) );

            // Assert
            Assert.Equal( 1, _document.ItemsCount );
            Assert.Equal( path, _document.GetItem( 0 ).Image.Path );
        }

        [Fact]
        public void InsertImage_WidhthAndHeightMoreThanMax_SetMaxSize()
        {
            // Arrange
            int expectedSize = 10000;

            // Act
            _document.InsertImage( new Image.Image( "", 1000000, 100000 ) );

            // Assert
            Assert.Equal( 1, _document.ItemsCount );
            IImage image = _document.GetItem( 0 ).Image;
            Assert.Equal( expectedSize, image.Width );
            Assert.Equal( expectedSize, image.Height );
        }

        [Fact]
        public void Undo_CorrectResult()
        {
            // Arrange
            bool isUndoInvoked = false;
            _documentHistoryMock.Setup( dh => dh.Undo() ).Callback( () => isUndoInvoked = true );

            // Act
            _document.Undo();

            // Assert
            Assert.True( isUndoInvoked );
        }

        [Fact]
        public void Redo_CorrectResult()
        {
            // Arrange
            bool isRedoInvoked = false;
            _documentHistoryMock.Setup( dh => dh.Redo() ).Callback( () => isRedoInvoked = true );

            // Act
            _document.Redo();

            // Assert
            Assert.True( isRedoInvoked );
        }

        [Fact]
        public void DeleteItem_CorrectDelete()
        {
            // Arrange
            _document.InsertImage( new Image.Image( "", 1000000, 100000 ) );

            // Act
            _document.DeleteItem( 0 );

            // Assert
            Assert.Equal( 0, _document.ItemsCount );
        }
    }
}
