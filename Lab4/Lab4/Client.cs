using System;
using System.Collections.Generic;
using Lab4.Canvas;
using Lab4.Designer;
using Lab4.Painter;

namespace Lab4
{
    class Client
    {
        private readonly IDesigner _designer;
        private readonly IPainter _painter;
        private readonly ICanvas _canvas;
        private readonly List<string> _shapeDescriptions;

        public Client( IDesigner designer, IPainter painter, ICanvas canvas )
        {
            _designer = designer;
            _painter = painter;
            _canvas = canvas;
            _shapeDescriptions = new List<string>();
        }

        public void Run()
        {
            Help();
            bool exit = false;
            while ( !exit )
            {
                string command = Console.ReadLine();
                if ( command == "exit" )
                {
                    exit = true;
                }
                else
                {
                    MakeActionByCommand( command );
                }
            }
        }

        private void Help()
        {
            Console.WriteLine( "help - show possible instructions" );
            Console.WriteLine( "paint - painter draw by picture draft from designer" );
            Console.WriteLine( "clear - remove all from picture draft" );
            Console.WriteLine( "exit - exit from program" );
            Console.WriteLine( "Bottom commands send shapes to designer(Designer not understand what you want, if you describe shape incorrectly):" );
            Console.WriteLine( "Ellipse <color> <center.X> <center.Y> <horizontalRadius> <verticalRadius>" );
            Console.WriteLine( "Rectangle <color> <leftTop.X> <leftTop.Y> <rightBottom.X> <rightBottom.Y>" );
            Console.WriteLine( "RegularPolygon <color> <vertexCount> <radius> <center.x> <center.y>" );
            Console.WriteLine( "Triangle <color> <vertex1.x> <vertex1.Y> <vertex2.x> <vertex2.Y> <vertex3.x> <vertex3.Y>" );
        }

        private void Paint()
        {
            PictureDraft picruteDraft = _designer.CreateDraft( _shapeDescriptions );
            _painter.DrawPicture( picruteDraft, _canvas );
        }

        private void Clear()
        {
            _shapeDescriptions.Clear();
        }

        private void MakeActionByCommand( string command )
        {
            switch ( command )
            {
                case "help":
                    Help();
                    break;
                case "paint":
                    Paint();
                    break;
                case "clear":
                    Clear();
                    break;
                default:
                    _shapeDescriptions.Add( command );
                    break;
            }
        }
    }
}
