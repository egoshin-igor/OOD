namespace Command.Paragraph
{
    public class Paragraph : IParagraph
    {
        public string Text { get; set; }

        public Paragraph( string text )
        {
            Text = text;
        }
    }
}
