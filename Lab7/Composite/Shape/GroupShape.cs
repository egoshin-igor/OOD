using System;
using System.Collections.Generic;
using System.Linq;
using Composite.Canvas;

namespace Composite.Shape
{
    public class GroupShape : IGroupShape
    {
        private readonly List<IShape> _shapes = new List<IShape>();

        public int ShapesCount => _shapes.Count;

        public Rect Frame { get => GetFrame(); set => SetFrame( value ); }
        public LineStyle LineStyle { get => GetLineStyle(); set => SetLineStyle( value ); }
        public FillStyle FillStyle { get => GetFillStyle(); set => SetFillStyle( value ); }

        public void Draw( ICanvas canvas )
        {
            for ( int i = 0; i < _shapes.Count; ++i )
            {
                _shapes[ i ].Draw( canvas );
            }
        }

        public IShape GetShapeAtIndex( int index )
        {
            return _shapes[ index ];
        }

        public void InsertShape( IShape shape, int index )
        {
            _shapes.Insert( index, shape );
        }

        public void RemoveShapeAtIndex( int index )
        {
            _shapes.RemoveAt( index );
        }

        private Rect GetFrame()
        {
            if ( ShapesCount == 0 )
            {
                return null;
            }

            Rect firstFrame = _shapes[ 0 ].Frame;
            float left = firstFrame.Left;
            float top = firstFrame.Top;
            float width = firstFrame.Width;
            float height = firstFrame.Height;

            for ( int i = 1; i < ShapesCount; i++ )
            {
                Rect currentFrame = _shapes[ i ].Frame;
                Math.Min( left, currentFrame.Left );
                Math.Max( top, currentFrame.Top );
                Math.Max( width, currentFrame.Width );
                Math.Max( height, currentFrame.Height );
            }

            return new Rect( left, top, width, height );
        }

        private void SetFrame( Rect newFrame )
        {
            Rect currentFrame = Frame;
            float widthScale = newFrame.Width / currentFrame.Width;
            float heightScale = newFrame.Height / currentFrame.Height;

            foreach ( IShape shape in _shapes )
            {
                Rect shapeFrame = shape.Frame;
                float leftDiff = shapeFrame.Left - currentFrame.Left;
                float topDiff = shapeFrame.Top - currentFrame.Top;

                shape.Frame = new Rect(
                    left: newFrame.Left + leftDiff * widthScale,
                    top: newFrame.Top + topDiff * heightScale,
                    width: shapeFrame.Width * widthScale,
                    height: shapeFrame.Height * heightScale
                );
            }
        }

        private LineStyle GetLineStyle()
        {
            if ( ShapesCount == 0 )
            {
                return null;
            }

            LineStyle firstLineStyle = _shapes.First().LineStyle;

            return _shapes.All( s => s.LineStyle == firstLineStyle ) ? firstLineStyle.Copy() : null;
        }

        private void SetLineStyle( LineStyle lineStyle )
        {
            foreach ( IShape shape in _shapes )
            {
                shape.LineStyle = lineStyle;
            }
        }

        private FillStyle GetFillStyle()
        {
            if ( ShapesCount == 0 )
            {
                return null;
            }

            FillStyle firstLineStyle = _shapes.First().FillStyle;

            return _shapes.All( s => s.FillStyle == firstLineStyle ) ? firstLineStyle.Copy() : null;
        }

        private void SetFillStyle( FillStyle fillStyle )
        {
            foreach ( IShape shape in _shapes )
            {
                shape.FillStyle = fillStyle;
            }
        }
    }
}
