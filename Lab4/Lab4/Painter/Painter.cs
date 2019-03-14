using System;
using Lab4.Canvas;
using Lab4.Shape;

namespace Lab4.Painter
{
    class Painter : IPainter
    {
        public void DrawPicture( PictureDraft pictureDraft, ICanvas canvas )
        {
            foreach ( BaseShape shape in pictureDraft.Shapes )
            {
                Console.WriteLine( $"Shape: {shape.GetType().Name}" );
                shape.Draw( canvas );
                Console.WriteLine( $"-----------------------------" );
            }
        }
    }
}
