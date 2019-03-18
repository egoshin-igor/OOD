using System;
using System.Linq;
using Streams.InputStream;
using Streams.OutputStream;
using Xunit;

namespace Streams.Test
{
    public class EncodeTest
    {
        [Fact]
        public void EncodeAndDecodeByte_GetOriginByte()
        {
            // Arrange
            Random random = new Random();
            int key = random.Next();

            var buffer = new byte[ 1 ];
            byte data = 1;

            IOutputStream encodingOutputStream = new EncodingOutputStream( new MemoryOutputStream( buffer ), key );
            IInputStream decodingInputStream = new DecodingInputStream( new MemoryInputStream( buffer ), key );

            // Act
            encodingOutputStream.WriteByte( data );
            encodingOutputStream.Dispose();
            int result = decodingInputStream.ReadByte();
            decodingInputStream.Dispose();

            // Assert
            Assert.Equal( data, result );
        }

        [Fact]
        public void EncodeAndDecodeBlock_GetOriginBlock()
        {
            // Arrange
            Random random = new Random();
            int key = random.Next();

            var buffer = new byte[ 3 ];
            byte[] data = { 1, 2, 3 };
            var result = new byte[ 3 ];

            IOutputStream encodingOutputStream = new EncodingOutputStream( new MemoryOutputStream( buffer ), key );
            IInputStream decodingInputStream = new DecodingInputStream( new MemoryInputStream( buffer ), key );

            // Act
            encodingOutputStream.WriteBlock( data, ( uint )data.Length );
            encodingOutputStream.Dispose();
            int readSize = decodingInputStream.ReadBlock( result, ( uint )result.Length );
            decodingInputStream.Dispose();

            // Assert
            Assert.Equal( result.Length, readSize );
            Assert.True( result.SequenceEqual( data ) );
        }
    }
}
