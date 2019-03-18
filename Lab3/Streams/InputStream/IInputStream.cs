using System;

namespace Streams.InputStream
{
    public interface IInputStream : IDisposable
    {
        bool IsEof { get; }
        int ReadByte();
        int ReadBlock( byte[] buffer, uint count );
    }
}
