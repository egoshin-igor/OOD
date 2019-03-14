using System.Collections.Generic;
using Lab4.Shape;

namespace Lab4
{
    class PictureDraft
    {
        public List<BaseShape> Shapes { get; private set; }

        public int ShapeCount { get; private set; }

        public PictureDraft( List<BaseShape> shapes )
        {
            Shapes = new List<BaseShape>( shapes );
        }
    }
}
