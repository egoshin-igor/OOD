using System;
using Xunit;

namespace Streams.Test
{
    public class ByteShuffleUtilTest
    {
        [Fact]
        public void EncodeAndDecodeBytes_GetOriginBytes()
        {
            // Arrange
            Random random = new Random();
            int key = random.Next();

            byte[] encodingShuffledBytes = ByteShuffleUtil.GetEncodingShuffledBytes( key );
            byte[] decodingShuffledBytes = ByteShuffleUtil.GetDecodingShuffledBytes( key );

            bool result = true;

            // Act
            for ( int i = 0; i <= 255; i++ )
            {
                if ( i != decodingShuffledBytes[ encodingShuffledBytes[ i ] ] )
                {
                    result = false;
                    break;
                }
            }

            // Assert
            Assert.True( result );
        }
    }
}
