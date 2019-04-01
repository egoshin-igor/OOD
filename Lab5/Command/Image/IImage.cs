namespace Command.Image
{
    public interface IImage
    {
        int Width { get; }
        int Height { get; }
        string Path { get; }
        void Resize( int width, int height );
    }
}
