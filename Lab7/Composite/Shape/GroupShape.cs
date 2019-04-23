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

        public Rect Frame { get => GetFrame(); set => SetFrame( value ); }
        public LineStyle LineStyle { get => GetLineStyle(); }
        public BaseStyle FillStyle { get => GetFillStyle(); }

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
            int firstDefinedFrameIndex = _shapes.FindIndex( s => s.Frame != null );
            if ( firstDefinedFrameIndex == -1 )
            {
                return null;
            }

            Rect firstDefinedFrame = _shapes[ firstDefinedFrameIndex ].Frame;
            float left = firstDefinedFrame.Left;
            float top = firstDefinedFrame.Top;
            float width = firstDefinedFrame.Width;
            float height = firstDefinedFrame.Height;

            for ( int i = firstDefinedFrameIndex + 1; i < ShapesCount; i++ )
            {
                Rect currentFrame = _shapes[ i ].Frame;
                if ( currentFrame == null )
                {
                    continue;
                }

                float maxRight = Math.Max( left + width, currentFrame.Left + currentFrame.Width );
                float minTop = Math.Min( top - height, currentFrame.Top - currentFrame.Height );

                left = Math.Min( left, currentFrame.Left );
                top = Math.Max( top, currentFrame.Top );
                width = maxRight - left;
                height = top - minTop;

            }

            return new Rect( left, top, width, height );
        }

        private void SetFrame( Rect newFrame )
        {
            if ( Frame == null )
            {
                return;
            }

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
            LineStyle result = null;

            if ( ShapesCount == 0 )
            {
                return result;
            }

            LineStyle firstLineStyle = _shapes.First().LineStyle;
            bool isAllStylesEqual = _shapes.All( s => s.LineStyle.Equals( firstLineStyle ) );
            if ( isAllStylesEqual )
            {
                result = firstLineStyle.Copy();
                result.OnColorChange += () => ChangeChildsLineColor( result.Color );
                result.OnEnablingStateChange += () => ChangeChildsLineStyleEnablingState( result.IsEnabled );
                result.OnThicknessChange += () => ChangeChildsLineThickness( result.Thickness );
            }

            return result;
        }

        private void ChangeChildsLineColor( Color color )
        {
            foreach ( IShape shape in _shapes )
            {
                shape.LineStyle.Color = color;
            }
        }

        private void ChangeChildsLineStyleEnablingState( bool enable )
        {
            foreach ( IShape shape in _shapes )
            {
                shape.LineStyle.Enable( enable );
            }
        }

        private void ChangeChildsLineThickness( float thickness )
        {
            foreach ( IShape shape in _shapes )
            {
                shape.LineStyle.Thickness = thickness;
            }
        }

        private BaseStyle GetFillStyle()
        {
            BaseStyle result = null;

            if ( ShapesCount == 0 )
            {
                return result;
            }

            BaseStyle firstFillStyle = _shapes.First().FillStyle;
            bool isAllStylesEqual = _shapes.All( s => s.FillStyle.Equals( firstFillStyle ) );
            if ( isAllStylesEqual )
            {
                result = firstFillStyle.Copy();
                result.OnColorChange += () => ChangeChildsFillColor( result.Color );
                result.OnEnablingStateChange += () => ChangeChildsFillStyleEnablingState( result.IsEnabled );
            }

            return result;
        }

        private void ChangeChildsFillColor( Color color )
        {
            foreach ( IShape shape in _shapes )
            {
                shape.FillStyle.Color = color;
            }
        }

        private void ChangeChildsFillStyleEnablingState( bool enable )
        {
            foreach ( IShape shape in _shapes )
            {
                shape.FillStyle.Enable( enable );
            }
        }
    }
}
