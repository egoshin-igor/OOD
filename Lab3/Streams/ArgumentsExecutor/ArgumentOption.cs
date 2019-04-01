namespace Streams.ArgumentsExecutor
{
    public class ArgumentOption
    {
        public ArgumentType Type { get; private set; }
        public string FirstArgument { get; private set; }
        public int? SecondArgument { get; private set; }

        public ArgumentOption( ArgumentType type, string firstArgument, int? secondArgument = null )
        {
            Type = type;
            FirstArgument = firstArgument;
            SecondArgument = secondArgument;
        }

    }
}
