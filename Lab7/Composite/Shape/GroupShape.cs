using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Composite.Canvas;

namespace Composite.Shape
{
    public class GroupShape : IGroupShape
    {
        private readonly List<IShape> _shapes = new List<IShape>();

        public int ShapesCount => _shapes.Count;

        public ILineStyle LineStyle { get; }
        public IStyle FillStyle { get; }

        public GroupShape()
        {
            FillStyle = new GroupStyle( GetFillStyles() );
            LineStyle = new GroupLineStyle( GetLineStyles() );
        }

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

        public Rect? GetFrame()
        {
            List<Rect> definedChildFrames = _shapes
                .Select( s => s.GetFrame() )
                .Where( dcf => dcf.HasValue )
                .Select( f => f.Value )
                .ToList();

            if ( ShapesCount == 0 || definedChildFrames.Count == 0 )
            {
                return null;
            }

            Rect firstDefinedFrame = definedChildFrames.First();
            float left = firstDefinedFrame.Left;
            float top = firstDefinedFrame.Top;
            float width = firstDefinedFrame.Width;
            float height = firstDefinedFrame.Height;

            for ( int i = 1; i < definedChildFrames.Count; i++ )
            {
                Rect currentFrame = definedChildFrames[ i ];

                float maxRight = Math.Max( left + width, currentFrame.Left + currentFrame.Width );
                float minTop = Math.Min( top - height, currentFrame.Top - currentFrame.Height );

                left = Math.Min( left, currentFrame.Left );
                top = Math.Max( top, currentFrame.Top );
                width = maxRight - left;
                height = top - minTop;
            }

            return new Rect( left, top, width, height );
        }

        public void SetFrame( Rect newFrame )
        {
            Rect? currentFrame = GetFrame();
            if ( currentFrame == null )
            {
                return;
            }

            float widthScale = newFrame.Width / currentFrame.Value.Width;
            float heightScale = newFrame.Height / currentFrame.Value.Height;

            foreach ( IShape shape in _shapes )
            {
                Rect? shapeFrame = shape.GetFrame();
                if ( shapeFrame == null )
                {
                    continue;
                }

                float leftDiff = shapeFrame.Value.Left - currentFrame.Value.Left;
                float topDiff = shapeFrame.Value.Top - currentFrame.Value.Top;

                var neShapeFrame = new Rect(
                    left: newFrame.Left + leftDiff * widthScale,
                    top: newFrame.Top + topDiff * heightScale,
                    width: shapeFrame.Value.Width * widthScale,
                    height: shapeFrame.Value.Height * heightScale
                );
                shape.SetFrame( neShapeFrame );
            }
        }

        private IEnumerable<IStyle> GetFillStyles()
        {
            foreach ( var shape in _shapes )
            {
                yield return shape.FillStyle;
            }
        }

        private IEnumerable<ILineStyle> GetLineStyles()
        {
            foreach ( var shape in _shapes )
            {
                yield return shape.LineStyle;
            }
        }
    }
}
