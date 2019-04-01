using System.IO;

namespace Streams.OutputStream
{
    public class FileOutputStream : IOutputStream
    {
        private readonly FileStream _source;

        public FileOutputStream( string fileName )
        {
            _source = new FileStream( fileName, FileMode.Create );
        }

        public void WriteByte( byte data )
        {
            _source.WriteByte( data );
        }

        public void WriteBlock( byte[] data, uint size )
        {
            _source.Write( data, offset: 0, ( int )size );
        }

        public void Dispose()
        {
            Flush();
            _source.Dispose();
        }

        public void Flush()
        {
        }
    }
}
