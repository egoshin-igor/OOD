﻿using System;
using Command.Document;

namespace Command.Menu
{
    public class MenuItem
    {
        public string Shortcut { get; }
        public string Description { get; }
        public Action<string, IDocument> CommandExecuter { get; }

        public MenuItem( string shortcut, string description, Action<string, IDocument> commandExecutor )
        {
            Shortcut = shortcut;
            Description = description;
            CommandExecuter = commandExecutor;
        }
    }
}