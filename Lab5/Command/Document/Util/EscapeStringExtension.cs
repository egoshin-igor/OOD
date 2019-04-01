namespace Command.Document.Util
{
    public static class EscapeStringExtension
    {
        public static string GetEscaped( this string text )
        {
            return Microsoft.Security.Application.Encoder.HtmlEncode( text );
        }
    }
}
