using System;
using System.Collections.Generic;

namespace Streams
{
    public static class ByteShuffleUtil
    {
        public static byte[] GetEncodingShuffledBytes( int key )
        {
            var shuffledBytes = new byte[ 256 ];
            for ( int i = 0; i < shuffledBytes.Length; i++ )
            {
                shuffledBytes[ i ] = ( byte )i;
            }
            shuffledBytes.Shuffle( key );

            return shuffledBytes;
        }

        public static byte[] GetDecodingShuffledBytes( int key )
        {
            byte[] encodingShuffledBytes = GetEncodingShuffledBytes( key );

            byte[] decodingShuffledBytes = new byte[ 256 ];
            for ( int i = 0; i < decodingShuffledBytes.Length; i++ )
            {
                decodingShuffledBytes[ encodingShuffledBytes[ i ] ] = ( byte )i;
            }

            return decodingShuffledBytes;
        }

        private static void Shuffle( this IList<byte> list, int key )
        {
            Random random = new Random( key );
            int maxRandomValue = list.Count;
            while ( maxRandomValue > 1 )
            {
                maxRandomValue--;
                int i = random.Next( maxRandomValue + 1 );
                byte value = list[ i ];
                list[ i ] = list[ maxRandomValue ];
                list[ maxRandomValue ] = value;
            }
        }
    }
}
