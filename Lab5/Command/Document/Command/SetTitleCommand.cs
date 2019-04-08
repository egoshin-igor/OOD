using System;
using System.Collections.Generic;
using System.Text;

namespace Command.Document.Command
{
    public class SetTitleCommand : ICommand
    {
        IDocument _document;
        private string _title;
        private string _previousTitle;

        public SetTitleCommand( string title, IDocument document )
        {
            _document = document;
            _title = title;
            _previousTitle = _document.Title;
        }

        public void Execute()
        {
            _previousTitle = _document.Title;
            _document.Title = _title;
        }

        public void Unexecute()
        {
            _document.Title = _previousTitle;
        }

        public void Dispose()
        {
        }
    }
}
