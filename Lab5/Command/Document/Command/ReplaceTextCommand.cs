using Command.Document.Item;
using Command.Document.Item.Enum;

namespace Command.Document.Command
{
    public class ReplaceTextCommand : ICommand
    {
        IDocument _document;
        private readonly int _position;
        private string _text;
        private string _previousText;

        public ReplaceTextCommand( int position, string text, IDocument document )
        {
            _position = position;
            _text = text;
            _document = document;
        }

        public void Execute()
        {
            DocumentItem item = _document.GetItem( _position );
            if ( item.Type != DocumentItemType.Paragraph )
            {
                throw new DocumentException( $"Incorrect type {item.Type.ToString()}" );
            }
            _previousText = item.Paragraph.Text;
            item.Paragraph.Text = _text;
        }

        public void Unexecute()
        {
            DocumentItem item = _document.GetItem( _position );
            item.Paragraph.Text = _previousText;
        }
    }
}
