namespace Command.Document
{
    public interface IDocumentHistory
    {
        bool CanUndo { get; }
        bool CanRendo { get; }
        void Undo();
        void Redo();
    }
}
