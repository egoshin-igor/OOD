using System;
using Composite.Shape;
using Moq;
using Xunit;
using Color = System.Drawing.Color;

namespace Composite.Tests.Shape
{
    public class GroupeShapeTest
    {
        private Mock<IShape> _shapeMock = new Mock<IShape>();
        private Mock<IGroupShape> _groupShapeMock = new Mock<IGroupShape>();

        [Fact]
        public void ShapesCount_InitShape_ShapesCountEqualsZero()
        {
            // Arrange
            // Act
            var groupShape = new GroupShape();

            // Assert
            Assert.Equal( 0, groupShape.ShapesCount );
        }


        [Fact]
        public void InsertShape_InsertFirstShape_ShapesCountEqualsOne()
        {
            // Arrange
            var groupShape = new GroupShape();

            // Act
            groupShape.InsertShape( _shapeMock.Object, 0 );

            // Assert
            Assert.Equal( 1, groupShape.ShapesCount );
        }

        [Fact]
        public void InsertShape_IndexOutOfRange_ThrowsOutOfRangeException()
        {
            // Arrange
            var groupShape = new GroupShape();

            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>( () => groupShape.InsertShape( _shapeMock.Object, 3 ) );
        }

        [Fact]
        public void GetShapeAtIndex_ShapeHasInsertedBefore_GetInsertedShape()
        {
            // Arrange
            var groupShape = new GroupShape();
            groupShape.InsertShape( _shapeMock.Object, 0 );

            // Act
            IShape result = groupShape.GetShapeAtIndex( 0 );

            // Assert
            Assert.Same( _shapeMock.Object, result );
        }


        [Fact]
        public void GetShapeAtIndex_GroupShapeHasInserted_GetInsertedGroupShape()
        {
            // Arrange
            var groupShape = new GroupShape();
            groupShape.InsertShape( _groupShapeMock.Object, 0 );

            // Act
            var result = groupShape.GetShapeAtIndex( 0 ) as IGroupShape;

            // Assert
            Assert.Same( _groupShapeMock.Object, result );
        }

        [Fact]
        public void GetShapeAtIndex_IndexOutOfRange_ThrowsOutOfRangeException()
        {
            // Arrange
            var groupShape = new GroupShape();

            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>( () => groupShape.GetShapeAtIndex( 0 ) );
        }

        [Fact]
        public void RemoveShapeAtIndex_ShapeCountEqualsOne_ShapesCountEqualsZero()
        {
            // Arrange
            var groupShape = new GroupShape();
            groupShape.InsertShape( _shapeMock.Object, 0 );

            // Act
            groupShape.RemoveShapeAtIndex( 0 );

            // Assert
            Assert.Equal( 0, groupShape.ShapesCount );
        }

        [Fact]
        public void RemoveShapeAtIndex_IndexOutOfRange_ThrowsOutOfRangeException()
        {
            // Arrange
            var groupShape = new GroupShape();

            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>( () => groupShape.RemoveShapeAtIndex( 0 ) );
        }

        [Fact]
        public void GetFrame_EmptyGroupShape_ReturnNull()
        {
            // Arrange
            var groupShape = new GroupShape();

            // Act
            Rect? result = groupShape.GetFrame();

            // Assert
            Assert.Null( result );
        }

        [Fact]
        public void GetFrame_GroupShapeHasOnePhigure_ReturnThisPhigureFrame()
        {
            // Arrange
            var groupShape = new GroupShape();
            var shape = new Rectangle( new Rect( 1, 1, 1, 1 ) );
            groupShape.InsertShape( shape, 0 );

            // Act
            Rect? result = groupShape.GetFrame();

            // Assert
            Assert.Equal( shape.GetFrame(), result );
        }

        [Fact]
        public void GetFrame_GroupShapeHasTwoPhigure_ReturnCombinedFrame()
        {
            // Arrange
            var groupShape = new GroupShape();
            var rectangle = new Rectangle( new Rect( left: 0, top: 1, width: 2, height: 1 ) );
            var ellipse = new Rectangle( new Rect( left: 1, top: 2, width: 1.5f, height: 1 ) );
            groupShape.InsertShape( rectangle, 0 );
            groupShape.InsertShape( ellipse, 1 );
            var expectedFrame = new Rect( 0, 2, 2.5f, 2 );

            // Act
            Rect? result = groupShape.GetFrame();

            // Assert
            Assert.Equal( expectedFrame, result );
        }

        [Fact]
        public void GetFrame_GroupShapeHasAnotherGroupShape_ReturnCombinedFrame()
        {
            // Arrange
            var groupShapeOne = new GroupShape();
            var rectangle = new Rectangle( new Rect( left: 0, top: 1, width: 2, height: 1 ) );
            var ellipse = new Rectangle( new Rect( left: 1, top: 2, width: 1.5f, height: 1 ) );
            groupShapeOne.InsertShape( rectangle, 0 );
            groupShapeOne.InsertShape( ellipse, 1 );
            var groupShapeTwo = new GroupShape();
            groupShapeTwo.InsertShape( groupShapeOne, 0 );
            groupShapeTwo.InsertShape( rectangle, 1 );

            var expectedFrame = new Rect( 0, 2, 2.5f, 2 );

            // Act
            Rect? result = groupShapeTwo.GetFrame();

            // Assert
            Assert.True( result.HasValue );
            Assert.Equal( expectedFrame, result );
        }

        [Fact]
        public void SetFrame_SetToSimpleShape_GetSettedFrame()
        {
            // Arrange
            var groupShape = new GroupShape();
            var rectangle = new Rectangle( new Rect( left: 0, top: 1, width: 2, height: 1 ) );
            groupShape.InsertShape( rectangle, 0 );
            var expectedFrame = new Rect( 3, 3, 3, 3 );

            // Act
            groupShape.SetFrame( expectedFrame );
            Rect? result = groupShape.GetFrame();

            // Assert
            Assert.True( result.HasValue );
            Assert.Equal( expectedFrame, result );
        }

        [Fact]
        public void SetFrame_GroupShapeHasChild_ChangeChildFrameCorrectly()
        {
            // Arrange
            var groupShape = new GroupShape();
            var rectangle = new Rectangle( new Rect( left: 0, top: 1, width: 2, height: 1 ) );
            groupShape.InsertShape( rectangle, 0 );
            var expectedChildFrame = new Rect( 3, 3, 3, 3 );

            // Act
            groupShape.SetFrame( new Rect( 3, 3, 3, 3 ) );
            Rect? result = groupShape.GetShapeAtIndex( 0 ).GetFrame();

            // Assert
            Assert.True( result.HasValue );
            Assert.Equal( expectedChildFrame, result );
        }

        [Fact]
        public void SetFrame_GroupShapeHasTwoChilds_ChildsFrameChangedCorrectly()
        {
            // Arrange
            var groupShape = new GroupShape();
            var rectangle = new Rectangle( new Rect( left: 0, top: 1, width: 2, height: 1 ) );
            var ellipse = new Rectangle( new Rect( left: 1, top: 2, width: 1.5f, height: 1 ) );
            groupShape.InsertShape( rectangle, 0 );
            groupShape.InsertShape( ellipse, 1 );
            var expectedRectangleFrame = new Rect( 0, 0.5f, 0.8f, 0.5f );
            var expectedEllipseFrame = new Rect( 0.4f, 1f, 0.6f, 0.5f );

            // Act
            groupShape.SetFrame( new Rect( 0, 1, 1, 1 ) );
            Rect? rectangleFrame = groupShape.GetShapeAtIndex( 0 ).GetFrame();
            Rect? ellipseFrame = groupShape.GetShapeAtIndex( 1 ).GetFrame();

            // Assert
            Assert.True( rectangleFrame.HasValue && ellipseFrame.HasValue );
            Assert.Equal( expectedRectangleFrame, rectangleFrame );
            Assert.Equal( expectedEllipseFrame, ellipseFrame );
        }

        [Fact]
        public void GetLineStyle_ChildsWithoutStyles_ReturnDefaultStyle()
        {
            // Arrange
            GroupShape groupShape = GetGroupShape( 3 );
            var expectedStyle = new LineStyle( Color.Empty, thickness: 0 );

            // Act
            ILineStyle result = groupShape.LineStyle;

            // Assert
            Assert.True( Equals( expectedStyle, result ) );
        }

        [Fact]
        public void GetFillStyle_ChildsWithoutStyles_ReturnDefaultStyle()
        {
            // Arrange
            GroupShape groupShape = GetGroupShape( 3 );
            var expectedStyle = new BaseStyle( Color.Empty );

            // Act
            IStyle result = groupShape.FillStyle;

            // Assert
            Assert.Equal( expectedStyle, result );
        }

        [Fact]
        public void GetLineStyle_ChildsWithEqualStyles_ReturnThisStyle()
        {
            // Arrange
            var lineStyle = new LineStyle( Color.Black, thickness: 1 );
            GroupShape groupShape = GetGroupShape( 3, lineStyle );

            // Act
            ILineStyle result = groupShape.LineStyle;

            // Assert
            Assert.True( Equals( lineStyle, result ) );
        }

        [Fact]
        public void GetFillStyle_ChildsWithEqualStyles_ReturnThisStyle()
        {
            // Arrange
            var fillStyle = new BaseStyle( Color.Black );
            GroupShape groupShape = GetGroupShape( 3, lineStyle: null, fillStyle );

            // Act
            IStyle result = groupShape.FillStyle;

            // Assert
            Assert.Equal( fillStyle, result );
        }

        [Fact]
        public void GetFillStyle_ChildsWithDifferentStyles_ReturnNull()
        {
            // Arrange
            var fillStyle = new BaseStyle( Color.Black );
            GroupShape groupShape = GetGroupShape( 3, lineStyle: null, fillStyle );
            groupShape.GetShapeAtIndex( 0 ).FillStyle.Color = Color.Blue;

            // Act
            IStyle result = groupShape.FillStyle;

            // Assert
            Assert.Null( result );
        }

        [Fact]
        public void GetLineStyle_OneOfTheChildIsGroupShapeAndChildsStyleEquals_ReturnThisStyle()
        {
            // Arrange
            var lineStyle = new LineStyle( Color.Black, thickness: 1 );
            GroupShape groupShape = GetGroupShape( 3, lineStyle );
            groupShape.InsertShape( GetGroupShape( 3, lineStyle ), 0 );

            // Act
            ILineStyle result = groupShape.LineStyle;

            // Assert
            Assert.True( Equals( lineStyle, result ) );
        }

        [Fact]
        public void GetLineStyle_ChangeStyleColor_AllChildsUpdateColorToThisOne()
        {
            // Arrange
            var lineStyle = new LineStyle( Color.Black, thickness: 1 );
            GroupShape groupShape = GetGroupShape( 3, lineStyle );
            groupShape.InsertShape( GetGroupShape( 3, lineStyle ), 0 );

            // Act
            ILineStyle result = groupShape.LineStyle;
            result.Color = Color.Red;

            // Assert
            for ( int i = 0; i < groupShape.ShapesCount; i++ )
            {
                IShape shape = groupShape.GetShapeAtIndex( i );
                Assert.Equal( Color.Red, shape.LineStyle.Color );
            }
        }

        [Fact]
        public void GetLineStyle_ChildStyleChangeColor_ParentStyleColorIsEmpty()
        {
            // Arrange
            var lineStyle = new LineStyle( Color.Black, thickness: 1 );
            GroupShape groupShape = GetGroupShape( 3, lineStyle );
            var childShape = GetGroupShape( 3, lineStyle );
            groupShape.InsertShape( childShape, 0 );
            childShape.LineStyle.Color = Color.White;

            // Act
            ILineStyle result = groupShape.LineStyle;

            // Assert
            Assert.Equal( Color.Empty, result.Color );
        }


        private GroupShape GetGroupShape( int shapeCount, LineStyle lineStyle = null, BaseStyle fillStyle = null )
        {
            var result = new GroupShape();

            for ( int i = 0; i < shapeCount; i++ )
            {
                var frame = new Rect( left: 0, top: 1, width: 2, height: 1 );
                IShape shape = new Rectangle( frame, lineStyle, fillStyle );
                result.InsertShape( shape, i );
            }

            return result;
        }

        private bool Equals( IStyle first, IStyle second )
        {
            return first.Color == second.Color && first.IsEnabled == second.IsEnabled;
        }

        private bool Equals( ILineStyle first, ILineStyle second )
        {
            return Equals( first as IStyle, second as IStyle ) && first.Thickness == second.Thickness;
        }
    }
}
