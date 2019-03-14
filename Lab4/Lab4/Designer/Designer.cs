using System;
using System.Collections.Generic;
using Lab4.Shape;
using Lab4.Shape.Factory;

namespace Lab4.Designer
{
    class Designer : IDesigner
    {
        private readonly IShapeFactory _shapeFactory;
        public Designer( IShapeFactory shapeFactory )
        {
            _shapeFactory = shapeFactory;
        }

        public PictureDraft CreateDraft( List<string> shapeDescriptions )
        {
            var shapes = new List<BaseShape>();

            foreach ( string shapeDescription in shapeDescriptions )
            {
                try
                {
                    BaseShape shape = _shapeFactory.CreateShape( shapeDescription );
                    shapes.Add( shape );
                }
                catch ( ApplicationException )
                {
                    Console.WriteLine( $"Incorrect shape decription: {shapeDescription}" );
                }
            }

            return new PictureDraft( shapes );
        }
    }
}
