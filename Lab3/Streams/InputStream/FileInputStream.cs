using System;
using System.IO;

namespace Streams.InputStream
{
    class FileInputStream : IInputStream
    {
        FileStream _source;

        public FileInputStream( string fileName )
        {
            _source = new FileStream( fileName, FileMode.Open );
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
