using System.Linq;
using Streams.OutputStream;
using Xunit;

namespace Streams.Test.OutputStream
{
    public class MemoryOutputStreamTest
    {
        [Fact]
        public void WriteByte_ByteIsWritten()
        {
            // Arrange
            var result = new byte[ 1 ];
            IOutputStream memoryOutputStream = new MemoryOutputStream( result );
            var expectedData = new byte[] { 1 };

            // Act
            memoryOutputStream.WriteByte( 1 );
            memoryOutputStream.Dispose();

            // Assert
            Assert.True( result.SequenceEqual( expectedData ) );
        }

        [Fact]
        public void WriteBlock_WriteFirstByteFromArray_WrittenOnlyOneByte()
        {
            // Arrange
            var result = new byte[ 1 ];
            IOutputStream memoryOutputStream = new MemoryOutputStream( result );
            var expectedData = new byte[] { 1 };

            // Act
            memoryOutputStream.WriteBlock( new byte[] { 1, 2 }, size: 1 );
            memoryOutputStream.Dispose();

            // Assert
            Assert.True( result.SequenceEqual( expectedData ) );
        }

        [Fact]
        public void WriteBlock_WriteAllFromArray_AllDataIsWritten()
        {
            // Arrange
            var result = new byte[ 3 ];
            IOutputStream memoryOutputStream = new MemoryOutputStream( result );
            var data = new byte[] { 1, 2, 3 };

            // Act
            memoryOutputStream.WriteBlock( data, size: ( uint )data.Length );
            memoryOutputStream.Dispose();

            // Assert
            Assert.True( result.SequenceEqual( data ) );
        }
    }
}
