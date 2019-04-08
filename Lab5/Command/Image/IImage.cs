using System;

namespace Command.Image
{
    public interface IImage : IDisposable
    {
        int Width { get; }
        int Height { get; }
        string Path { get; }
        string FileExtrension { get; }
        void Resize( int width, int height );
    }
}
