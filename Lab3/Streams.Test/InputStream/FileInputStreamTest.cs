using System.Collections.Generic;
using System.Linq;
using Streams.InputStream;
using Xunit;

namespace Streams.Test.InputStream
{
    public class FileInputStreamTest
    {
        private const string TestFilesPath = "../../../InputStream/TestFiles";

        [Fact]
        public void ReadByte_FileIsEmpty_ReturnEndOfStreamIntCode()
        {
            // Arrange
            const int endOfFileCode = -1;
            IInputStream fileInputStream = new FileInputStream( $"{TestFilesPath}/EmptyFile.txt" );

            // Act
            int result = fileInputStream.ReadByte();
            fileInputStream.Dispose();

            // Assert
            Assert.Equal( endOfFileCode, result );
        }

        [Fact]
        public void ReadByte_FileWithData_ReturnFirstByte()
        {
            // Arrange
            const int expectedResult = 0x31;
            IInputStream fileInputStream = new FileInputStream( $"{TestFilesPath}/FileWithData.txt" );

            // Act
            int result = fileInputStream.ReadByte();
            fileInputStream.Dispose();

            // Assert
            Assert.Equal( expectedResult, result );
        }

        [Fact]
        public void ReadBlock_FileIsEmpty_ReadDataSizeEqualsZero()
        {
            // Arrange
            const int expectedResult = 0;
            IInputStream fileInputStream = new FileInputStream( $"{TestFilesPath}/emptyFile.txt" );

            // Act
            int result = fileInputStream.ReadBlock( buffer: new byte[ 1 ], count: 1 );
            fileInputStream.Dispose();

            // Assert
            Assert.Equal( expectedResult, result );
        }

        [Fact]
        public void ReadBlock_FileWithData_ReturnData()
        {
            // Arrange
            const int expectedReadSize = 3;
            var expectedBuffer = new byte[] { 0x31, 0x32, 0x33 };
            var buffer = new byte[ 3 ];
            IInputStream fileInputStream = new FileInputStream( $"{TestFilesPath}/FileWithData.txt" );

            // Act
            int readSize = fileInputStream.ReadBlock( buffer, count: 3 );
            fileInputStream.Dispose();

            // Assert
            Assert.Equal( expectedReadSize, readSize );
            Assert.Equal( expectedBuffer, buffer );
        }
    }
}
