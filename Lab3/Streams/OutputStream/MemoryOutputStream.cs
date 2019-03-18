using System.IO;

namespace Streams.OutputStream
{
    public class MemoryOutputStream : IOutputStream
    {
        private readonly MemoryStream _source;

        public MemoryOutputStream( uint capacity )
        {
            _source = new MemoryStream( ( int )capacity );
        }

        public MemoryOutputStream( byte[] bytes )
        {
            _source = new MemoryStream( bytes, writable: true );
        }

        public void Dispose()
        {
            Flush();
            _source.Dispose();
        }

        public void Flush()
        {
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
