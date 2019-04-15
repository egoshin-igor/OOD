using System;

namespace Adapter.ModernGrapicsLib
{
    public class GraphicsLogicalException : Exception
    {
        public GraphicsLogicalException()
            : base()
        {
        }

        public GraphicsLogicalException( string message )
            : base( message )
        {
        }
    }
}
