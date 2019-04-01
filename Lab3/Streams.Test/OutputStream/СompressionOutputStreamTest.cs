using System.Linq;
using Streams.OutputStream;
using Xunit;

namespace Streams.Test.OutputStream
{
    public class СompressionOutputStreamTest
    {
        [Fact]
        public void WriteByte_WriteManyEqualsBytes_WriteCompressed()
        {
            // Arrange
            var result = new byte[ 3 ];
            IOutputStream compressionOutputStream = new CompressionOutputStream( new MemoryOutputStream( result ) );
            var expectedData = new byte[] { 255, 6, 1 };

            // Act
            for ( int i = 0; i < 10; i++ )
            {
                compressionOutputStream.WriteByte( 1 );
            }
            compressionOutputStream.Dispose();

            // Assert
            Assert.True( result.SequenceEqual( expectedData ) );
        }

        [Fact]
        public void WriteByte_WriteManyNotEqualsBytes_WriteUncompressed()
        {
            // Arrange
            var result = new byte[ 6 ];
            IOutputStream compressionOutputStream = new CompressionOutputStream( new MemoryOutputStream( result ) );
            var expectedData = new byte[] { 0, 1, 2, 3, 4, 5 };

            // Act
            for ( int i = 0; i < 6; i++ )
            {
                compressionOutputStream.WriteByte( ( byte )i );
            }
            compressionOutputStream.Dispose();

            // Assert
            Assert.True( result.SequenceEqual( expectedData ) );
        }

        [Fact]
        public void WriteByte_WriteBytesWithMarker_WriteCompressed()
        {
            // Arrange
            var result = new byte[ 5 ];
            IOutputStream compressionOutputStream = new CompressionOutputStream( new MemoryOutputStream( result ) );
            var expectedData = new byte[] { 255, 255, 255, 6, 1 };

            // Act
            compressionOutputStream.WriteByte( 255 );
            for ( int i = 0; i < 10; i++ )
            {
                compressionOutputStream.WriteByte( 1 );
            }
            compressionOutputStream.Dispose();

            // Assert
            Assert.True( result.SequenceEqual( expectedData ) );
        }

        [Fact]
        public void WriteByte_WriteEqualBytesMoreThanCompressionLength_WriteCompressed()
        {
            // Arrange
            var result = new byte[ 6 ];
            IOutputStream compressionOutputStream = new CompressionOutputStream( new MemoryOutputStream( result ) );
            var expectedData = new byte[] { 255, 254, 1, 255, 38, 1 };

            // Act
            for ( int i = 0; i < 300; i++ )
            {
                compressionOutputStream.WriteByte( 1 );
            }
            compressionOutputStream.Dispose();

            // Assert
            Assert.True( result.SequenceEqual( expectedData ) );
        }

        [Fact]
        public void WriteByte_WriteManyEqualsAndNotEqualsBytes_WritePartCompressedAndPartUncompressed()
        {
            // Arrange
            var result = new byte[ 6 ];
            IOutputStream compressionOutputStream = new CompressionOutputStream( new MemoryOutputStream( result ) );
            var expectedData = new byte[] { 0, 1, 2, 255, 0, 1 };

            // Act
            for ( int i = 0; i < 3; i++ )
            {
                compressionOutputStream.WriteByte( ( byte )i );
            }
            for ( int i = 0; i < 4; i++ )
            {
                compressionOutputStream.WriteByte( 1 );
            }
            compressionOutputStream.Dispose();

            // Assert
            Assert.True( result.SequenceEqual( expectedData ) );
        }

        [Fact]
        public void WriteBlock_WriteManyEqualsBytes_WriteCompressed()
        {
            // Arrange
            var result = new byte[ 6 ];
            IOutputStream compressionOutputStream = new CompressionOutputStream( new MemoryOutputStream( result ) );
            var inputData = new byte[] { 1, 1, 1, 1, 2, 2, 2, 2, 2 };
            var expectedData = new byte[] { 255, 0, 1, 255, 1, 2 };

            // Act
            compressionOutputStream.WriteBlock( inputData, ( uint )inputData.Length );
            compressionOutputStream.Dispose();

            // Assert
            Assert.True( result.SequenceEqual( expectedData ) );
        }
    }
}
