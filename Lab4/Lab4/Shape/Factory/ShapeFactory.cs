using System;
using System.Collections.Generic;
using System.Linq;
using Lab4.ArgumentsParser;
using Lab4.Enum;

namespace Lab4.Shape.Factory
{
    class ShapeFactory : IShapeFactory
    {
        private static readonly Dictionary<string, Func<ShapeArgumentsParser, BaseShape>> _shapeCreatorByTypeName;

        static ShapeFactory()
        {
            _shapeCreatorByTypeName = new Dictionary<string, Func<ShapeArgumentsParser, BaseShape>>
            {
                { "Triangle", CreateTriangle },
                { "RegularPolygon", CreateRegularPolygon},
                { "Rectangle", CreateRectangle },
                {  "Ellipse", CreateEllipse }
            };
        }

        public BaseShape CreateShape( string shapeDescription )
        {
            string[] shapeDescriptionArguments = shapeDescription.Split( separator: " " );
            var shapeArgumentsParser = new ShapeArgumentsParser( shapeDescriptionArguments );

            string shapeName = GetShapeName( shapeArgumentsParser );
            if ( !_shapeCreatorByTypeName.ContainsKey( shapeName ) )
            {
                throw new ApplicationException( "Such shape not exist" );
            }

            try
            {
                return _shapeCreatorByTypeName[ shapeName ]( shapeArgumentsParser );
            }
            catch ( Exception ex )
            {
                throw new ApplicationException( ex.Message );
            }
        }

        private string GetShapeName( ShapeArgumentsParser shapeArgumentsParser )
        {
            if ( !shapeArgumentsParser.HasNext )
            {
                throw new ApplicationException( "Wrong Amount of arguments" );
            }

            return shapeArgumentsParser.GetNextAsString();
        }

        private static Triangle CreateTriangle( ShapeArgumentsParser shapeArgumentsParser )
        {
            if ( shapeArgumentsParser.NextArgumentsCount != 7 )
            {
                throw new ApplicationException( "Triangle is not created. Wrong count of parametrs" );
            }

            ColorType shapeColor = shapeArgumentsParser.GetNextAsColor();

            var vertex1 = new Point( shapeArgumentsParser.GetNextAsDouble(), shapeArgumentsParser.GetNextAsDouble() );
            var vertex2 = new Point( shapeArgumentsParser.GetNextAsDouble(), shapeArgumentsParser.GetNextAsDouble() );
            var vertex3 = new Point( shapeArgumentsParser.GetNextAsDouble(), shapeArgumentsParser.GetNextAsDouble() );

            return new Triangle( vertex1, vertex2, vertex3, shapeColor );
        }

        private static RegularPolygon CreateRegularPolygon( ShapeArgumentsParser shapeArgumentsParser )
        {
            if ( shapeArgumentsParser.NextArgumentsCount != 5 )
            {
                throw new ApplicationException( "RegularPolygon is not created. Wrong count of parametrs" );
            }

            ColorType shapeColor = shapeArgumentsParser.GetNextAsColor();
            int vertexCount = shapeArgumentsParser.GetNextAsInt();
            double radius = shapeArgumentsParser.GetNextAsDouble();
            var center = new Point( shapeArgumentsParser.GetNextAsDouble(), shapeArgumentsParser.GetNextAsDouble() );

            return new RegularPolygon( vertexCount, radius, center, shapeColor );
        }

        private static Ellipse CreateEllipse( ShapeArgumentsParser shapeArgumentsParser )
        {
            if ( shapeArgumentsParser.NextArgumentsCount != 5 )
            {
                throw new ApplicationException( "Ellipse is not created. Wrong count of parametrs" );
            }

            ColorType shapeColor = shapeArgumentsParser.GetNextAsColor();
            var center = new Point( shapeArgumentsParser.GetNextAsDouble(), shapeArgumentsParser.GetNextAsDouble() );
            double horizontalRadius = shapeArgumentsParser.GetNextAsDouble();
            double verticalRadius = shapeArgumentsParser.GetNextAsDouble();

            return new Ellipse( center, horizontalRadius, verticalRadius, shapeColor );
        }

        private static Rectangle CreateRectangle( ShapeArgumentsParser shapeArgumentsParser )
        {
            if ( shapeArgumentsParser.NextArgumentsCount != 5 )
            {
                return null;
            }

            ColorType shapeColor = shapeArgumentsParser.GetNextAsColor();
            var leftTop = new Point( shapeArgumentsParser.GetNextAsDouble(), shapeArgumentsParser.GetNextAsDouble() );
            var rightBottom = new Point( shapeArgumentsParser.GetNextAsDouble(), shapeArgumentsParser.GetNextAsDouble() );

            return new Rectangle( leftTop, rightBottom, shapeColor );
        }
    }
}
