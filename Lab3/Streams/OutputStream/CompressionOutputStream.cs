using System.Collections.Generic;

namespace Streams.OutputStream
{
    public class CompressionOutputStream : IOutputStream
    {
        private const byte RleMarker = 255;
        private const int MaxCompressionLength = 258;
        private byte _lastByte = 0;
        private int _lastBytesLength = 0;

        private readonly IOutputStream _outputStream;

        public CompressionOutputStream( IOutputStream outputStream )
        {
            _outputStream = outputStream;
        }

        public void Dispose()
        {
            Flush();
            _outputStream.Dispose();
        }

        public void WriteBlock( byte[] data, uint size )
        {
            var result = new List<byte>();

            foreach ( byte value in data )
            {
                byte[] compressedBytes = GetBytesAfterCompressStep( value );
                if ( compressedBytes != null )
                {
                    result.AddRange( compressedBytes );
                }
            }

            if ( result.Count != 0 )
            {
                _outputStream.WriteBlock( result.ToArray(), ( uint )result.Count );
            }
        }

        public void WriteByte( byte data )
        {
            byte[] result = GetBytesAfterCompressStep( data );

            if ( result != null )
            {
                _outputStream.WriteBlock( result, ( uint )result.Length );
            }
        }

        public void Flush()
        {
            if ( _lastBytesLength != 0 )
            {
                byte[] result = GetCompressed( _lastByte, _lastBytesLength );
                _outputStream.WriteBlock( result, ( uint )result.Length );
                _lastByte = 0;
                _lastBytesLength = 0;
            }

            _outputStream.Flush();
        }

        private byte[] GetBytesAfterCompressStep( byte data )
        {
            byte[] result = null;

            if ( _lastBytesLength == 0 )
            {
                _lastByte = data;
                _lastBytesLength = 1;
            }
            else if ( data == _lastByte )
            {
                _lastBytesLength++;
            }
            else
            {
                result = GetCompressed( _lastByte, _lastBytesLength );
                _lastByte = data;
                _lastBytesLength = 1;
            }

            if ( _lastBytesLength > MaxCompressionLength )
            {
                result = GetCompressed( _lastByte, MaxCompressionLength );
                _lastBytesLength -= MaxCompressionLength;
            }

            return result;
        }

        private byte[] GetCompressed( byte data, int length )
        {
            const int smallEqualBytesLength = 3;

            var result = new List<byte>();

            if ( length == 1 || length <= smallEqualBytesLength )
            {
                for ( int i = 0; i < length; i++ )
                {
                    if ( data == RleMarker )
                    {
                        result.Add( data );
                    }

                    result.Add( data );
                }
            }
            else
            {
                result.AddRange( new byte[] { RleMarker, ( byte )( length - 4 ), data } );
            }

            return result.ToArray();
        }
    }
}
