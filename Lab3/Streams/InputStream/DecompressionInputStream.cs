using System;

namespace Streams.InputStream
{
    public class DecompressionInputStream : IInputStream
    {
        private const byte RleMarker = 255;

        private readonly IInputStream _inputStream;

        private byte _currentValue;
        private byte _length = 0;

        public bool IsEof => _inputStream.IsEof;

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
                if ( IsEof && _length == 0 )
                {
                    break;
                }
            }

            return readSize;
        }

        public int ReadByte()
        {
            if ( _length != 0 )
            {
                _length--;
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

            _length = _currentValue;
            if ( IsEof )
            {
                throw new ApplicationException( $"After length={RleMarker} marker can be one or more bytes" );
            }

            _currentValue = ( byte )_inputStream.ReadByte();
            _length--;

            return _currentValue;
        }
    }
}
