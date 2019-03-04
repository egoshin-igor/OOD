using System.IO;

namespace Streams.OutputStream
{
    class FileOutputStream : IOutputStream
    {
        FileStream _source;

        public FileOutputStream( string fileName )
        {
            _source = new FileStream( fileName, FileMode.OpenOrCreate );
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
