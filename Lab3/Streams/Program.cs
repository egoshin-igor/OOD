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
                PrintHelp();
            }
        }

        private static void PrintHelp()
        {
            Console.WriteLine( "Right program running:" );
            Console.WriteLine( "progam <options> <inpit-file> <output-file>" );
            Console.WriteLine( "<options>:" );
            Console.WriteLine( " --encrypt <key>" );
            Console.WriteLine( " --decrypt <key>" );
            Console.WriteLine( " --compress" );
            Console.WriteLine( " --decompress" );
        }
    }
}
