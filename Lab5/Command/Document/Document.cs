using System.Collections.Generic;
using System.IO;
using System.Text;
using Command.Document.Item;
using Command.Document.Util;
using Command.Image;
using Command.Paragraph;

namespace Command.Document
{
    public class Document : IDocument
    {
        private readonly List<DocumentItem> _items = new List<DocumentItem>();
        private readonly DocumentHistory _history;

        public int ItemsCount => _items.Count;
        public string Title { get; set; } = "Unnamed";
        public bool CanUndo => _history.CanUndo;
        public bool CanRedo => _history.CanRedo;

        public Document( DocumentHistory documentHistory )
        {
            _history = documentHistory;
        }

        public DocumentItem GetItem( int index )
        {
            if ( index < 0 || index >= ItemsCount )
            {
                throw new DocumentException( $"Nonexist get position {index}" );
            }

            return _items[ index ];
        }

        public void InsertImage( IImage image, int? position = null )
        {
            var imageDocumentItem = new DocumentItem( image );

            Insert( imageDocumentItem, position );
        }

        public void InsertParagraph( IParagraph paragraph, int? position = null )
        {
            var paragraphDocumentItem = new DocumentItem( paragraph );

            Insert( paragraphDocumentItem, position );
        }

        public void Redo()
        {
            _history.Redo();
        }

        public void Undo()
        {
            _history.Undo();
        }

        public void DeleteItem( int index )
        {
            if ( index < 0 || index >= _items.Count )
            {
                throw new DocumentException( $"Nonexist remove position {index}" );
            }

            _items.RemoveAt( index );
        }

        public void Save( string path )
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append( "<!DOCTYPE html>" );
            stringBuilder.Append( "<html>" );

            stringBuilder.Append( $"<head><meta charset=\"utf-8\"><title>{Title.GetEscaped()}</title></head>" );
            stringBuilder.Append( "<body>" ).Write( _items, path ).Append( "<body>" );

            stringBuilder.Append( "</html>" );

            Save( path, stringBuilder.ToString() );
        }

        private void Save( string path, string text )
        {
            using ( var sw = new StreamWriter( path + Title + ".html" ) )
            {
                sw.Write( text );
            }
        }

        private void Insert( DocumentItem documentItem, int? position )
        {
            if ( position.HasValue && ( position > _items.Count || position < 0 ) )
            {
                throw new DocumentException( $"Nonexist insert position {position}" );
            }

            if ( position.HasValue )
            {
                _items.Insert( position.Value, documentItem );
            }
            else
            {
                _items.Add( documentItem );
            }
        }
    }
}
