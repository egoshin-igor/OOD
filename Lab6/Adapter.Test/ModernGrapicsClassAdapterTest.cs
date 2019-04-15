using System.Collections.Generic;
using System.IO;
using Moq;
using Adapter.Adapter;
using Xunit;

namespace Adapter.Test
{
    public class ModernGrapicsClassAdapterTest
    {
        private readonly Mock<TextWriter> _textWriterMock;
        private List<string> _lastWritedStrings = new List<string>();

        public ModernGrapicsClassAdapterTest()
        {
            _textWriterMock = new Mock<TextWriter>();
            _textWriterMock
                .Setup( tw => tw.WriteLine( It.IsAny<string>() ) )
                .Callback( ( string str ) => _lastWritedStrings.Add( str ) );
        }

        [Fact]
        public void LineTo_ColorAndStartPositionUndefined_DrawLineWithDefaultColorAndStartPosition()
        {
            // Arrange
            _lastWritedStrings.Clear();
            var modernGrapicsClassAdapter = new ModernGrapicsClassAdapter( _textWriterMock.Object );

            // Act
            modernGrapicsClassAdapter.BeginDraw();
            modernGrapicsClassAdapter.LineTo( 2, 2 );
            modernGrapicsClassAdapter.EndDraw();

            // Assert
            Assert.Equal( expected: 5, _lastWritedStrings.Count );
            Assert.Equal( expected: "<draw>", _lastWritedStrings[ 0 ] );
            Assert.Equal(
                expected: "<line fromX=0 fromY=0 toX=2 toY=2>",
                _lastWritedStrings[ 1 ]
            );
            Assert.Equal(
                expected: "  <color r=\"0\" g=\"0\" b=\"0\" a=\"0\" />",
                _lastWritedStrings[ 2 ]
            );
            Assert.Equal( expected: "</line>", _lastWritedStrings[ 3 ] );
            Assert.Equal( expected: "</draw>", _lastWritedStrings[ 4 ] );
        }

        [Fact]
        public void LineTo_StartPositionDefined_DrawFromStartPositionToNewPosition()
        {
            // Arrange
            int lineTagBeginingIndex = 1;
            int lineTagEndingIndex = 3;
            _lastWritedStrings.Clear();
            var modernGrapicsClassAdapter = new ModernGrapicsClassAdapter( _textWriterMock.Object );

            // Act
            modernGrapicsClassAdapter.BeginDraw();
            modernGrapicsClassAdapter.MoveTo( 1, 1 );
            modernGrapicsClassAdapter.LineTo( 2, 2 );
            modernGrapicsClassAdapter.EndDraw();

            // Assert
            Assert.Equal( expected: 5, _lastWritedStrings.Count );
            Assert.Equal(
                expected: "<line fromX=1 fromY=1 toX=2 toY=2>",
                _lastWritedStrings[ lineTagBeginingIndex ]
            );
            Assert.Equal( expected: "</line>", _lastWritedStrings[ lineTagEndingIndex ] );
        }

        [Fact]
        public void SetColor_DefineColor_DrawWithDefinedColor()
        {
            // Arrange
            int lineColorIndex = 2;
            _lastWritedStrings.Clear();
            var modernGrapicsClassAdapter = new ModernGrapicsClassAdapter( _textWriterMock.Object );

            // Act
            modernGrapicsClassAdapter.BeginDraw();
            modernGrapicsClassAdapter.SetColor( 0xAAEEFF );
            modernGrapicsClassAdapter.MoveTo( 1, 1 );
            modernGrapicsClassAdapter.LineTo( 2, 2 );
            modernGrapicsClassAdapter.EndDraw();

            // Assert
            Assert.Equal( expected: 5, _lastWritedStrings.Count );
            Assert.Equal(
                expected: "  <color r=\"0,67\" g=\"0,93\" b=\"1\" a=\"1\" />",
                _lastWritedStrings[ lineColorIndex ]
            );
        }
    }
}
