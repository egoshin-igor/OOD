namespace Streams.InputStream
{
    public class DecodingInputStream : IInputStream
    {
        private readonly IInputStream _inputStream;
        private readonly byte[] _decodingShuffledBytes;

        public bool IsEof => _inputStream.IsEof;

        public DecodingInputStream( IInputStream inputStream, int key )
        {
            _inputStream = inputStream;
            _decodingShuffledBytes = ByteShuffleUtil.GetDecodingShuffledBytes( key );
        }

        public void Dispose()
        {
            _inputStream.Dispose();
        }

        public int ReadBlock( byte[] buffer, uint count )
        {
            int readSize = _inputStream.ReadBlock( buffer, count );

            for ( int i = 0; i < readSize; i++ )
            {
                buffer[ i ] = _decodingShuffledBytes[ buffer[ i ] ];
            }

            return readSize;
        }

        public int ReadByte()
        {
            int value = _inputStream.ReadByte();
            return value != -1 ? _decodingShuffledBytes[ value ] : -1;
        }
    }
}
