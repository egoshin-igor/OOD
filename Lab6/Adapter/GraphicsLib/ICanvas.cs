namespace Adapter.GraphicsLib
{
    public interface ICanvas
    {
        // Ставит "перо" в точку x, y
        void MoveTo( int x, int y );
        // Рисует линию с текущей позиции, передвигая перо в точку x, y 
        void LineTo( int x, int y );
    }
}
