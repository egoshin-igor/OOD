using System.IO;

namespace Adapter.ModernGrapicsLib
{
    public class ModernGraphicsRenderer
    {
        private readonly TextWriter _output;
        private bool _drawing = false;

        public ModernGraphicsRenderer( TextWriter output )
        {
            _output = output;
        }

        ~ModernGraphicsRenderer()
        {
            if ( _drawing ) // Завершаем рисование, если оно было начато
            {
                EndDraw();
            }
        }

        // Этот метод должен быть вызван в начале рисования
        public void BeginDraw()
        {
            if ( _drawing )
            {
                throw new GraphicsLogicalException( "Drawing has already begun" );
            }

            _output.WriteLine( "<draw>" );
            _drawing = true;
        }

        // Выполняет рисование линии
        public void DrawLine( Point start, Point end )
        {
            if ( !_drawing )
            {
                throw new GraphicsLogicalException( "DrawLine is allowed between BeginDraw()/EndDraw() only" );
            }

            _output.WriteLine( $"<line fromX={start.X} fromY={start.Y} toX={end.X} toY={end.Y}/>" );
        }

        // Этот метод должен быть вызван в конце рисования
        public void EndDraw()
        {
            if ( !_drawing )
            {
                throw new GraphicsLogicalException( "Drawing has not been started" );
            }

            _output.WriteLine( "</draw>" );
            _drawing = false;
        }
    }
}
