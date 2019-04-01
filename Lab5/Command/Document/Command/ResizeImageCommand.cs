using Command.Document.Item;
using Command.Document.Item.Enum;

namespace Command.Document.Command
{
    public class ResizeImageCommand : ICommand
    {
        IDocument _document;
        private readonly int _position;
        private int _width;
        private int _height;
        private int _previousWeight;
        private int _previousHeight;

        public ResizeImageCommand( int position, int width, int height, IDocument document )
        {
            _position = position;
            _width = width;
            _height = height;
            _document = document;
        }

        public void Execute()
        {
            DocumentItem item = _document.GetItem( _position );
            Image.IImage image = item.Image;
            if ( item.Type != DocumentItemType.Image )
            {
                throw new DocumentException( $"Incorrect type {item.Type.ToString()}" );
            }

            _previousWeight = image.Width;
            _previousHeight = image.Height;
            image.Resize( _width, _height );
        }

        public void Unexecute()
        {
            DocumentItem item = _document.GetItem( _position );
            item.Image.Resize( _previousWeight, _previousWeight );
        }
    }
}
