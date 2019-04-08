using Command.Paragraph;

namespace Command.Document.Command
{
    public class InsertParagraphCommand : ICommand
    {
        private readonly string _text;
        private readonly IDocument _document;
        private int? _position;

        public InsertParagraphCommand( string text, IDocument document, int? position )
        {
            _text = text;
            _document = document;
            _position = position;
        }

        public void Execute()
        {
            _document.InsertParagraph( _text, _position );
            if ( _position == null )
            {
                _position = _document.ItemsCount - 1;
            }
        }

        public void Unexecute()
        {
            _document.DeleteItem( _position.Value );
        }

        public void Dispose()
        {
        }
    }
}
