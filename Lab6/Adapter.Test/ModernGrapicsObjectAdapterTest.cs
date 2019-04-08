using System.Collections.Generic;
using System.IO;
using Moq;
using Adapter.Adapter;
using Adapter.ModernGrapicsLib;
using Xunit;

namespace Adapter.Test
{
    public class ModernGrapicsObjectAdapterTest
    {
        private readonly Mock<TextWriter> _textWriterMock;
        private readonly Mock<ModernGraphicsRenderer> _modernGraphicsRendererMock;
        private List<string> _lastWritedStrings = new List<string>();

        public ModernGrapicsObjectAdapterTest()
        {
            _textWriterMock = new Mock<TextWriter>();
            _textWriterMock
                .Setup( tw => tw.WriteLine( It.IsAny<string>() ) )
                .Callback( ( string str ) => _lastWritedStrings.Add( str ) );

            _modernGraphicsRendererMock = new Mock<ModernGraphicsRenderer>( _textWriterMock.Object );
        }

        [Fact]
        public void LineTo_DrawFromDefaultPositionToNewPosition()
        {
            // Arrange
            _lastWritedStrings.Clear();
            var modernGrapicsObjectAdapter = new ModernGrapicsObjectAdapter( _modernGraphicsRendererMock.Object );

            // Act
            modernGrapicsObjectAdapter.LineTo( 2, 2 );

            // Assert
            Assert.Equal( expected: 3, _lastWritedStrings.Count );
            Assert.Equal( expected: "<draw>", _lastWritedStrings[ 0 ] );
            Assert.Equal(
                expected: "<line fromX=0 fromY=0 toX=2 toY=2/>",
                _lastWritedStrings[ 1 ]
            );
            Assert.Equal( expected: "</draw>", _lastWritedStrings[ 2 ] );
        }

        [Fact]
        public void MoveToAndLineTo_DrawFromStartPositionToNewPosition()
        {
            // Arrange
            _lastWritedStrings.Clear();
            var modernGrapicsObjectAdapter = new ModernGrapicsObjectAdapter( _modernGraphicsRendererMock.Object );

            // Act
            modernGrapicsObjectAdapter.MoveTo( 1, 1 );
            modernGrapicsObjectAdapter.LineTo( 2, 2 );

            // Assert
            Assert.Equal( expected: 3, _lastWritedStrings.Count );
            Assert.Equal( expected: "<draw>", _lastWritedStrings[ 0 ] );
            Assert.Equal(
                expected: "<line fromX=1 fromY=1 toX=2 toY=2/>",
                _lastWritedStrings[ 1 ]
            );
            Assert.Equal( expected: "</draw>", _lastWritedStrings[ 2 ] );
        }
    }
}