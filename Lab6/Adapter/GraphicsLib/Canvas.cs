using System;

namespace Adapter.GraphicsLib
{
    public class Canvas : ICanvas
    {
        public void LineTo( int x, int y )
        {
            Console.WriteLine( $"LineTo ({ x }, { y })" );
        }

        public void MoveTo( int x, int y )
        {
            Console.WriteLine( $"MoveTo ({ x }, { y })" );
        }
    }
}
