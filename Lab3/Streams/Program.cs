using System;

namespace Streams
{
    public class Program
    {
        static void Main( string[] args )
        {
            var argumentsExecutor = new ArgumentsExecutor.ArgumentsExecutor( args );
            try
            {
                argumentsExecutor.Execute();
            }
            catch ( ApplicationException ex )
            {
                Console.WriteLine( ex.Message );
            }
        }
    }
}
