using Command.Document.Command;

namespace Command.Document
{
    public interface IDocumentHistory
    {
        bool CanUndo { get; }
        bool CanRendo { get; }
        void Undo();
        void Redo();
        void AddToHistory( ICommand command );
    }
}
