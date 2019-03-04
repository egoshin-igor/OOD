using System.Collections.Generic;
using System.IO;

namespace Streams.InputStream
{
    class MemoryInputStream : IInputStream
    {
        MemoryStream _source;

        public MemoryInputStream( List<byte> bytes )
        {
            _source = new MemoryStream( bytes.ToArray(), false );
        }

        public void Dispose()
        {
            _source.Dispose();
        }

        public bool IsEof()
        {
            return _source.Length == _source.Position;
        }

        public int ReadBlock( byte[] buffer, uint count )
        {
            return _source.Read( buffer, offset: 0, ( int )count );
        }

        public byte ReadByte()
        {
            return ( byte )_source.ReadByte();
        }
    }
}
