using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Command.Document.Item;
using Command.Document.Item.Enum;
using Command.Image;

namespace Command.Document.Util
{
    public static class HtmlStringBuilderExtension
    {
        public static StringBuilder Write( this StringBuilder stringBuilder, List<DocumentItem> documentItems, string path )
        {
            foreach ( DocumentItem documentItem in documentItems )
            {
                stringBuilder.Write( documentItem, path );
            }

            return stringBuilder;
        }

        public static StringBuilder Write( this StringBuilder stringBuilder, DocumentItem documentItem, string path )
        {
            const string referencePath = "images/";

            if ( documentItem.Type == DocumentItemType.Image )
            {
                string fullPath = Path.GetDirectoryName( path ) + $"/{referencePath}";
                IImage image = documentItem.Image;
                string newImageName = Guid.NewGuid().ToString() + image.FileExtrension;
                try
                {
                    Directory.CreateDirectory( fullPath );
                    File.Copy( image.Path, fullPath + newImageName, overwrite: true );
                }
                catch ( Exception ex )
                {
                    throw new DocumentException( $"File cant by copy: {ex.Message}" );
                }
                stringBuilder.Append( $"<img src=\"{referencePath + newImageName}\" width=\"{image.Width}\" height=\"{image.Height}\">" );
            }
            else if ( documentItem.Type == DocumentItemType.Paragraph )
            {
                stringBuilder.Append( $"<p>{documentItem.Paragraph.Text.GetEscaped()}</p>" );
            }
            else
            {
                throw new NotImplementedException( $"Unrecognized document item type - {documentItem.Type}" );
            }

            return stringBuilder;
        }
    }
}
