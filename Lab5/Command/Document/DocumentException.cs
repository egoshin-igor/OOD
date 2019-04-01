using System;

namespace Command.Document
{
    public class DocumentException : ApplicationException
    {
        public DocumentException()
            : base()
        {
        }

        public DocumentException( string message )
            : base( message )
        {
        }
    }
}
