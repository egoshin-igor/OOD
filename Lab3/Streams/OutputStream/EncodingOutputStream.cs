namespace Streams.OutputStream
{
    public class EncodingOutputStream : IOutputStream
    {
        private readonly IOutputStream _outputStream;
        private readonly byte[] _encodingShuffledBytes;

        public EncodingOutputStream( IOutputStream outputStream, int key )
        {
            _outputStream = outputStream;
            _encodingShuffledBytes = ByteShuffleUtil.GetEncodingShuffledBytes( key );
        }

        public void Dispose()
        {
            Flush();
            _outputStream.Dispose();
        }

        public void Flush()
        {
            _outputStream.Flush();
        }

        public void WriteBlock( byte[] data, uint size )
        {
            var encodedData = new byte[ size ];
            for ( int i = 0; i < size; i++ )
            {
                encodedData[ i ] = _encodingShuffledBytes[ data[ i ] ];
            }

            _outputStream.WriteBlock( encodedData, size );
        }

        public void WriteByte( byte data )
        {
            _outputStream.WriteByte( _encodingShuffledBytes[ data ] );
        }
    }
}
