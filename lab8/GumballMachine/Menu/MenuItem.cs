using System;

namespace GumballMachine.Menu
{
    public class MenuItem
    {
        public string Shortcut { get; }
        public string Description { get; }
        public Action<string> CommandExecuter { get; }

        public MenuItem( string shortcut, string description, Action<string> commandExecutor )
        {
            Shortcut = shortcut;
            Description = description;
            CommandExecuter = commandExecutor;
        }
    }
}
