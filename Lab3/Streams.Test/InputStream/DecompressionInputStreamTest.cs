using System.Linq;
using Streams.InputStream;
using Xunit;

namespace Streams.Test.InputStream
{
    public class DecompressionInputStreamTest
    {
        [Fact]
        public void ReadByte_ReadSingleByte_ReadCorrect()
        {
            // Arrange
            var inputData = new byte[] { 1, 2 };
            IInputStream decompressionInputStream = new DecompressionInputStream( new MemoryInputStream( inputData ) );

            // Act
            int result = decompressionInputStream.ReadByte();
            decompressionInputStream.Dispose();

            // Assert
            Assert.Equal( 1, result );
        }

        [Fact]
        public void ReadByte_ReadFromCompressedByte_ReadCorrect()
        {
            // Arrange
            var inputData = new byte[] { 255, 3, 4 };
            IInputStream decompressionInputStream = new DecompressionInputStream( new MemoryInputStream( inputData ) );

            // Act
            int result = decompressionInputStream.ReadByte();
            decompressionInputStream.Dispose();

            // Assert
            Assert.Equal( 4, result );
        }

        [Fact]
        public void ReadByte_ReadBytesEqualsMarker_ReadCorrect()
        {
            // Arrange
            var inputData = new byte[] { 255, 255 };
            IInputStream decompressionInputStream = new DecompressionInputStream( new MemoryInputStream( inputData ) );

            // Act
            int result = decompressionInputStream.ReadByte();
            decompressionInputStream.Dispose();

            // Assert
            Assert.Equal( 255, result );
        }

        [Fact]
        public void ReadBlock_ReadFromCompressedByte_ReadCorrect()
        {
            // Arrange
            var inputData = new byte[] { 255, 3, 4 };
            IInputStream decompressionInputStream = new DecompressionInputStream( new MemoryInputStream( inputData ) );
            var buffer = new byte[ 3 ];
            var expectedData = new byte[] { 4, 4, 4 };

            // Act
            int readSize = decompressionInputStream.ReadBlock( buffer, 3 );
            decompressionInputStream.Dispose();

            // Assert
            Assert.Equal( 3, readSize );
            Assert.True( buffer.SequenceEqual( expectedData ) );
        }
    }
}
