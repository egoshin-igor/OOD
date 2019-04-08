using System.IO;

namespace Command.Image
{
    public class Image : IImage
    {
        private bool _disposed = false;

        public Image( string path, string fileExtrension, int width, int height )
        {
            Path = path;
            FileExtrension = fileExtrension;
            Resize( width, height );
        }

        ~Image()
        {
            Dispose();
        }

        public string Path { get; private set; }
        public string FileExtrension { get; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public void Dispose()
        {
            if ( !_disposed )
            {
                File.Delete( Path );
                _disposed = true;
            }
        }

        public void Resize( int width, int height )
        {
            const int maxWidth = 10000;
            const int maxHeight = 10000;

            Width = width > maxWidth ? maxWidth : ( width < 0 ? 0 : width );
            Height = height > maxHeight ? maxHeight : ( height < 0 ? 0 : height );
        }
    }
}
