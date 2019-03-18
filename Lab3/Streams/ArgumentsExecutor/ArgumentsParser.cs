namespace Streams.ArgumentsExecutor
{
    class ArgumentsParser
    {
        private int _index = 0;

        private string[] _arguments;

        public bool HasNext { get => _index != _arguments.Length; }

        public int NextArgumentsCount { get => _arguments.Length - _index; }

        public ArgumentsParser( string[] arguments )
        {
            _arguments = arguments;
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
    }
}

