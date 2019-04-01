using System;
using System.Collections.Generic;
using System.Linq;
using Command.Document.Command;

namespace Command.Document
{
    public class DocumentHistory : IDocumentHistory
    {
        private readonly List<ICommand> _commands;
        private readonly List<ICommand> _cancelledCommands;

        public bool CanRedo => _cancelledCommands.Any();
        public bool CanUndo => _commands.Any();

        public bool CanRendo => throw new NotImplementedException();

        protected DocumentHistory()
        {
        }

        public DocumentHistory( List<ICommand> commands, List<ICommand> cancelledCommands )
        {
            _commands = commands;
            _cancelledCommands = cancelledCommands;
        }

        public virtual void Undo()
        {
            if ( !CanUndo )
            {
                throw new DocumentException( "Undo can not be executed" );
            }

            ICommand command = _commands.Last();
            command.Unexecute();
            _commands.RemoveAt( _commands.Count - 1 );

            _cancelledCommands.Add( command );
        }

        public virtual void Redo()
        {
            if ( !CanRedo )
            {
                throw new DocumentException( "Redo can not be executed" );
            }

            ICommand command = _cancelledCommands.Last();
            command.Execute();
            _cancelledCommands.RemoveAt( _cancelledCommands.Count - 1 );

            _commands.Add( command );
        }
    }
}
