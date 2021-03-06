﻿using System;
using Adapter.Adapter;
using Adapter.GraphicsLib;
using Adapter.ModernGrapicsLib;
using Adapter.ShapeDrawingLib;

namespace Adapter
{
    class Program
    {
        static void Main( string[] args )
        {
            Console.WriteLine( $"Should we use new API (y)?" );
            string userInput = Console.ReadLine().ToLower();

            if ( userInput.ToLower() == "y" )
            {
                Console.WriteLine( "Object adapter:" );
                PaintPictureOnModernGraphicsRendererWithObjectAdapter();
                Console.WriteLine();
                Console.WriteLine( "Class adapter:" );
                PaintPictureOnModernGraphicsRendererWithClassAdapter();
            }
            else
            {
                PaintPictureOnCanvas();
            }
        }

        private static void PaintPicture( CanvasPainter painter )
        {
            var triangle = new Triangle(
                new ShapeDrawingLib.Point( 10, 15 ),
                new ShapeDrawingLib.Point( 100, 200 ),
                new ShapeDrawingLib.Point( 150, 250 ),
                0xFFFFFF
            );

            var rectangle = new Rectangle( new ShapeDrawingLib.Point( 30, 40 ), 18, 24, 0xEEAA11 );
            Console.WriteLine( "Triangle:" );
            painter.Draw( triangle );
            Console.WriteLine( "Rectangle" );
            painter.Draw( rectangle );
        }

        private static void PaintPictureOnCanvas()
        {
            Canvas simpleCanvas = new Canvas();
            CanvasPainter painter = new CanvasPainter( simpleCanvas );
            PaintPicture( painter );
        }

        private static void PaintPictureOnModernGraphicsRendererWithObjectAdapter()
        {
            var renderer = new ModernGraphicsRenderer( Console.Out );
            var modernGrapicsObjectAdapter = new ModernGrapicsObjectAdapter( renderer );
            var painter = new CanvasPainter( modernGrapicsObjectAdapter );

            modernGrapicsObjectAdapter.BeginDraw();
            PaintPicture( painter );
            modernGrapicsObjectAdapter.EndDraw();
        }

        private static void PaintPictureOnModernGraphicsRendererWithClassAdapter()
        {
            var modernGrapicsClassAdapter = new ModernGrapicsClassAdapter( Console.Out );
            var painter = new CanvasPainter( modernGrapicsClassAdapter );

            modernGrapicsClassAdapter.BeginDraw();
            PaintPicture( painter );
            modernGrapicsClassAdapter.EndDraw();
        }
    }
}
