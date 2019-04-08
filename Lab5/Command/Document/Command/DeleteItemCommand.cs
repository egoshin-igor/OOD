using Command.Document.Item;
using Command.Document.Item.Enum;
using Command.Image;

namespace Command.Document.Command
{
    public class DeleteItemCommand : ICommand
    {
        IDocument _document;
        private int _position;
        private DocumentItem _deletedDocumentItem;

        public DeleteItemCommand( int position, IDocument document )
        {
            _document = document;
            _position = position;
        }

        public void Dispose()
        {
            if ( _deletedDocumentItem.Type == DocumentItemType.Image )
            {
                IImage image = _deletedDocumentItem.Image;
                image.Dispose();
            }
        }

        public void Execute()
        {
            _deletedDocumentItem = _document.GetItem( _position );
            _document.DeleteItem( _position );
        }

        public void Unexecute()
        {
            if ( _deletedDocumentItem.Type == DocumentItemType.Image )
            {
                IImage image = _deletedDocumentItem.Image;
                _document.InsertImage( image.Path, image.Width, image.Height, _position );
            }
            else if ( _deletedDocumentItem.Type == DocumentItemType.Paragraph )
            {
                _document.InsertParagraph( _deletedDocumentItem.Paragraph.Text, _position );
            }
            else
            {
                throw new DocumentException( $"Unrecognized document item {_deletedDocumentItem.Type.ToString()}" );
            }
        }
    }
}
