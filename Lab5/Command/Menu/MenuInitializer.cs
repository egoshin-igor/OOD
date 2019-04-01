﻿using System;
using System.Collections.Generic;
using Command.Document;
using Command.Document.Command;
using Command.Menu.Util;
using ICommand = Command.Document.Command.ICommand;

namespace Command.Menu
{
    public class MenuInitializer
    {
        private readonly Menu _menu;
        private readonly List<ICommand> _commands = new List<ICommand>();
        private readonly List<ICommand> _cancelledCommands = new List<ICommand>();

        public MenuInitializer()
        {
            var documentHistory = new DocumentHistory( _commands, _cancelledCommands );
            IDocument document = new Document.Document( documentHistory );
            _menu = new Menu( document );
        }

        public Menu GetInited()
        {
            InitInsertParagraphMenuItem();
            InitHelp();
            InitSave();
            InitSetTitle();
            InitReplaceText();
            InitDeleteItem();
            InitUndoItem();
            InitRedoItem();
            InitListItem();
            InitInsertImageItem();
            InitResizeImageItem();

            return _menu;
        }

        private void AddCommand( ICommand command )
        {
            _cancelledCommands.Clear();
            _commands.Add( command );
            if ( _commands.Count > 10 )
            {
                _commands.RemoveAt( 0 );
            }
        }

        private void InitInsertParagraphMenuItem()
        {
            string description = $"Print <InsertParagraph> <position|end> <text> to save paragraph on document";

            _menu.AddItem( shortcut: "InsertParagraph", description, InsertParagraphCommandExecutor );
        }

        private void InitHelp()
        {
            _menu.AddItem(
                shortcut: "Help",
                description: "Print <Help> to show command info",
                ( arguments, doc ) => Console.WriteLine( _menu.GetCommandsInfo() )
            );
        }

        private void InitSave()
        {
            _menu.AddItem(
                shortcut: "Save",
                description: "Print <Save> <path> to save document",
                SaveCommandExecutor
            );
        }

        private void InitSetTitle()
        {
            _menu.AddItem(
                shortcut: "SetTitle",
                description: "Print <SetTitle> <title> to define your document title",
                SetTitleCommandExecutor
            );
        }

        private void InitReplaceText()
        {
            _menu.AddItem(
                shortcut: "ReplaceText",
                description: "Print <ReplaceText> <position> <text> to replace selected text from paragraph",
                ReplaceTextCommandExecutor
            );
        }

        private void InitDeleteItem()
        {
            _menu.AddItem(
                shortcut: "DeleteItem",
                description: "Print <DeleteItem> <position> to delete item on position",
                DeleteItemCommandExecutor
            );
        }

        private void InitUndoItem()
        {
            _menu.AddItem(
                shortcut: "Undo",
                description: "Print <Undo> to undo previous command",
                UndoCommandExecutor
            );
        }

        private void InitRedoItem()
        {
            _menu.AddItem(
                shortcut: "Redo",
                description: "Print <Redo> to redo command",
                RedoCommandExecutor
            );
        }

        private void InitListItem()
        {
            _menu.AddItem(
                shortcut: "List",
                description: "Print <List> to show document items",
                ListCommandExecutor
            );
        }

        private void InitInsertImageItem()
        {
            _menu.AddItem(
                shortcut: "InsertImage",
                description: "Print <InsertImage> <position> <weight> <height> <path> to insert image to document",
                InsertImageCommandExecutor
            );
        }

        private void InitResizeImageItem()
        {
            _menu.AddItem(
                shortcut: "ResizeImage",
                description: "Print <ResizeImage> <position> <weight> <height> to resize image",
                ResizeImageCommandExecutor
            );
        }

        private void InsertParagraphCommandExecutor( string commandParams, IDocument document )
        {
            var argumentsParser = new ArgumentsParser( commandParams );
            if ( argumentsParser.NextArgumentsCount != 2 )
            {
                throw new MenuException();
            }

            int? position = GetPosition( argumentsParser.GetNextAsString() );
            string text = argumentsParser.GetNextAsString();

            ICommand command =
                new InsertParagraphCommand( new Paragraph.Paragraph( text ), document, position );
            command.Execute();
            AddCommand( command );
        }

        private void SaveCommandExecutor( string commandParams, IDocument document )
        {
            var argumentsParser = new ArgumentsParser( commandParams );
            if ( argumentsParser.NextArgumentsCount != 1 )
            {
                throw new MenuException();
            }

            document.Save( argumentsParser.GetNextAsString() );
        }

        private void SetTitleCommandExecutor( string commandParams, IDocument document )
        {
            var argumentsParser = new ArgumentsParser( commandParams );
            if ( argumentsParser.NextArgumentsCount != 1 )
            {
                throw new MenuException();
            }

            ICommand command = new SetTitleCommand( argumentsParser.GetNextAsString(), document );
            command.Execute();
            AddCommand( command );
        }

        private void ReplaceTextCommandExecutor( string commandParams, IDocument document )
        {
            var argumentsParser = new ArgumentsParser( commandParams );
            if ( argumentsParser.NextArgumentsCount != 2 )
            {
                throw new MenuException();
            }

            int? position = argumentsParser.GetNextAsInt();
            if ( position == null )
            {
                throw new MenuException();
            }
            string text = argumentsParser.GetNextAsString();

            ICommand command = new ReplaceTextCommand( position.Value, text, document );
            command.Execute();
            AddCommand( command );
        }

        public void DeleteItemCommandExecutor( string commandParams, IDocument document )
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

            ICommand command = new DeleteItemCommand( position.Value, document );
            command.Execute();
            AddCommand( command );
        }

        public void UndoCommandExecutor( string commandParams, IDocument document )
        {
            var argumentsParser = new ArgumentsParser( commandParams );
            if ( argumentsParser.NextArgumentsCount != 0 )
            {
                throw new MenuException();
            }

            document.Undo();
        }

        public void RedoCommandExecutor( string commandParams, IDocument document )
        {
            var argumentsParser = new ArgumentsParser( commandParams );
            if ( argumentsParser.NextArgumentsCount != 0 )
            {
                throw new MenuException();
            }

            document.Redo();
        }

        private void ListCommandExecutor( string commandParams, IDocument document )
        {
            var argumentsParser = new ArgumentsParser( commandParams );
            if ( argumentsParser.NextArgumentsCount != 0 )
            {
                throw new MenuException();
            }

            Console.WriteLine( _menu.GetDocumentInfo() );
        }

        private void InsertImageCommandExecutor( string commandParams, IDocument document )
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

            ICommand command =
                new InsertImageCommand( new Image.Image( path, weight.Value, height.Value ), document, position );
            command.Execute();
            AddCommand( command );
        }

        private void ResizeImageCommandExecutor( string commandParams, IDocument document )
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

            ICommand command = new ResizeImageCommand( position.Value, weight.Value, height.Value, document );
            command.Execute();
            AddCommand( command );
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