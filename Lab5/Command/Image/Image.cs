namespace Command.Image
{
    public class Image : IImage
    {
        public Image( string path, int weidht, int height )
        {
            Path = path;
            Resize( weidht, height );
        }

        public int Width { get; private set; }
        public int Height { get; private set; }
        public string Path { get; private set; }

        public void Resize( int width, int height )
        {
            const int maxWidth = 10000;
            const int maxHeight = 10000;

            Width = width > maxWidth ? maxWidth : ( width < 0 ? 0 : width );
            Height = height > maxHeight ? maxHeight : ( height < 0 ? 0 : height );
        }
    }
}
