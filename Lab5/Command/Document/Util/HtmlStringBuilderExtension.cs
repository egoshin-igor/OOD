﻿using System;
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
            string referencePath = $"{Path.Combine( Directory.GetCurrentDirectory(), path )}/images/"
                .Replace( '\\', '/' );

            if ( documentItem.Type == DocumentItemType.Image )
            {
                string newPath = referencePath + Guid.NewGuid().ToString() + ".png";
                IImage image = documentItem.Image;
                try
                {
                    Directory.CreateDirectory( Path.GetDirectoryName( newPath ) );
                    File.Copy( image.Path, newPath, overwrite: true );
                }
                catch ( Exception ex )
                {
                    throw new DocumentException( $"File cant by copy: {ex.Message}" );
                }
                stringBuilder.Append( $"<img src=\"{newPath}\" width=\"{image.Width}\" height=\"{image.Height}\">" );
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
