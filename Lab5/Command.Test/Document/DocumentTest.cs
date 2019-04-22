using System.IO;
using System.Linq;
using Command.Document;
using Command.Document.Item;
using Command.Image;
using CsQuery;
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
            Assert.Throws<DocumentException>( () => _document.InsertParagraph( "Text", position: -1 ) );
        }


        [Fact]
        public void InsertParagraph_PositionMoreThanDocumentItemsCount_ThrowDocumentException()
        {
            // Arrange
            // Act
            // Assert
            Assert.Equal( 0, _document.ItemsCount );
            Assert.Throws<DocumentException>( () =>
                _document.InsertParagraph( "Text", position: 1 ) );
        }

        [Fact]
        public void GetItem_ItemByIndexDoesNotExist_CorrectGet()
        {
            // Arrange
            DocumentItem documentItem = new DocumentItem( new Paragraph.Paragraph( "1" ) );

            // Act
            // Assert
            Assert.Throws<DocumentException>( () => _document.GetItem( 1 ) );
        }

        [Fact]
        public void InsertParagraphAndGetItem_CorrectInsertAndGet()
        {
            // Arrange
            string paragraphText = "Text";

            // Act
            _document.InsertParagraph( "Text" );

            // Assert
            Assert.Equal( 1, _document.ItemsCount );
            Assert.Equal( paragraphText, _document.GetItem( 0 ).Paragraph.Text );
        }

        [Fact]
        public void InsertImage_CorrectInsertAndGet()
        {
            // Arrange
            string path = System.IO.Path.GetTempFileName();

            // Act
            _document.InsertImage( path, 22, 22 );

            // Assert
            Assert.Equal( 1, _document.ItemsCount );
        }

        [Fact]
        public void InsertImage_WidhthAndHeightMoreThanMax_SetMaxSize()
        {
            // Arrange
            int expectedSize = 10000;

            // Act
            _document.InsertImage( System.IO.Path.GetTempFileName(), 1000000, 100000 );

            // Assert
            Assert.Equal( 1, _document.ItemsCount );
            IImage image = _document.GetItem( 0 ).Image;
            Assert.Equal( expectedSize, image.Width );
            Assert.Equal( expectedSize, image.Height );
        }

        [Fact]
        public void InsertImage_InsertMoreThanMaxCommandsCanStoreHistory_ImageDoesNotDeleted()
        {
            // Arrange
            string originFilePath = Path.GetTempFileName();
            _document.InsertImage( originFilePath, 1, 1 );
            string tempImagePath = _document.GetItem( 0 ).Image.Path;
            int maxCommandsInHistory = 10;

            // Act
            for ( int i = 0; i < maxCommandsInHistory + 1; i++ )
            {
                _document.InsertImage( originFilePath, 1, 1 );
            }

            // Assert
            Assert.True( File.Exists( tempImagePath ) );
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
            _document.InsertImage( System.IO.Path.GetTempFileName(), 1, 1 );

            // Act
            _document.DeleteItem( 0 );

            // Assert
            Assert.Equal( 0, _document.ItemsCount );
        }

        [Fact]
        public void Save_SaveImage_ImageHasReferencePath()
        {
            // Arrange
            string expectedReferencePathBegining = "images/";
            _document.InsertImage( Path.GetTempFileName(), 1, 1 );
            string temporaryDirectory = Path.GetTempPath();
            string temporaryPath = Path.Combine( temporaryDirectory, "1.html" );

            // Act
            _document.Save( temporaryPath );

            // Assert
            string html = File.ReadAllText( temporaryPath );
            string imagePath = GetFirstImagePath( html );
            Assert.StartsWith( expectedReferencePathBegining, imagePath );
        }

        private string GetFirstImagePath( string html )
        {
            CQ image = CQ.Create( html )[ "img" ];
            string imagePath = image.First().Attr( "src" );

            return imagePath;
        }
    }
}
