using Command.Paragraph;

namespace Command.Document.Command
{
    public class InsertParagraphCommand : ICommand
    {
        private readonly IParagraph _paragraph;
        private readonly IDocument _document;
        private int? _position;

        public InsertParagraphCommand( IParagraph paragraph, IDocument document, int? position )
        {
            _paragraph = paragraph;
            _document = document;
            _position = position;
        }

        public void Execute()
        {
            _document.InsertParagraph( _paragraph, _position );
            if ( _position == null )
            {
                _position = _document.ItemsCount - 1;
            }
        }

        public void Unexecute()
        {
            _document.DeleteItem( _position.Value );
        }
    }
}
