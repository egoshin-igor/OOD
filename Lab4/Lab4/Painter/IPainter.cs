using Lab4.Canvas;

namespace Lab4.Painter
{
    interface IPainter
    {
        void DrawPicture( PictureDraft pictureDraft, ICanvas canvas );
    }
}
