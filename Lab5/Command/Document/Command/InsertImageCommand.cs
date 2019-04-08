namespace Command.Document.Command
{
    public class InsertImageCommand : ICommand
    {
        private readonly string _path;
        private readonly int _weidht;
        private readonly int _height;
        private readonly IDocument _document;
        private int? _position;

        public InsertImageCommand( string path, int weidht, int height, IDocument document, int? position )
        {
            _path = path;
            _weidht = weidht;
            _height = height;
            _document = document;
            _position = position;
        }

        public void Execute()
        {
            _document.InsertImage( _path, _weidht, _height, _position );
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
