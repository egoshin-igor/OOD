using System.Drawing;
using System.Numerics;
using SkiaSharp;

namespace Composite.Canvas.Utils
{
    public static class SkiaUtil
    {
        public static SKColor ToSkiaColor( this Color color )
        {
            return new SKColor( color.R, color.G, color.B, color.A );
        }

        public static SKPoint ToSkiaPoint( this Vector2 point )
        {
            return new SKPoint( point.X, point.Y );
        }

        public static SKPoint[] ToSkiaPoints( this Vector2[] points )
        {
            var result = new SKPoint[ points.Length ];

            for ( int i = 0; i < result.Length; i++ )
            {
                result[ i ] = points[ i ].ToSkiaPoint();
            }

            return result;
        }
    }
}
