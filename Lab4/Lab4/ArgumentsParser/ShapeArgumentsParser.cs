using Lab4.Enum;

namespace Lab4.ArgumentsParser
{
    class ShapeArgumentsParser
    {
        private int _index = 0;

        private string[] _arguments;

        public bool HasNext { get => _index != _arguments.Length; }

        public int NextArgumentsCount { get => _arguments.Length - _index; }

        public ShapeArgumentsParser( string[] arguments )
        {
            _arguments = arguments;
        }

        public string GetNextAsString()
        {
            return _arguments[ _index++ ];
        }

        public int GetNextAsInt()
        {
            return int.Parse( GetNextAsString() );
        }

        public double GetNextAsDouble()
        {
            return double.Parse( GetNextAsString() );
        }

        public ColorType GetNextAsColor()
        {
            return ( ColorType )System.Enum.Parse(
                typeof( ColorType ),
                GetNextAsString(),
                ignoreCase: true
            );
        }
    }
}
