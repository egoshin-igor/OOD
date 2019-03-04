using System.IO;

namespace Streams.OutputStream
{
    class MemoryOutputStream : IOutputStream
    {
        MemoryStream _source;

        public MemoryOutputStream( uint size )
        {
            _source = new MemoryStream( ( int )size );
        }

        public MemoryOutputStream( byte[] bytes )
        {
            _source = new MemoryStream( bytes, writable: true );
        }

        public void Dispose()
        {
            _source.Dispose();
        }

        public void WriteBlock( byte[] data, uint size )
        {
            _source.Write( data, offset: 0, ( int )size );
        }

        public void WriteByte( byte data )
        {
            _source.WriteByte( data );
        }
    }
}
