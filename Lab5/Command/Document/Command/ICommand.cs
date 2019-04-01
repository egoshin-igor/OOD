namespace Command.Document.Command
{
    public interface ICommand
    {
        void Execute();
        void Unexecute();
    }
}
