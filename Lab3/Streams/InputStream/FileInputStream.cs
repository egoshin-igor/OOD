using System.IO;

namespace Streams.InputStream
{
    public class FileInputStream : IInputStream
    {
        private readonly FileStream _source;

        public bool IsEof => _source.Position >= _source.Length;

        public FileInputStream( string fileName )
        {
            _source = new FileStream( fileName, FileMode.Open );
        }

        public int ReadBlock( byte[] buffer, uint count )
        {
            return _source.Read( buffer, offset: 0, ( int )count );
        }

        public int ReadByte()
        {
            return _source.ReadByte();
        }

        public void Dispose()
        {
            _source.Dispose();
        }
    }
}
