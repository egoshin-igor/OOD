using System;
using System.Text;
using Command.Document;
using Command.Document.Command;
using Command.Menu.Util;

namespace Command.Menu
{
    public class MenuSetup
    {
        private readonly Menu _menu;
        private readonly IDocument _document;

        public MenuSetup()
        {
            IDocumentHistory documentHistory = new DocumentHistory();
            _document = new Document.Document( documentHistory );
            _menu = new Menu();
        }

        public Menu GetSetuped()
        {
            string insertParagraphDescription
                = $"Print <InsertParagraph> <position|end> <text> to save paragraph on document";
            _menu.AddItem( shortcut: "InsertParagraph", insertParagraphDescription, InsertParagraphCommandExecutor );

            _menu.AddItem(
                shortcut: "Help",
                description: "Print <Help> to show command info",
                ( arguments ) => Console.WriteLine( _menu.GetCommandsInfo() )
            );

            _menu.AddItem(
                shortcut: "Save",
                description: "Print <Save> <path> to save document",
                SaveCommandExecutor
            );

            _menu.AddItem(
                shortcut: "SetTitle",
                description: "Print <SetTitle> <title> to define your document title",
                SetTitleCommandExecutor
            );

            _menu.AddItem(
                shortcut: "ReplaceText",
                description: "Print <ReplaceText> <position> <text> to replace selected text from paragraph",
                ReplaceTextCommandExecutor
            );

            _menu.AddItem(
                shortcut: "DeleteItem",
                description: "Print <DeleteItem> <position> to delete item on position",
                DeleteItemCommandExecutor
            );

            _menu.AddItem(
                shortcut: "Undo",
                description: "Print <Undo> to undo previous command",
                UndoCommandExecutor
            );

            _menu.AddItem(
                shortcut: "Redo",
                description: "Print <Redo> to redo command",
                RedoCommandExecutor
            );

            _menu.AddItem(
                shortcut: "List",
                description: "Print <List> to show document items",
                ListCommandExecutor
            );

            _menu.AddItem(
                shortcut: "InsertImage",
                description: "Print <InsertImage> <position> <weight> <height> <path> to insert image to document",
                InsertImageCommandExecutor
            );

            _menu.AddItem(
                shortcut: "ResizeImage",
                description: "Print <ResizeImage> <position> <weight> <height> to resize image",
                ResizeImageCommandExecutor
            );

            return _menu;
        }

        private void InsertParagraphCommandExecutor( string commandParams )
        {
            var argumentsParser = new ArgumentsParser( commandParams );
            if ( argumentsParser.NextArgumentsCount < 2 )
            {
                throw new MenuException();
            }

            int? position = GetPosition( argumentsParser.GetNextAsString() );
            string text = argumentsParser.GetNextsAsString( ' ' );

            ICommand command = new InsertParagraphCommand( text, _document, position );
            command.Execute();
        }

        private void SaveCommandExecutor( string commandParams )
        {
            var argumentsParser = new ArgumentsParser( commandParams );
            if ( argumentsParser.NextArgumentsCount != 1 )
            {
                throw new MenuException();
            }

            _document.Save( argumentsParser.GetNextAsString() );
        }

        private void SetTitleCommandExecutor( string commandParams )
        {
            var argumentsParser = new ArgumentsParser( commandParams );
            if ( argumentsParser.NextArgumentsCount < 1 )
            {
                throw new MenuException();
            }

            ICommand command = new SetTitleCommand( argumentsParser.GetNextsAsString( ' ' ), _document );
            command.Execute();
        }

        private void ReplaceTextCommandExecutor( string commandParams )
        {
            var argumentsParser = new ArgumentsParser( commandParams );
            if ( argumentsParser.NextArgumentsCount < 2 )
            {
                throw new MenuException();
            }

            int? position = argumentsParser.GetNextAsInt();
            if ( position == null )
            {
                throw new MenuException();
            }
            string text = argumentsParser.GetNextsAsString( ' ' );

            ICommand command = new ReplaceTextCommand( position.Value, text, _document );
            command.Execute();
        }

        public void DeleteItemCommandExecutor( string commandParams )
        {
            var argumentsParser = new ArgumentsParser( commandParams );
            if ( argumentsParser.NextArgumentsCount != 1 )
            {
                throw new MenuException();
            }

            int? position = argumentsParser.GetNextAsInt();
            if ( position == null )
            {
                throw new MenuException();
            }

            ICommand command = new DeleteItemCommand( position.Value, _document );
            command.Execute();
        }

        public void UndoCommandExecutor( string commandParams )
        {
            var argumentsParser = new ArgumentsParser( commandParams );
            if ( argumentsParser.NextArgumentsCount != 0 )
            {
                throw new MenuException();
            }

            _document.Undo();
        }

        public void RedoCommandExecutor( string commandParams )
        {
            var argumentsParser = new ArgumentsParser( commandParams );
            if ( argumentsParser.NextArgumentsCount != 0 )
            {
                throw new MenuException();
            }

            _document.Redo();
        }

        private void ListCommandExecutor( string commandParams )
        {
            var argumentsParser = new ArgumentsParser( commandParams );
            if ( argumentsParser.NextArgumentsCount != 0 )
            {
                throw new MenuException();
            }

            Console.WriteLine( GetDocumentInfo() );
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

        private void InsertImageCommandExecutor( string commandParams )
        {
            var argumentsParser = new ArgumentsParser( commandParams );
            if ( argumentsParser.NextArgumentsCount != 4 )
            {
                throw new MenuException();
            }

            int? position = GetPosition( argumentsParser.GetNextAsString() );
            int? weight = argumentsParser.GetNextAsInt();
            int? height = argumentsParser.GetNextAsInt();
            if ( weight == null || height == null )
            {
                throw new MenuException();
            }
            string path = argumentsParser.GetNextAsString();

            ICommand command = new InsertImageCommand( path, weight.Value, height.Value, _document, position );
            command.Execute();
        }

        private void ResizeImageCommandExecutor( string commandParams )
        {
            var argumentsParser = new ArgumentsParser( commandParams );
            if ( argumentsParser.NextArgumentsCount != 3 )
            {
                throw new MenuException();
            }

            int? position = argumentsParser.GetNextAsInt();
            int? weight = argumentsParser.GetNextAsInt();
            int? height = argumentsParser.GetNextAsInt();
            if ( position == null || weight == null || height == null )
            {
                throw new MenuException();
            }

            ICommand command = new ResizeImageCommand( position.Value, weight.Value, height.Value, _document );
            command.Execute();
        }

        private int? GetPosition( string argument )
        {
            int? result = null;

            if ( argument != "end" )
            {
                int intArgument;
                if ( int.TryParse( argument, out intArgument ) )
                {
                    result = intArgument;
                }
                else
                {
                    throw new MenuException();
                }
            }

            return result;
        }
    }
}
