using Command.Document.Item.Enum;
using Command.Image;
using Command.Paragraph;

namespace Command.Document.Item
{
    public class DocumentItem
    {
        public DocumentItemType Type { get; private set; }
        public IImage Image { get; private set; }
        public IParagraph Paragraph { get; private set; }

        public DocumentItem( IImage image )
        {
            Image = image;
            Type = DocumentItemType.Image;
            Paragraph = null;
        }

        public DocumentItem( IParagraph paragraph )
        {
            Paragraph = paragraph;
            Type = DocumentItemType.Paragraph;
            Image = null;
        }

        public string GetDescription()
        {
            if ( Type == DocumentItemType.Paragraph )
            {
                return $"Paragraph: {Paragraph.Text}";
            }
            else
            {
                return $"Image: {Image.Width} {Image.Height} {Image.Path}";
            }
        }
    }
}
