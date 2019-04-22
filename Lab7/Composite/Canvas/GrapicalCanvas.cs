using System;
using System.Drawing;
using System.IO;
using System.Numerics;
using Composite.Canvas.Utils;
using SkiaSharp;

namespace Composite.Canvas
{
    public class GrapicalCanvas : ICanvas
    {
        private SKBitmap _skiaBitmap;
        private SKCanvas _skiaCanvas;
        private SKPaint _skiaPaint;

        public float LineThickness { private get; set; } = 1;
        public Color FillColor { private get; set; } = Color.Empty;
        public Color LineColor { private get; set; } = Color.Black;

        public GrapicalCanvas( int width, int height )
        {
            _skiaBitmap = new SKBitmap( width, height );
            _skiaCanvas = new SKCanvas( _skiaBitmap );
            _skiaPaint = new SKPaint { IsAntialias = true };
        }

        public void DrawEllipse( float left, float top, float width, float height )
        {
            var skiaRect = new SKRect( left, top, left + width, top - width );

            SetFillStyle();
            _skiaCanvas.DrawOval( skiaRect, _skiaPaint );
            SetLineStyle();
            _skiaCanvas.DrawOval( skiaRect, _skiaPaint );
        }

        public void DrawLine( Vector2 from, Vector2 to )
        {
            SetLineStyle();
            _skiaCanvas.DrawLine( from.ToSkiaPoint(), to.ToSkiaPoint(), _skiaPaint );
        }

        public void DrawPolygon( Vector2[] points )
        {
            const int minPointsCount = 3;

            if ( points.Length < minPointsCount )
            {
                throw new ApplicationException( $"Polygon drawing requires {minPointsCount} points" );
            }

            SKPath path = new SKPath();
            path.AddPoly( points.ToSkiaPoints() );

            SetFillStyle();
            _skiaCanvas.DrawPath( path, _skiaPaint );
            SetLineStyle();
            _skiaCanvas.DrawPath( path, _skiaPaint );
        }

        public void Save( string path )
        {
            using ( var stream = File.Create( path ) )
            using ( var skiaStream = new SKManagedWStream( stream ) )
            {
                SKPixmap.Encode( skiaStream, _skiaBitmap, SKEncodedImageFormat.Png, 100 );
            }
        }

        public void Dispose()
        {
            _skiaBitmap.Dispose();
            _skiaCanvas.Dispose();
            _skiaPaint.Dispose();
        }

        private void SetLineStyle()
        {
            _skiaPaint.Style = SKPaintStyle.Stroke;
            _skiaPaint.Color = LineColor.ToSkiaColor();
            _skiaPaint.StrokeWidth = LineThickness;
        }

        private void SetFillStyle()
        {
            _skiaPaint.Style = SKPaintStyle.Fill;
            _skiaPaint.Color = FillColor.ToSkiaColor();
        }
    }
}
