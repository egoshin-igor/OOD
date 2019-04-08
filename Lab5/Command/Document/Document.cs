using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Command.Document.Command;
using Command.Document.Item;
using Command.Document.Util;
using Command.Image;

namespace Command.Document
{
    public class Document : IDocument
    {
        private readonly List<DocumentItem> _items = new List<DocumentItem>();
        private string _title = "Unnamed";

        public IDocumentHistory DocumentHistory { get; }
        public int ItemsCount => _items.Count;
        public bool CanUndo => DocumentHistory.CanUndo;
        public bool CanRedo => DocumentHistory.CanRedo;
        public string Title
        {
            get => _title;
            set
            {
                ICommand command = new SetTitleCommand( value, this );
                _title = value;
                DocumentHistory.AddToHistory( command );
            }
        }

        public Document( IDocumentHistory documentHistory )
        {
            DocumentHistory = documentHistory;
        }

        public DocumentItem GetItem( int index )
        {
            if ( index < 0 || index >= ItemsCount )
            {
                throw new DocumentException( $"Nonexist get position {index}" );
            }

            return _items[ index ];
        }

        public void InsertImage( string path, int weight, int height, int? position = null )
        {
            if ( position == null )
            {
                position = ItemsCount > 0 ? ItemsCount : 0;
            }

            string tempFileName = Path.GetTempFileName();
            try
            {
                File.Copy( path, tempFileName, overwrite: true );
            }
            catch ( Exception ex )
            {
                throw new DocumentException( $"File {path} copying is not possible. {ex.Message}" );
            }

            IImage temporaryImage = new Image.Image( tempFileName, Path.GetExtension( path ), weight, height );

            var imageDocumentItem = new DocumentItem( temporaryImage );

            Insert( imageDocumentItem, position.Value );
            ICommand command = new InsertImageCommand( path, weight, height, this, position );
            DocumentHistory.AddToHistory( command );
        }

        public void InsertParagraph( string text, int? position = null )
        {
            if ( position == null )
            {
                position = ItemsCount > 0 ? ItemsCount : 0;
            }

            var paragraphDocumentItem = new DocumentItem( new Paragraph.Paragraph( text ) );
            Insert( paragraphDocumentItem, position.Value );
            ICommand command = new InsertParagraphCommand( text, this, position );
            DocumentHistory.AddToHistory( command );
        }

        public void Redo()
        {
            DocumentHistory.Redo();
        }

        public void Undo()
        {
            DocumentHistory.Undo();
        }

        public void DeleteItem( int index )
        {
            if ( index < 0 || index >= _items.Count )
            {
                throw new DocumentException( $"Nonexist remove position {index}" );
            }

            IImage image = _items[ index ].Image;
            _items.RemoveAt( index );
            ICommand command = new DeleteItemCommand( index, this );
            DocumentHistory.AddToHistory( command );
        }

        public void Save( string path )
        {
            path = path.Replace( '\\', '/' );
            var stringBuilder = new StringBuilder();

            stringBuilder.Append( "<!DOCTYPE html>" );
            stringBuilder.Append( "<html>" );

            stringBuilder.Append( $"<head><meta charset=\"utf-8\"><title>{Title.GetEscaped()}</title></head>" );
            stringBuilder.Append( "<body>" ).Write( _items, path ).Append( "</body>" );

            stringBuilder.Append( "</html>" );

            Save( path, stringBuilder.ToString() );
        }

        private void Save( string path, string text )
        {
            try
            {
                using ( var sw = new StreamWriter( path ) )
                {
                    sw.Write( text );
                }
            }
            catch ( Exception ex )
            {
                throw new DocumentException( ex.Message );
            }
        }

        private void Insert( DocumentItem documentItem, int position )
        {
            if ( position > _items.Count || position < 0 )
            {
                throw new DocumentException( $"Nonexist insert position {position}" );
            }

            _items.Insert( position, documentItem );
        }
    }
}
