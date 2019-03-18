using System;

namespace Streams.OutputStream
{
    public interface IOutputStream : IDisposable
    {
        void WriteByte( byte data );
        void WriteBlock( byte[] data, uint size );
        void Flush();
    }
}
