using Command.Document.Item;
using Command.Image;
using Command.Paragraph;

namespace Command.Document
{
    public interface IDocument
    {
        void InsertParagraph( IParagraph paragraph, int? position = null );
        void InsertImage( IImage image, int? position = null );
        int ItemsCount { get; }
        DocumentItem GetItem( int index );
        void DeleteItem( int index );
        string Title { get; set; }
        bool CanUndo { get; }
        void Undo();
        bool CanRedo { get; }
        void Redo();
        void Save( string path );
    }
}
