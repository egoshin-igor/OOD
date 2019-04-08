using System;

namespace Command.Document.Command
{
    public interface ICommand : IDisposable
    {
        void Execute();
        void Unexecute();
    }
}
