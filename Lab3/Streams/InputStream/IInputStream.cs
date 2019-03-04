using System;

namespace Streams.InputStream
{
    interface IInputStream : IDisposable
    {
        bool IsEof();
        byte ReadByte();
        int ReadBlock( byte[] buffer, uint count );
    }
}
