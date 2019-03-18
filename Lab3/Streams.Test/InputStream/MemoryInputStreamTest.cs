using Streams.InputStream;
using Xunit;

namespace Streams.Test.InputStream
{
    public class MemoryInputStreamTest
    {
        [Fact]
        public void ReadByte_EndOfStream_ReturnEndOfStreamIntCode()
        {
            // Arrange
            const int endOfFileCode = -1;
            IInputStream memoryInputStream = new MemoryInputStream( new byte[ 0 ] );

            // Act
            int result = memoryInputStream.ReadByte();
            memoryInputStream.Dispose();

            // Assert
            Assert.Equal( endOfFileCode, result );
        }

        [Fact]
        public void ReadByte_StreamWithData_ReturnFirstByte()
        {
            // Arrange
            const int expectedResult = 0x31;
            IInputStream memoryInputStream = new MemoryInputStream( new byte[] { 0x31, 0x32 } );

            // Act
            int result = memoryInputStream.ReadByte();
            memoryInputStream.Dispose();

            // Assert
            Assert.Equal( expectedResult, result );
        }

        [Fact]
        public void ReadBlock_EndOfStream_ReadDataSizeEqualsZero()
        {
            // Arrange
            const int expectedResult = 0;
            IInputStream memoryInputStream = new MemoryInputStream( new byte[ 0 ] );

            // Act
            int result = memoryInputStream.ReadBlock( buffer: new byte[ 1 ], count: 1 );
            memoryInputStream.Dispose();

            // Assert
            Assert.Equal( expectedResult, result );
        }

        [Fact]
        public void ReadBlock_StreamWithData_ReturnData()
        {
            // Arrange
            const int expectedReadSize = 3;
            var expectedBuffer = new byte[] { 0x31, 0x32, 0x33 };
            IInputStream memoryInputStream = new MemoryInputStream( new byte[] { 0x31, 0x32, 0x33 } );

            // Act
            var buffer = new byte[ 3 ];
            int readSize = memoryInputStream.ReadBlock( buffer, count: 3 );
            memoryInputStream.Dispose();

            // Assert
            Assert.Equal( expectedReadSize, readSize );
            Assert.Equal( expectedBuffer, buffer );
        }
    }
}
