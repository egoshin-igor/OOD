using System;
using System.Collections.Generic;
using System.Text;

namespace Streams.OutputStream
{
    interface IOutputStream : IDisposable
    {
        void WriteByte( byte data );
        void WriteBlock( byte[] data, uint size );
    }
}
