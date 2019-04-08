using Command.Document.Item;

namespace Command.Document
{
    public interface IDocument
    {
        void InsertParagraph( string text, int? position = null );
        void InsertImage( string path, int weight, int height, int? position = null );
        int ItemsCount { get; }
        DocumentItem GetItem( int index );
        void DeleteItem( int index );
        string Title { get; set; }
        bool CanUndo { get; }
        void Undo();
        bool CanRedo { get; }
        void Redo();
        void Save( string path );
        IDocumentHistory DocumentHistory { get; }
    }
}
