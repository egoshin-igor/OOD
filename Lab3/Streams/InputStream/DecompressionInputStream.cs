using System;

namespace Streams.InputStream
{
    public class DecompressionInputStream : IInputStream
    {
        private const byte RleMarker = 255;

        private readonly IInputStream _inputStream;

        private byte _currentValue;
        private int _byteslength = 0;

        public bool IsEof => _byteslength == 0 && _inputStream.IsEof;

        public DecompressionInputStream( IInputStream inputStream )
        {
            _inputStream = inputStream;
        }

        public void Dispose()
        {
            _inputStream.Dispose();
        }

        public int ReadBlock( byte[] buffer, uint count )
        {
            int readSize = 0;

            for ( int i = 0; i < count; i++ )
            {
                buffer[ i ] = ( byte )ReadByte();
                readSize++;
                if ( IsEof && _byteslength == 0 )
                {
                    break;
                }
            }

            return readSize;
        }

        public int ReadByte()
        {
            if ( _byteslength != 0 )
            {
                _byteslength--;
                return _currentValue;
            }

            if ( IsEof )
            {
                return -1;
            }

            _currentValue = ( byte )_inputStream.ReadByte();
            if ( _currentValue != RleMarker )
            {
                return _currentValue;
            }

            if ( IsEof )
            {
                throw new ApplicationException( $"After rleMarker={RleMarker} can be one or more bytes" );
            }

            _currentValue = ( byte )_inputStream.ReadByte();
            if ( _currentValue == RleMarker )
            {
                return RleMarker;
            }

            _byteslength = _currentValue + 4;
            if ( IsEof )
            {
                throw new ApplicationException( $"After length={RleMarker} marker can be one or more bytes" );
            }

            _currentValue = ( byte )_inputStream.ReadByte();
            _byteslength--;

            return _currentValue;
        }
    }
}
