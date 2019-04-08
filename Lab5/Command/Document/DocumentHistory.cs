using System.Collections.Generic;
using System.Linq;
using Command.Document.Command;

namespace Command.Document
{
    public class DocumentHistory : IDocumentHistory
    {
        private readonly List<ICommand> _commands = new List<ICommand>();
        private readonly List<ICommand> _cancelledCommands = new List<ICommand>();
        private bool _isDocumentHistoryLocked = false;

        public bool CanRedo => _cancelledCommands.Any();
        public bool CanUndo => _commands.Any();

        public DocumentHistory()
        {
        }

        public virtual void Undo()
        {
            if ( !CanUndo )
            {
                throw new DocumentException( "Undo can not be executed" );
            }

            ICommand command = _commands.Last();
            _isDocumentHistoryLocked = true;
            command.Unexecute();
            _isDocumentHistoryLocked = false;
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
            _isDocumentHistoryLocked = true;
            command.Execute();
            _isDocumentHistoryLocked = false;
            _cancelledCommands.RemoveAt( _cancelledCommands.Count - 1 );

            _commands.Add( command );
        }

        public virtual void AddToHistory( ICommand command )
        {
            const int maxCommandsQuantity = 10;
            if ( _isDocumentHistoryLocked )
            {
                return;
            }

            while ( _cancelledCommands.Count > 0 )
            {
                _cancelledCommands[ _cancelledCommands.Count - 1 ].Dispose();
                _cancelledCommands.RemoveAt( _cancelledCommands.Count - 1 );
            }

            _commands.Add( command );
            if ( _commands.Count > maxCommandsQuantity )
            {
                _commands[ 0 ].Dispose();
                _commands.RemoveAt( 0 );
            }
        }
    }
}
