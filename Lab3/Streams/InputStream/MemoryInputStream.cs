using System.IO;

namespace Streams.InputStream
{
    public class MemoryInputStream : IInputStream
    {
        private readonly MemoryStream _source;

        public bool IsEof => _source.Position >= _source.Length;

        public MemoryInputStream( byte[] bytes )
        {
            _source = new MemoryStream( bytes, writable: false );
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
