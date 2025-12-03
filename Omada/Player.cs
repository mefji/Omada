using System.Numerics;

namespace Omada
{
    internal class Player
    {
        public Vector2 Position;
        public int Rows;
        public int Cols;
        public char[,] Shape;

        public Player(Vector2 position, int rows, int cols)
        {
            Position = position;
            Rows = rows;
            Cols = cols;
            Shape = ShapeFactory.CreateBox('@', Rows, Cols);
        }

        public void UpdateShape()
        {
            Shape = ShapeFactory.CreateBox('@', Rows, Cols);
        }
    }
}
