using System;
using System.Collections.Generic;
using System.Linq;
using Streams.OutputStream;
using Xunit;

namespace Streams.Test.OutputStream
{
    public class FileOutputStreamTest
    {
        [Fact]
        public void WriteByte_ByteIsWritten()
        {
            // Arrange
            string fileName = GetTempFileName();
            IOutputStream fileOutputStream = new FileOutputStream( fileName );
            byte data = 1;

            // Act
            fileOutputStream.WriteByte( data );
            fileOutputStream.Dispose();

            // Assert
            Assert.True( IsEqualsDataFromFile( fileName, data ) );
        }

        [Fact]
        public void WriteBlock_WriteFirstByteFromArray_WrittenOnlyOneByte()
        {
            // Arrange
            string fileName = GetTempFileName();
            IOutputStream fileOutputStream = new FileOutputStream( fileName );
            var data = new byte[] { 1, 2, 3 };
            var expectedWrittenData = new byte[] { 1 };

            // Act
            fileOutputStream.WriteBlock( data, size: 1 );
            fileOutputStream.Dispose();

            // Assert
            Assert.True( IsEqualsDataFromFile( fileName, expectedWrittenData ) );
        }

        [Fact]
        public void WriteBlock_WriteAllFromArray_AllDataIsWritten()
        {
            // Arrange
            string fileName = GetTempFileName();
            IOutputStream fileOutputStream = new FileOutputStream( fileName );
            var data = new byte[] { 1, 2, 3 };

            // Act
            fileOutputStream.WriteBlock( data, size: ( uint )data.Length );
            fileOutputStream.Dispose();

            // Assert
            Assert.True( IsEqualsDataFromFile( fileName, data ) );
        }

        private bool IsEqualsDataFromFile( string fileName, byte[] data )
        {
            byte[] expectedResult = System.IO.File.ReadAllBytes( fileName );
            return expectedResult.SequenceEqual( data );
        }

        private bool IsEqualsDataFromFile( string fileName, byte data )
        {
            return IsEqualsDataFromFile( fileName, new byte[] { data } );
        }

        private string GetTempFileName()
        {
            return System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".txt";
        }
    }
}
