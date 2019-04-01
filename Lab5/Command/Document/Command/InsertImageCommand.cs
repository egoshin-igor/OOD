using Command.Image;

namespace Command.Document.Command
{
    public class InsertImageCommand : ICommand
    {
        private readonly IImage _image;
        private readonly IDocument _document;
        private int? _position;

        public InsertImageCommand( IImage image, IDocument document, int? position )
        {
            _image = image;
            _document = document;
            _position = position;
        }

        public void Execute()
        {
            _document.InsertImage( _image, _position );
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
