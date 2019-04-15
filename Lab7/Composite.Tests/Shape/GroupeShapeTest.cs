using System;
using Composite.Shape;
using Moq;
using Xunit;

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
    }
}
