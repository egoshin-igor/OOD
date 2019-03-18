using System;
using System.Collections.Generic;
using System.Linq;
using Streams.InputStream;
using Streams.OutputStream;

namespace Streams.ArgumentsExecutor
{
    public class ArgumentsExecutor
    {
        private string _inputFileName = null;
        private string _outputFileName = null;
        private readonly string[] _arguments;
        private Queue<Action> _transformQueue = new Queue<Action>();

        public ArgumentsExecutor( string[] arguments )
        {
            _arguments = arguments;
        }

        public void Execute()
        {
            ParseFileNames();

            IInputStream inputStream = new FileInputStream( _inputFileName );
            IOutputStream outputStream = new FileOutputStream( _inputFileName );

            ParseCommands( ref inputStream, ref outputStream );
            WriteFromTo( inputStream, outputStream );

            inputStream.Dispose();
            outputStream.Dispose();
        }

        private void ParseFileNames()
        {
            int length = _arguments.Length;
            if ( length < 2 )
            {
                throw new ApplicationException( "Arguments count must be more than one" );
            }

            _outputFileName = _arguments[ length - 1 ];
            _inputFileName = _arguments[ length - 2 ];
        }

        private void ParseCommands( ref IInputStream inputStream, ref IOutputStream outputStream )
        {
            int? key = null;
            var argumentsParser = new ArgumentsParser( _arguments.Take( _arguments.Length - 2 ).ToArray() );
            while ( argumentsParser.HasNext )
            {
                switch ( argumentsParser.GetNextAsString() )
                {
                    case "--encrypt":
                        key = argumentsParser.HasNext ? argumentsParser.GetNextAsInt() : null;
                        if ( key == null )
                        {
                            throw new ApplicationException( "Invalid command" );
                        }
                        outputStream = new EncodingOutputStream( outputStream, key.Value );
                        break;
                    case "--decrypt":
                        key = argumentsParser.HasNext ? argumentsParser.GetNextAsInt() : null;
                        if ( key == null )
                        {
                            throw new ApplicationException( "Invalid command" );
                        }
                        inputStream = new DecodingInputStream( inputStream, key.Value );
                        break;
                    case "--compress":
                        outputStream = new СompressionOutputStream( outputStream );
                        break;
                    case "--decompress":
                        inputStream = new DecompressionInputStream( inputStream );
                        break;
                    default:
                        throw new ApplicationException( "Invalid command" );
                }
            }
        }

        private void WriteFromTo( IInputStream from, IOutputStream to )
        {
            while ( !from.IsEof )
            {
                to.WriteByte( ( byte )from.ReadByte() );
            }
        }

        private void InvalidCommandException()
        {
            throw new ApplicationException( "Invalid command" );
        }
    }
}
