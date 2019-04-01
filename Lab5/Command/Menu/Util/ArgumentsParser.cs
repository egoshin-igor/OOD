using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Command.Menu.Util
{
    public class ArgumentsParser
    {
        private int _index = 0;

        private string[] _arguments;

        public bool HasNext { get => _index != _arguments.Length; }

        public int NextArgumentsCount { get => _arguments.Length - _index; }

        public ArgumentsParser( string arguments )
        {
            if ( arguments != null )
            {
                _arguments = SplitToArguments( arguments );
            }
            else
            {
                _arguments = new string[ 0 ];
            }
        }

        public string GetNextAsString()
        {
            return _arguments[ _index++ ];
        }

        public int? GetNextAsInt()
        {
            int result;
            if ( int.TryParse( GetNextAsString(), out result ) )
            {
                return result;
            }

            return null;
        }

        private string[] SplitToArguments( string str )
        {
            return Regex.Matches( str, @"[\""].+?[\""]|[^ ]+" )
                .Cast<Match>()
                .Select( m =>
                {
                    string param = m.Value;
                    if ( param.Length < 2 )
                    {
                        return param;
                    }

                    int lastIndex = param.Length - 1;
                    if ( param[ 0 ] == '\"' && param[ lastIndex ] == '\"' )
                    {
                        return param.Substring( 1, param.Length - 2 );
                    }

                    return param;
                } )
                .ToArray();
        }
    }
}
