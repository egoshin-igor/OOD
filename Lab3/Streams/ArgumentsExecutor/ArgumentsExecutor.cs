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

        public ArgumentsExecutor( string[] arguments )
        {
            _arguments = arguments;
        }

        public void Execute()
        {
            ParseFileNames();
            List<ArgumentOption> argumentOptions = GetArgumentOptions();
            bool isArgumentTypesNotSimular = argumentOptions.Select( ao => ao.Type ).Distinct().Count() != 1;
            if ( isArgumentTypesNotSimular )
            {
                throw new ApplicationException( "Arguments must be only input or output options" );
            }

            ArgumentType type = argumentOptions.First().Type;
            if ( type == ArgumentType.Input )
            {
                argumentOptions.Reverse();
            }

            IInputStream inputStream = new FileInputStream( _inputFileName );
            IOutputStream outputStream = new FileOutputStream( _outputFileName );
            DecorateByArgumentOptions( argumentOptions, ref inputStream, ref outputStream );

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

        private List<ArgumentOption> GetArgumentOptions()
        {
            var result = new List<ArgumentOption>();
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
                        result.Add( new ArgumentOption( ArgumentType.Output, "--encrypt", key ) );
                        break;
                    case "--decrypt":
                        key = argumentsParser.HasNext ? argumentsParser.GetNextAsInt() : null;
                        if ( key == null )
                        {
                            throw new ApplicationException( "Invalid command" );
                        }
                        result.Add( new ArgumentOption( ArgumentType.Input, "--decrypt", key ) );
                        break;
                    case "--compress":
                        result.Add( new ArgumentOption( ArgumentType.Output, "--compress" ) );
                        break;
                    case "--decompress":
                        result.Add( new ArgumentOption( ArgumentType.Input, "--decompress" ) );
                        break;
                    default:
                        throw new ApplicationException( "Invalid command" );
                }
            }

            return result;
        }

        public void DecorateByArgumentOptions( List<ArgumentOption> argumentOptions, ref IInputStream inputStream, ref IOutputStream outputStream )
        {
            if ( argumentOptions.Count == 0 )
            {
                return;
            }

            foreach ( ArgumentOption argumentOption in argumentOptions )
            {
                switch ( argumentOption.FirstArgument )
                {
                    case "--encrypt":
                        outputStream = new EncodingOutputStream( outputStream, argumentOption.SecondArgument.Value );
                        break;
                    case "--decrypt":
                        inputStream = new DecodingInputStream( inputStream, argumentOption.SecondArgument.Value );
                        break;
                    case "--compress":
                        outputStream = new CompressionOutputStream( outputStream );
                        break;
                    case "--decompress":
                        inputStream = new DecompressionInputStream( inputStream );
                        break;
                    default:
                        break;
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
