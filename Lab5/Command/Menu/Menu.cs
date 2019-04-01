using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Command.Document;

namespace Command.Menu
{
    public class Menu
    {
        private readonly List<MenuItem> _menuItems = new List<MenuItem>();
        private readonly IDocument _document;

        public Menu( IDocument document )
        {
            _document = document;
        }

        public void AddItem( string shortcut, string description, Action<string, IDocument> commandExecutor )
        {
            _menuItems.Add( new MenuItem( shortcut, description, commandExecutor ) );
        }

        public void Execute( string command )
        {
            int firstDelimeterIndex = command.IndexOf( value: " " );

            string shortcut;
            string commandParams = null;
            if ( firstDelimeterIndex == -1 )
            {
                shortcut = command;
            }
            else
            {
                shortcut = command.Substring( 0, firstDelimeterIndex );
                commandParams = command.Substring( firstDelimeterIndex + 1 );
            }

            MenuItem menuItem = _menuItems.FirstOrDefault( mi => mi.Shortcut == shortcut );

            if ( menuItem == null )
            {
                throw new MenuException();
            }

            menuItem.CommandExecuter( commandParams, _document );
        }

        public string GetCommandsInfo()
        {
            var resultBuilder = new StringBuilder();
            foreach ( MenuItem menuItem in _menuItems )
            {
                resultBuilder
                    .Append( "Shortcut: " + menuItem.Shortcut )
                    .Append( ". Description: " + menuItem.Description )
                    .Append( '\n' );
            }

            return resultBuilder.ToString();
        }

        public string GetDocumentInfo()
        {
            var resultBuilder = new StringBuilder();
            resultBuilder.Append( $"Title: {_document.Title}\n" );

            for ( int i = 0; i < _document.ItemsCount; i++ )
            {
                resultBuilder.Append( _document.GetItem( i ).GetDescription() ).Append( '\n' );
            }

            return resultBuilder.ToString();
        }
    }
}
